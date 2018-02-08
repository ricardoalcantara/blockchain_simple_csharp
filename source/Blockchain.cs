using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace source
{
    public class Blockchain
    {
        List<Block> _blocks;
        private readonly int _difficulty;

        public List<Block> Blocks
        {
            get
            {
                return _blocks;
            }
        }

        public Blockchain(int difficulty = 1)
        {
            _blocks = new List<Block> { new Block(0, null, "First Block") };
            _difficulty = difficulty;
        }

        public Block GetLastBlock()
        {
            return _blocks.Last();
        }

        public void AddBlock(string data)
        {
            var previousHash = _blocks.Last().Hash;

            var block = new Block(_blocks.Count, previousHash, data, _difficulty);

            _blocks.Add(block);
        }

        public bool IsValid()
        {
            for (var i = 1; i < _blocks.Count; i++)
            {
                var currentBlock = _blocks[i];
                var previousBlock = _blocks[i - 1];

                if (currentBlock.Hash != currentBlock.GenerateHash())
                {
                    return false;
                }

                if (currentBlock.Index != previousBlock.Index + 1)
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}