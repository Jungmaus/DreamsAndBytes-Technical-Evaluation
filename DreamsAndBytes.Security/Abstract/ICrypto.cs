using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Security.Abstract
{
    public interface ICrypto
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
