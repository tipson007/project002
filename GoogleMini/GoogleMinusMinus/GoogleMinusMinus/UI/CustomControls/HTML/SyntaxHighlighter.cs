using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;

namespace GoogleMini.UI.CustomControls.HTML
{
    public class SyntaxHighlighter
    {
        private class HighlightJob
        {           
            public string ColorKey { get; private set; }
            public int StartIndex { get; private set; }
            public int Length { get; private set; }            
            public IEnumerable<HighlightJob> ChildJobs { get; set; }

            public HighlightJob(string colorKey, int startIndex, int length)
            {
                this.ColorKey = colorKey;
                this.StartIndex = startIndex;
                this.Length = length;
            }

            public bool IsBefore(HighlightJob other)
            {
                return (StartIndex + Length <= other.StartIndex);
            }

            public bool IsAfter(HighlightJob other)
            {
                return (other.StartIndex + other.Length <= StartIndex);
            }
        }

        /// <summary>
        /// Represents a collection of HighlightJobs ordered by the index of the substring each job works on
        /// </summary>
        private class HighlightJobCollection : ICollection<HighlightJob>
        {
            private List<HighlightJob> jobs = new List<HighlightJob>();

            public int Count => ((ICollection<HighlightJob>)jobs).Count;

            public bool IsReadOnly => ((ICollection<HighlightJob>)jobs).IsReadOnly;

            public HighlightJob this[int index]
            {
                get
                {
                    return jobs[index];
                }                
            }

            /// <summary>
            /// Gets the index to place the job only if the job doesn't try to work on the same portion of text as another job already in the list.            
            /// </summary>
            /// <param name="job"></param>           
            /// <returns>index to place the job, otherwise -1</returns>
            internal int GetInsertionPoint(HighlightJob job)
            {
                if (job == null)
                    return -1;
                int low = 0, high = jobs.Count, mid;
                while (low < high)
                {
                    mid = low + (high - low) / 2;
                    if (job.IsAfter(jobs[mid]))
                        low = mid + 1;
                    else if (job.IsBefore(jobs[mid]))
                        high = mid;
                    else
                        return -1;
                }                
                return low;
            }
                        
            internal bool TryInsert(HighlightJob job)
            {
                var insertionPoint = GetInsertionPoint(job);
                if (insertionPoint == -1)
                    return false;
                jobs.Insert(insertionPoint, job);
                return true;
            }

            internal void AddJobs(IEnumerable<HighlightJob> jobs)
            {
                foreach (var item in jobs)
                {
                    TryInsert(item);
                }
            }

            public void Insert(int index, HighlightJob job)
            {
                if (index == jobs.Count || job.IsBefore(jobs[index]))
                    jobs.Insert(index, job);
            }

            public void Add(HighlightJob item)
            {
                ((ICollection<HighlightJob>)jobs).Add(item);
            }

            public void Clear()
            {
                ((ICollection<HighlightJob>)jobs).Clear();
            }

            public bool Contains(HighlightJob item)
            {
                return ((ICollection<HighlightJob>)jobs).Contains(item);
            }

            public void CopyTo(HighlightJob[] array, int arrayIndex)
            {
                ((ICollection<HighlightJob>)jobs).CopyTo(array, arrayIndex);
            }

            public bool Remove(HighlightJob item)
            {
                return ((ICollection<HighlightJob>)jobs).Remove(item);
            }

            public IEnumerator<HighlightJob> GetEnumerator()
            {
                return ((ICollection<HighlightJob>)jobs).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((ICollection<HighlightJob>)jobs).GetEnumerator();
            }
        }

        public string SourceCode { get; private set; }
        public CancellationToken? CancellationToken { get; private set; }
        public IList<SyntaxHighlightDescriptor> Descriptors { get; private set; }

        public SyntaxHighlighter(string text, IList<SyntaxHighlightDescriptor> descriptors, CancellationToken? cancellationToken)
        {
            SourceCode = text?? string.Empty;
            Descriptors = descriptors;
            CancellationToken = cancellationToken;
        }

        public string HighlightAsRtf(Dictionary<string, Color> colorDictionary, Color defaultColor, string rtfTemplate)
        {
            var highlightJobs = ApplyDescriptors(SourceCode, 0, Descriptors);
            var rb = new RTFBuilder(rtfTemplate);
            var highlightedTextLength = ConvertHighlightJobsToRichTextFormat(rb, highlightJobs, 0, colorDictionary, defaultColor);
            var leftOver = SourceCode.Length - highlightedTextLength;
            if (leftOver > 0)
            {
                rb.Append(SourceCode.Substring(highlightedTextLength, leftOver), defaultColor);
            }
            return rb.ToString();
        }

        private HighlightJobCollection ApplyDescriptors(string text, int indexOfTextArgInSourceCode, IList<SyntaxHighlightDescriptor> descriptors)
        {
            var jobs = new HighlightJobCollection();            
            foreach (var descriptor in descriptors)
            {
                CancellationToken?.ThrowIfCancellationRequested();
                ApplyDescriptor(text, indexOfTextArgInSourceCode, descriptor, jobs);                
            }
            return jobs;
        }
        
        private void ApplyDescriptor(string text, int indexOfTextArgInSourceCode, SyntaxHighlightDescriptor descriptor, HighlightJobCollection jobs)
        {
            if (descriptor.Pattern == null)
            {
                var job = new HighlightJob(descriptor.ColorKey, indexOfTextArgInSourceCode, text.Length);
                jobs.TryInsert(job);
                return;
            }

            var matches = descriptor.Pattern.Matches(text);
            if (matches.Count == 0)
                return;
            foreach (Match match in matches)
            {
                CancellationToken?.ThrowIfCancellationRequested();
                var job = new HighlightJob(descriptor.ColorKey, indexOfTextArgInSourceCode + match.Index, match.Length);
                var insertionPoint = jobs.GetInsertionPoint(job);
                var processChildDescriptors = (insertionPoint >= 0) && (descriptor.CapturedGroups != null);                
                if (processChildDescriptors)
                {
                    // because regex groups can't overlap, we do not require the added constraint provided by HighlightJobCollection.
                    // A simple List<HighlightJob> is sufficient
                    var childJobs = new List<HighlightJob>();
                    for (var i = 1; i < match.Groups.Count; ++i)
                    {
                        if (descriptor.CapturedGroups.TryGetValue(i, out var childDescriptors))
                        {
                            childJobs.AddRange(ApplyDescriptors(match.Groups[i].Value, indexOfTextArgInSourceCode + match.Groups[i].Index, childDescriptors));
                        }
                    }
                    job.ChildJobs = childJobs;
                }                
                 
                //  A job without a color key leaves its portion of text up for grabs by other jobs.
                //  The portion of its text used by its child jobs (if any) are not available to other jobs                 
                if (!string.IsNullOrEmpty(job.ColorKey) && insertionPoint >= 0)
                {
                    jobs.Insert(insertionPoint, job);
                }
                else if(processChildDescriptors)
                {
                    jobs.AddJobs(job.ChildJobs);
                }
            }
        }
      
        // returns length of characters highlighted.
        private int ConvertHighlightJobsToRichTextFormat(RTFBuilder builder, IEnumerable<HighlightJob> jobs, int startIndex, Dictionary<string, Color> colorDictionary, Color parentColor)
        {
            var currentIndex = startIndex;
            foreach (var job in jobs)                
            {
                CancellationToken?.ThrowIfCancellationRequested();
                if (job.StartIndex != currentIndex)
                {                    
                    builder.Append(SourceCode.Substring(currentIndex, job.StartIndex - currentIndex), parentColor);
                    currentIndex = job.StartIndex;
                }
                
                if (!colorDictionary.TryGetValue(job.ColorKey, out var color))
                    color = parentColor;

                if (job.ChildJobs != null)
                {
                    currentIndex += ConvertHighlightJobsToRichTextFormat(builder, job.ChildJobs, currentIndex, colorDictionary, color);
                    var leftOver = job.StartIndex + job.Length - currentIndex;
                    if (leftOver > 0)
                    {                        
                        builder.Append(SourceCode.Substring(currentIndex, leftOver), color);
                        currentIndex += leftOver;
                    }
                }
                else
                {                    
                    builder.Append(SourceCode.Substring(currentIndex, job.Length), color);
                    currentIndex += job.Length;
                }                                
            }
            return currentIndex - startIndex;
        }               
    }
}
