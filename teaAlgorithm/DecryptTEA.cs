using System;
using System.Collections.Generic;
using System.Text;

namespace teaAlgorithm
{
    public class DecryptTEA
    {
        public byte[] Decrypt(byte[] cipher, uint[] Key)
        {
            byte[] dataBytes = new byte[cipher.Length];
            uint[] tempData = new uint[2];
            for (int i = 0; i < cipher.Length; i += 8)
            {
                tempData[0] = BitConverter.ToUInt32(cipher, i);
                tempData[1] = BitConverter.ToUInt32(cipher, i + 4);
                Decode(tempData, Key);
                Array.Copy(BitConverter.GetBytes(tempData[0]), 0, dataBytes, i, 4);
                Array.Copy(BitConverter.GetBytes(tempData[1]), 0, dataBytes, i + 4, 4);
            }

            // Strip the null char if it was added.
            int index = dataBytes.Length - 1;
            while (dataBytes[index] == 0)
            {
                index--;
            }

            if (index + 1 != dataBytes.Length)
            {
                Array.Resize(ref dataBytes, index + 1);
            }

            return dataBytes;
        }

        private void Decode(uint[] v, uint[] k)
        {
            uint v0 = v[0];
            uint v1 = v[1];
            uint delta = 0x9e3779b9;
            uint sum = delta << 5;

            for (int i = 0; i < 32; i++)
            {
                v1 -= (v0 << 4) + k[2] ^ v0 + sum ^ (v0 >> 5) + k[3];
                v0 -= (v1 << 4) + k[0] ^ v1 + sum ^ (v1 >> 5) + k[1];
                sum -= delta;
            }
            v[0] = v0; v[1] = v1;
        }


    }
}
