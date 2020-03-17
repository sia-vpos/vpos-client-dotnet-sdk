using javax.crypto.spec;
using javax.crypto;
using System;
using System.Collections.Generic;
using System.Text;
using javax.xml.bind;
using System.Security.Cryptography;

namespace VPOS_Library.Utils
{
    public class AESEncoder
    {
        public static String Encode3DSData(String apiSecretMerchant, String jsonObject)
        {
            // Initialization vector
            byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            // AES Key from the API merchant key
            byte[] key = Encoding.UTF8.GetBytes(apiSecretMerchant.Substring(0, 16));
            IvParameterSpec ivParameterSpec = new IvParameterSpec(iv);
            SecretKeySpec secretKeySpec = new SecretKeySpec(key, "AES");

            // What we should encrypt
            byte[] toEncrypt = Encoding.UTF8.GetBytes(jsonObject);


            // Encrypt
            AesManaged tdes = new AesManaged();
            tdes.Key = key;
            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.PKCS7;
            tdes.IV = iv;
            ICryptoTransform crypt = tdes.CreateEncryptor();
            byte[] cipher = crypt.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
            var encryptedText = Convert.ToBase64String(cipher);

            
            // Convert to base64
            return encryptedText;
        }
    }
}

