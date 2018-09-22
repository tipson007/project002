namespace GoogleMini.TextProcessing
{
    public class Word
    {        
        public int LocationIndex { get; private set; }        
        public int LineNumber { get; private set; }
        public int ColumnNumber { get; private set; }
        public string Text { get; private set; }

        public Word(string text, int lineNumber, int columnNumber, int locationIndex)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
            LocationIndex = locationIndex;
        }
    }
}
