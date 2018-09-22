using System.IO;
using CSharpTest.Net.Serialization;

namespace GoogleMini.FolderManagement
{
    public class FolderSerializer : ISerializer<Folder>
    {
        public static readonly FolderSerializer Instance = new FolderSerializer();

        public Folder ReadFrom(Stream stream)
        {
            var path = PrimitiveSerializer.String.ReadFrom(stream);
            var dateAdded = PrimitiveSerializer.DateTime.ReadFrom(stream);                       
            return new Folder(path, dateAdded);
        }

        public void WriteTo(Folder value, Stream stream)
        {
            PrimitiveSerializer.String.WriteTo(value.Path, stream);
            PrimitiveSerializer.DateTime.WriteTo(value.DateAdded, stream);
        }
    }
}
