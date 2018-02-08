using System;
using System.Text;

namespace source
{
    public class Block
    {
        public string PreviousHash { get; private set; }
        // public set to break;
        public string Data { get; private set; }

        public double Timestamp { get; private set; }


        public string Hash { get; private set; }
        public int Index { get; private set; }
        private readonly int _difficulty;
        private int _nonce;

        public Block(int index, string previousHash, string data, int difficulty = 1)
        {
            _difficulty = difficulty;
            Index = index;
            PreviousHash = previousHash;
            Data = data;
            Timestamp = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 00)).TotalSeconds;

            _nonce = 0;
            Mine();
        }

        public string GenerateHash()
        {
            string value = Index + PreviousHash + Data + Timestamp + _nonce;
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value), 0, Encoding.UTF8.GetByteCount(value));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        private void Mine()
        {
            Hash = GenerateHash();

            while (!Hash.StartsWith(new String('0', _difficulty)))
            {
                _nonce++;
                Hash = GenerateHash();
            }
        }
    }
}