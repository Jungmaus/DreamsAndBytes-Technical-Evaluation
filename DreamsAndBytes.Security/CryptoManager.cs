using DreamsAndBytes.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Security
{
    public class CryptoManager : ICrypto
    {
        private ICrypto _crypto;

        public CryptoManager(ICrypto crypto)
        {
            this._crypto = crypto;
        }

        public string Decrypt(string text) => this._crypto.Decrypt(text);

        public string Encrypt(string text) => this._crypto.Encrypt(text);
    }
}
