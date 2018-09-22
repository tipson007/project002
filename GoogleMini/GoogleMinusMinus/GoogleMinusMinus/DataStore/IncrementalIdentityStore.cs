using System;
using System.IO;
using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;

namespace GoogleMini.DataStore
{
    public class IncrementalIdentityStore : IDisposable
    {
        private BPlusTree<string, int> identityStore;

        public IncrementalIdentityStore(string databaseDirectory)
        {
            identityStore = new BPlusTree<string, int>(
                new BPlusTree<string, int>.OptionsV2(PrimitiveSerializer.String, VariantNumberSerializer.Int32)
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    FileName = Path.Combine(databaseDirectory, "indexDbIdentities.b+tree")
                }.CalcBTreeOrder(100, 4)
            );
        }

        public void Dispose()
        {
            ((IDisposable)identityStore).Dispose();
        }

        public int GetNext(string key)
        {
            if (key.Length > 50)
                throw new ArgumentException($"{nameof(key)} can't be more than 50 characters");
            return identityStore.GetOrAdd(key, 1);
        }        

        internal void SetNext(string key, int value)
        {
            if (key.Length > 50)
                throw new ArgumentException($"{nameof(key)} can't be more than 50 characters");
            identityStore[key] = value;
        }
    }
}
