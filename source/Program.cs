using System;

namespace source
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" - Creating the blockchain");
            var blockchain = new Blockchain(7);
            Func<object, string> serialize = Newtonsoft.Json.JsonConvert.SerializeObject;
            Func<string, dynamic> deserialize = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>;


            Console.WriteLine(" - Filling the blockchain");
            var rnd = new Random();
            int i = 10;
            // for (i = 0; i < 1000000; i++)
            // {
            blockchain.AddBlock(serialize(new { amount = rnd.Next(i) }));
            blockchain.AddBlock(serialize(new { amount = i + rnd.Next(i) }));
            // }

            Console.WriteLine(" - Validating");
            Console.WriteLine($"IsValid: {blockchain.IsValid()}"); // true

            // Console.WriteLine("Messing it");
            // blockchain.GetLastBlock().Data = serialize(new { amount = 200 });

            Console.WriteLine(" - Validating");
            Console.WriteLine($"IsValid: {blockchain.IsValid()}"); // false

            foreach (var block in blockchain.Blocks)
            {
                Console.WriteLine($"{block.Index} - {block.Hash}");
            }
        }
    }
}
