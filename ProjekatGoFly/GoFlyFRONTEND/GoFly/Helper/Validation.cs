using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace GoFly.Helper
{
    class Validation
    {
        public static async void Message(string body, string title)
        {
            var dlg = new MessageDialog(
                    string.Format(body), title);

            try
            {
                await dlg.ShowAsync();
            }
            catch (Exception) { }
        }

        public static String CreateMD5(string input)
        {
            var algorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);
            var hashed = algorithm.HashData(buffer);
            var output = CryptographicBuffer.EncodeToHexString(hashed);

            return output;
        }
    }
}
