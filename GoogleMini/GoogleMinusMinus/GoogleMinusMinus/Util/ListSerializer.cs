using System.Collections.Generic;
using System.IO;
using CSharpTest.Net.Serialization;

namespace GoogleMini.Util
{
    public class ListSerializer<T> : ISerializer<List<T>>         
    {
        private readonly ISerializer<T> _itemSerializer;

        public ListSerializer(ISerializer<T> serializer)
        {
            this._itemSerializer = serializer;
        }

        public List<T> ReadFrom(Stream stream)
        {
            var size = PrimitiveSerializer.Int32.ReadFrom(stream);
            if (size < 0)
                return null;            
            var list = new List<T>();
            for (var i = 0; i < size; i++)
                list.Add( _itemSerializer.ReadFrom(stream));
            return list;
        }

        public void WriteTo(List<T> value, Stream stream)
        {
            if (value == null)
            {
                PrimitiveSerializer.Int32.WriteTo(-1, stream);
                return;
            }
            PrimitiveSerializer.Int32.WriteTo(value.Count, stream);
            foreach (var item in value)
                _itemSerializer.WriteTo(item, stream);
        }
    }
}
