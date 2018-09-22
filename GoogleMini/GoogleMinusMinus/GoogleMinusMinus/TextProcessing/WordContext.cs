using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMini.TextProcessing
{
    public class WordContext
    {
        private const int MaxNumOfCharsBeforeMainWord = 200;
        private const int MaxNumOfCharsAfterMainWord = 200;

        /// <summary>
        /// Aynchronously gets the surrounding text that includes the word starting at a particular index
        /// </summary>
        /// <param name="filePath">path to the text file.</param>
        /// <param name="searchText">the word</param>
        /// <param name="charIndex">index of the word's first character.</param>
        /// <returns>returns a tuple of the context and the index of the word in the returned context.</returns>
        public static async Task<(string, int)> GetContext(string filePath, string searchText, int charIndex)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                var sb = new StringBuilder();
                do
                {
                    var line = await streamReader.ReadLineAsync().ConfigureAwait(false);
                    sb.Append(line + "\n");
                } while (!streamReader.EndOfStream && sb.Length - 1 < charIndex);

                // read a little bit more after the main word
                if (!streamReader.EndOfStream)
                {
                    var line = await streamReader.ReadLineAsync().ConfigureAwait(false);
                    sb.AppendLine(line);
                }
                var context = sb.ToString();
                // ensure at most 1 new line before main word
                int numOfNewLinesBeforeMainWord = 0, displayedContextStartIndex = 0;
                for (var i = charIndex; i >= 0; --i)
                {
                    if (context[i] == '\n')
                    {
                        numOfNewLinesBeforeMainWord++;
                        if (numOfNewLinesBeforeMainWord == 2)
                        {
                            displayedContextStartIndex = i + 1;
                            break;
                        }
                    }
                }
                // ensure at most 1 new line after main word
                // and also that num of chars after main word is atmost MaxNumOfCharsAfterMainWord
                int numOfNewLinesAfterMainWord = 0,
                    endIndexLimit = charIndex + searchText.Length + MaxNumOfCharsAfterMainWord,
                    displayedContextEndIndex = Math.Min(endIndexLimit, context.Length - 1);

                for (var i = charIndex + searchText.Length; i < context.Length && i <= endIndexLimit; ++i)
                {
                    if (context[i] == '\n')
                    {
                        numOfNewLinesAfterMainWord++;
                        if (numOfNewLinesAfterMainWord == 2)
                        {
                            displayedContextEndIndex = (context[i - 1] == '\r' ? i - 2 : i - 1);
                            break;
                        }
                    }
                }
                var wordIndexInContext = charIndex - displayedContextStartIndex;
                context = context.Substring(displayedContextStartIndex, displayedContextEndIndex - displayedContextStartIndex + 1).TrimEnd();
                return (context, wordIndexInContext);
            }
        }
    }
}
