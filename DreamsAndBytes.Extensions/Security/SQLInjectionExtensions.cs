using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DreamsAndBytes.Extensions.Security
{
    // SQL Injection
    public static partial class SecurityExtensions
    {
        public static string ClearData(this string text, DataType type)
        {
            switch (type)
            {
                case DataType.Password:
                    text = text.Replace("'", "");
                    text = text.Replace(" ", "");
                    break;
                default:
                    text = text.Replace("'", "");
                    break;
            }
            return text;
        }        
    }
}
