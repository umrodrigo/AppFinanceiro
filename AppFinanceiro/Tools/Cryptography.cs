using System.Security.Cryptography;
using System.Text;

namespace Financ.Api.Tools
{
    public static class Cryptography
    {
        public static string EncryptMD5(string value)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(value);
            return ByteToString(md5.ComputeHash(inputBytes));
        }

        public static string Sha256(string value)
        {
            using SHA256 sha256 = SHA256.Create();
            sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
            return ByteToString(sha256.Hash);
        }

        public static string ByteToString(byte[] buff)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < buff.Length; i++)
            {
                sb.Append(buff[i].ToString("X2"));
            }
            return sb.ToString().ToLowerInvariant();
        }

    }
}
