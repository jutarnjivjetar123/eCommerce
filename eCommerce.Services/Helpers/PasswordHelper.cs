using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Helpers
{
    public class PasswordHelper
    {

        public static string GenerateSalt()
        {
            // Use RNGCryptoServiceProvider or RandomNumberGenerator for generating random bytes
            using var rng = RandomNumberGenerator.Create();
            var byteArray = new byte[16];
            rng.GetBytes(byteArray);

            // Convert the byte array to a Base64 string for use as a salt
            return Convert.ToBase64String(byteArray);
        }


        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(buffer: dst);
            return Convert.ToBase64String(inArray);

        }
    }
}
