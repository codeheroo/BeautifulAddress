using NBitcoin;
using Nethereum.HdWallet;


namespace BeatifulAddress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to generate your address that begins or ends with specific symbols?");
            Console.WriteLine("1) I want it to begin with specific symbols");
            Console.WriteLine("2) I want it to end with specific symbols");
            Console.WriteLine("3) I want it to begin and end with specific symbols");
            Console.WriteLine("Write 1 or 2 or 3 to choose");
            string choice = Console.ReadLine();
            if (choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("You've written something else");
                return;
            }
            switch (choice)
            {
                case "1":
                    Console.WriteLine("How do you want your address to begin? Write first symbols of your wanted address (case sensitive)");
                    Console.WriteLine("Write without 0x");
                    string beginning= Console.ReadLine();
                    if (beginning == null || beginning.Length == 0 || beginning.Length > 42)
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    string[] result1 = GenerateBeautifulAccountFromTheBeginning("0x" + beginning);
                    Console.WriteLine("Account found!");
                    Console.WriteLine($"Address: {result1[0]}");
                    Console.WriteLine($"PrivateKey: {result1[1]}");
                    Console.WriteLine($"Mnemonic: {result1[2]}");
                    Console.ReadLine();

                    break;
                case "2":
                    Console.WriteLine("How do you want your address to end? Write last symbols of your wanted address (case sensitive)");
                    string ending = Console.ReadLine();
                    if (ending == null || ending.Length == 0 || ending.Length > 42)
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    string[] result2 = GenerateBeautifulAccountFromTheEnding(ending);
                    Console.WriteLine("Account found!");
                    Console.WriteLine($"Address: {result2[0]}");
                    Console.WriteLine($"PrivateKey: {result2[1]}");
                    Console.WriteLine($"Mnemonic: {result2[2]}");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("How do you want your address to begin? Write first symbols of your wanted address (case sensitive)");
                    Console.WriteLine("Write without 0x");
                    string beginning3 = Console.ReadLine();
                    if (beginning3 == null || beginning3.Length == 0 || beginning3.Length > 42)
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    Console.WriteLine("How do you want your address to end? Write last symbols of your wanted address (case sensitive)");
                    string ending3 = Console.ReadLine();
                    if (ending3 == null || ending3.Length == 0 || ending3.Length > 42)
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    string[] result3 = GenerateBeautifulAccountFromTheBeginningAndEnding("0x" + beginning3, ending3);
                    Console.WriteLine("Account found!");
                    Console.WriteLine($"Address: {result3[0]}");
                    Console.WriteLine($"PrivateKey: {result3[1]}");
                    Console.WriteLine($"Mnemonic: {result3[2]}");
                    Console.ReadLine();
                    break;
            }
            

        }
        
        static string[] GenerateBeautifulAccountFromTheBeginning(string beginning)
        {
            while (true)
            {
                Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);
                string Password = "password";
                var wallet = new Wallet(mnemo.ToString(), Password);
                var account = wallet.GetAccount(0);
                Console.WriteLine("Generating... ");
                Console.WriteLine(account.Address);

                if (beginning == account.Address.Substring(0, beginning.Length))
                {
                    return [account.Address, account.PrivateKey, mnemo.ToString()];
                }
            }
        }
        static string[] GenerateBeautifulAccountFromTheEnding(string ending)
        {
            while (true)
            {
                Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);
                string Password = "password";
                var wallet = new Wallet(mnemo.ToString(), Password);
                var account = wallet.GetAccount(0);
                Console.WriteLine("Generating... ");
                Console.WriteLine(account.Address);

                if (ending == account.Address.Substring(42 - ending.Length, ending.Length))
                {
                    return [account.Address, account.PrivateKey, mnemo.ToString()];
                }
            }
        }
        static string[] GenerateBeautifulAccountFromTheBeginningAndEnding(string beginning, string ending)
        {
            while (true)
            {
                Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);
                string Password = "password";
                var wallet = new Wallet(mnemo.ToString(), Password);
                var account = wallet.GetAccount(0);
                Console.WriteLine("Generating... ");
                Console.WriteLine(account.Address);

                if ((beginning == account.Address.Substring(0, beginning.Length)) && (ending == account.Address.Substring(42 - ending.Length, ending.Length)))
                {
                    return [account.Address, account.PrivateKey, mnemo.ToString()];
                }
            }
        }
    }
}
