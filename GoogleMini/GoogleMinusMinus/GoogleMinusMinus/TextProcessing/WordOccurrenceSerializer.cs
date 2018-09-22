using System.IO;
using CSharpTest.Net.Serialization;

namespace GoogleMini.TextProcessing
{
    public class WordOccurrenceSerializer : ISerializer<WordOccurrence>
    {
        public static readonly WordOccurrenceSerializer Instance = new WordOccurrenceSerializer();

        public WordOccurrence ReadFrom(Stream stream)
        {
            return new WordOccurrence
            {
                FileId = VariantNumberSerializer.Int32.ReadFrom(stream),
                LineNumber = VariantNumberSerializer.Int32.ReadFrom(stream),
                ColumnNumber = VariantNumberSerializer.Int32.ReadFrom(stream),
                CharIndex = VariantNumberSerializer.Int32.ReadFrom(stream)
            };      
        }

        public void WriteTo(WordOccurrence value, Stream stream)
        {
            VariantNumberSerializer.Int32.WriteTo(value.FileId, stream);
            VariantNumberSerializer.Int32.WriteTo(value.LineNumber, stream);
            VariantNumberSerializer.Int32.WriteTo(value.ColumnNumber, stream);
            VariantNumberSerializer.Int32.WriteTo(value.CharIndex, stream);
        }
    }    
}
