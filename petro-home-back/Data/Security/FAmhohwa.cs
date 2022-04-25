using petro_home_back.Data.Extensions;
using System.Security.Cryptography;
using System.Text;

namespace petro_home_back.Data.Security
{
    public static class FAmhohwa
    {
    }

    public class FAES128
    {
        public static string Encrypt(string data, string key = "비밀키 지우기")
        {
            while (key.Length < 16)
            {
                key += "0";
            }
            while (key.Length > 16)
            {
                key = key[..16];
            }
            if (data.Length <= 0)
            {
                data = " ";
            }

            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            byte[] dataArray = Encoding.UTF8.GetBytes(data);

            using var algo = Aes.Create();
            algo.Mode = CipherMode.ECB;
            algo.Padding = PaddingMode.PKCS7;
            algo.Key = keyArray;

            ICryptoTransform trans = algo.CreateEncryptor();
            byte[] ret = trans.TransformFinalBlock(dataArray, 0, dataArray.Length);

            return FConverter.HexByteToHexStr(ret);
        }
        public static string Decrypt(string data, string key = "비밀키 지우기")
        {
            while (key.Length < 16)
            {
                key += "0";
            }
            while (key.Length > 16)
            {
                key = key[..16];
            }
            if (data.Length <= 0)
            {
                return data;
            }

            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            byte[] dataArray = FConverter.HexStrToByte(data);

            using var algo = Aes.Create();
            algo.Mode = CipherMode.ECB;
            algo.Padding = PaddingMode.PKCS7;
            algo.Key = keyArray;

            ICryptoTransform trans = algo.CreateDecryptor();
            byte[] ret = trans.TransformFinalBlock(dataArray, 0, dataArray.Length);

            return Encoding.UTF8.GetString(ret).Replace("\0", "");
        }
    }
}
