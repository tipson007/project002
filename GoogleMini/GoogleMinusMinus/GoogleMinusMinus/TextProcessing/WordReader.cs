using System;
using System.Collections.Generic;
using System.IO;

namespace GoogleMini.TextProcessing
{
    public class WordReader : IDisposable
    {       
        private int lineNumber;
        private int columnNumber;
        private int charIndex;
        private StreamReader reader;

        public WordReader(string path)            
        {
            reader = new StreamReader(path);            
            lineNumber = 1;
            columnNumber = 1;
            charIndex = 0;
        }

        public void Dispose()
        {
            ((IDisposable)reader).Dispose();
        }

        public IEnumerable<Word> ReadWords()
        {
            string line = null;
            while((line = reader.ReadLine()) != null)
            {
                var startPos = 0;
                for (var i = 0; i < line.Length; i++, charIndex++, columnNumber++)
                {
                    if (!(char.IsLetter(line[i]) || (char.IsDigit(line[i]) && i!= startPos)))
                    {
                        var s = line.Substring(startPos, i - startPos);
                        startPos = i + 1;
                        if (string.IsNullOrEmpty(s))
                            continue;
                        yield return new Word(s, lineNumber, columnNumber - s.Length, charIndex - s.Length);
                    }
                }
                var lastWordInLine = line.Substring(startPos, line.Length - startPos);
                if (!string.IsNullOrEmpty(lastWordInLine))
                {
                    yield return new Word(lastWordInLine, lineNumber, columnNumber - lastWordInLine.Length, charIndex - lastWordInLine.Length);
                }
                charIndex++;
                lineNumber++;
                columnNumber = 1;
            }            
        }                
    }
}
