using System;
using System.Collections.Generic;
using System.Text;

namespace teaAlgorithm
{
    public class TeaHandler
    {
        private uint ConvertStringToUInt(string Input)
        {
            uint output;
            output = ((uint)Input[0]);
            output += ((uint)Input[1] << 8);
            output += ((uint)Input[2] << 16);
            output += ((uint)Input[3] << 24);
            return output;
        }

        public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

        public uint[] ReturnKeyUint(string _key)
        {
            string keyfor = "";
            for(int i=0; i<16; i++)
            {
                if (_key.Length > i)
                {
                    keyfor += _key[i];
                }
                else
                {
                    keyfor += "0";
                }
            }
            uint[] key = new uint[4];
            key[0] = ConvertStringToUInt(keyfor.Substring(0,4));
            key[1] = ConvertStringToUInt(keyfor.Substring(4, 4));
            key[2] = ConvertStringToUInt(keyfor.Substring(8, 4));
            key[3] = ConvertStringToUInt(keyfor.Substring(12, 4));
            return key;
        }

        public string Encrypt(string text, string key)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            EncryptTEA encryptTEA = new EncryptTEA();
            var cipherByteArray = encryptTEA.Encrypt(bytes, ReturnKeyUint(key));
            string hex = ConvertStringToHex(Encoding.Unicode.GetString(cipherByteArray), System.Text.Encoding.Unicode);
            return hex;
        }

        public string Decrypt(string cipher, string key)
        {
            DecryptTEA decryptTEA = new DecryptTEA();
            string normal = ConvertHexToString(cipher, System.Text.Encoding.Unicode);
            var textByteArray = decryptTEA.Decrypt(Encoding.Unicode.GetBytes(normal), ReturnKeyUint(key));
            byte[] texts = new byte[textByteArray.Length + 1];
            for(int i=0; i<textByteArray.Length; i++)
            {
                texts[i] = textByteArray[i];
            }
            return Encoding.Unicode.GetString(texts);
        }
    }
}
