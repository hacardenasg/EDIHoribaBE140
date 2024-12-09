using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HoribaBE140AD.EmulatorApp
{
    public class FactoryActivator
    {
        private string key1 = "ZgE58PtZB8c6d9M4ksyrfeRs2kywxrWN6xh28FmKtgev8A9mzzLdFYm7kNHww8AehsnvwwQRFkZs8J2SCYy54ABTx44qp68L3GxBmrkUsLnep2tPdDpPp2QUpfxbJ8Lnhv8FSJ9UAxDSsNRhLEa9VcH8Fe9TRdjgPfkUeTWa23HKXP29SGyXqy5EjsUY46XN3vQpTR89mgrR7KMFneR287SymXwCeNKehydj2uKkUKawkkrUP9VNRj3emnt4nmgA";
        private string key2 = "9ZJmUM5gaTt7yYFe8Bc9KdVFKP44g75faCBYTJQKwcyJRrPX9mMxfxS929gYabNDzuB64j5djwJqmJr72JFysPUqMbtxjTmUmjDcmGBSaQaDuvzZuBNPf7e2Lfcd9zCKNsGmAGCMJ8cUt2bQY9cH5NEKT5cGfYYNSFtcxQZ4KS2LWbz9P9HDdru9YFNyxghACq9RZVjRFYmsdWzbbPxnpepp5F2pSp2LP29mxe6PmT5hqDaapMkN5YFMCNnX9xar";

        public string GenerateRequestCode()
        {
            string dateForCode = DateTime.Now.ToString("yyyyMMddHHmmss");
            string guidCode = Guid.NewGuid().ToString();

            string codeFinal = Crypto.Encrypt(guidCode + dateForCode, key1);
            int counter = 0;
            string result = "";

            foreach (var item in codeFinal)
            {
                if ((char.IsLetterOrDigit(item) == true) && (char.IsPunctuation(item) == false) && (char.IsSymbol(item) == false)
                    && (item != '0') && (item != 'O') && (item != 'o') && (item != 'l') && (item != 'I'))
                {
                    counter += 1;
                    result += item;
                }
                if (counter == 8)
                {
                    break;
                }
            }

            return result;
        }

        public Boolean AuthorizeCode(string requestCode, string authorizationCode)
        {
            string code = GenerateAuthorizationCode(requestCode);
            Debug.Print(code);
            return authorizationCode == code;
        }

        private string GenerateAuthorizationCode(string code)
        {
            string codeNew = Crypto.Encrypt(code, key2);
            string codeFinal = Crypto.Encrypt(codeNew, key1);

            int counter = 0;
            string result = "";

            foreach (var item in codeFinal)
            {
                if ((char.IsLetterOrDigit(item) == true) && (char.IsPunctuation(item) == false) && (char.IsSymbol(item) == false)
                    && (item != '0') && (item != 'O') && (item != 'o') && (item != 'l') && (item != 'I'))
                {
                    counter += 1;
                    result += item;
                }
                if (counter == 8)
                {
                    break;
                }
            }

            return result;
        }
    }
}
