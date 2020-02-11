using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Builder
{
    public static class MessageBuilder
    {
        public static string GenerateMessage(string message, params string[] values)
        {
            for(int i = 0; i < values.Length; i++)
            {
                message = message.Replace(("{" + i + "}"), values[i]);  
            }
            return message;
        }
    }
}
