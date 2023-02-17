using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Translator
    {
        private Dictionary<char, string> rusEngPairs;

        public Translator()
        {
            rusEngPairs = new Dictionary<char, string>()
        {
            {'�',"a" },
            {'�',"b" },
            {'�',"v" },
            {'�',"g" },
            {'�',"d" },
            {'�',"e" },
            {'�',"yo" },
            {'�',"j" },
            {'�',"z" },
            {'�',"i" },
            {'�',"i'" },
            {'�',"k" },
            {'�',"l" },
            {'�',"m" },
            {'�',"n" },
            {'�',"o" },
            {'�',"p" },
            {'�',"r" },
            {'�',"s" },
            {'�',"t" },
            {'�',"y" },
            {'�',"f" },
            {'�',"h" },
            {'�',"c" },
            {'�',"ch" },
            {'�',"sh" },
            {'�',"sh'" },
            {'�',"'" },
            {'�',"u" },
            {'�',"'" },
            {'�',"e" },
            {'�',"yu" },
            {'�',"ya" },
        };
        }

        public string ToEnglish(string agentName)
        {
            var sb = new StringBuilder();
            agentName = agentName.ToLower();
            foreach (var ch in agentName)
            {
                if (char.IsLetter(ch))
                {
                    if (rusEngPairs.ContainsKey(ch))
                        sb.Append(rusEngPairs[ch]);
                    else
                        sb.Append(ch);
                }
                else if (!char.IsWhiteSpace(ch))
                    sb.Append(ch);
            }
            return sb.ToString();
        }
    }
}