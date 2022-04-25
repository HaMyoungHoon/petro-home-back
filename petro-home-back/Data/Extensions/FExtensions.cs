namespace petro_home_back.Data.Extensions
{
    public static class FExtensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(x => (T)x.Clone()).ToList();
        }
    }
    public static class FConverter
    {
        public static string HexByteToHexStr(byte[] data)
        {
            string temp = "";
            for (int i = 0; i < data.Length; i++)
            {
                temp += data[i].ToString("X2");
            }
            return temp;
        }

        public static byte[] HexStrToByte(string data)
        {
            byte[] ret = Array.Empty<byte>();
            while (true)
            {
                int resize = 2;
                int dataLength = 4;
                if (dataLength > data.Length)
                {
                    dataLength = data.Length;
                    if (dataLength == 2 || dataLength == 1)
                    {
                        resize -= 1;
                    }
                }

                string twoDv = data[..dataLength];
                if (twoDv.Length == 0)
                {
                    break;
                }
                data = data.Remove(0, dataLength);
                uint dvbufInt = uint.Parse(twoDv, System.Globalization.NumberStyles.AllowHexSpecifier);
                byte[] dvbufByte = BitConverter.GetBytes(dvbufInt);
                Array.Resize(ref dvbufByte, resize);
                Array.Reverse(dvbufByte);
                ret = ret.Concat(dvbufByte).ToArray();
            }
            return ret;
        }
    }
}
