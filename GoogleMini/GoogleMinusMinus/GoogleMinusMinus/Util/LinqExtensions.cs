using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GoogleMini.Util
{
    public static class LinqExtensions
    {
        /// <summary>
        /// See https://stackoverflow.com/questions/20002975/performance-of-skip-and-similar-functions-like-take
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                if (source is IList<T>)
                {
                    IList<T> list = (IList<T>)source;
                    for (int i = count; i < list.Count; i++)
                    {
                        e.MoveNext();
                        yield return list[i];
                    }
                }
                else if (source is IList)
                {
                    IList list = (IList)source;
                    for (int i = count; i < list.Count; i++)
                    {
                        e.MoveNext();
                        yield return (T)list[i];
                    }
                }
                else
                {
                    // .NET framework
                    while (count > 0 && e.MoveNext()) count--;
                    if (count <= 0)
                    {
                        while (e.MoveNext()) yield return e.Current;
                    }
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> collection, int batchSize)
        {
            List<T> nextbatch = new List<T>(batchSize);
            foreach (T item in collection)
            {
                nextbatch.Add(item);
                if (nextbatch.Count == batchSize)
                {
                    yield return nextbatch;
                    nextbatch = new List<T>();
                }
            }

            if (nextbatch.Any())
                yield return nextbatch;
        }
    }
}
