using NBitcoin;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Util;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.HdWallet;
using System;
using Nethereum.Contracts.QueryHandlers.MultiCall;

namespace BeatifulAddress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How do you want your address to begin? Write first symbols of your wanted address (case sensitive)\nWrite without 0x");
            string wanted = Console.ReadLine();

            if (wanted == null || wanted.Length == 0 || wanted.Length > 42)
            {
                return;
            }
            string[] result = GenerateBeautifulAddressFromBeginning("0x" + wanted);
            
            Console.WriteLine("Account found!");
            Console.WriteLine($"Address: {result[0]}");
            Console.WriteLine($"PrivateKey: {result[1]}");
            Console.WriteLine($"Mnemonic: {result[2]}");

        }
        static string[] GenerateBeautifulAddressFromBeginning(string beginning)
        {
            while (true)
            {
                Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);
                string Password = "password";
                var wallet = new Wallet(mnemo.ToString(), Password);
                var account = wallet.GetAccount(0);
                Console.WriteLine("Generating... ");
                Console.WriteLine(account.Address);
                Console.WriteLine(account.Address.Length);
                if (beginning == account.Address.Substring(0, beginning.Length))
                {
                    return [account.Address, account.PrivateKey, mnemo.ToString()];
                }
            }
        }
    }
}