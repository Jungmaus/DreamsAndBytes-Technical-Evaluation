using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Security.Abstract
{
    public interface IHash
    {
        string Hash(string text);
    }
}
