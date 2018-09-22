namespace GoogleMini.Util
{
    public class CompoundId
    {            
        public static ulong Combine(int item1, int item2)
        {
            return (ulong)item1 << 32 | (uint)item2;
        }

        public static (int, int) Split(ulong value)
        {
            unchecked
            {
                var item1 = (int)(value >> 32);
                var item2 = (int)(value & 0xFFFFFFFFUL);
                return (item1, item2);
            }            
        }
    }
}
