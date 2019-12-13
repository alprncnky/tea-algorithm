using System;
using System.Text;

namespace teaAlgorithm
{
    class Program
    {

        public static void Encrpyt()
        {
            Console.WriteLine("");
            Console.WriteLine("-Encrpyt Inputs-");
            Console.Write("Enter Key:");
            string key = Console.ReadLine();
            Console.Write("Enter value:");
            string text = Console.ReadLine();

            TeaHandler teaHandler = new TeaHandler();
            var _cipher = teaHandler.Encrypt(text, key);
            Console.WriteLine("Encrypted Value:" + _cipher);
        }

        public static void Decrypt()
        {
            Console.WriteLine("");
            Console.WriteLine("-Decrpyt Inputs-");
            Console.Write("Enter key:");
            string keyDecrypte = Console.ReadLine();
            Console.Write("Enter value:");
            string cipher = Console.ReadLine();
            TeaHandler teaHandler = new TeaHandler();
            Console.WriteLine("Decrypted Value:"+ teaHandler.Decrypt(cipher, keyDecrypte));
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--- TEA Algorithm ---");
                Console.WriteLine("1-) Encrypt");
                Console.WriteLine("2-) Decrypt");
                Console.WriteLine("3-) Clear Console");
                Console.WriteLine("4-) Exit");
                Console.Write("Select Number:");
                var selected_number = Console.ReadLine();
                var number = Convert.ToInt32(selected_number);
                if (number == 1)
                {
                    Encrpyt();
                }
                else if (number == 2)
                {
                    Decrypt();
                }
                else if (number == 3)
                {
                    Console.Clear();
                }
                else if (number == 4)
                {
                    Console.WriteLine("Exit");
                    return;
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Press any key to return menu");
                Console.ReadKey();
            }
        }
    }
}
