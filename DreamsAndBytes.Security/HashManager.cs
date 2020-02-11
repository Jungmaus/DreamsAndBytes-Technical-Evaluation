using DreamsAndBytes.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Security
{
    public class HashManager : IHash
    {
        private IHash _hash;

        public HashManager(IHash hash)
        {
            this._hash = hash;
        }

        public string Hash(string text) => this._hash.Hash(text);
    }
}
