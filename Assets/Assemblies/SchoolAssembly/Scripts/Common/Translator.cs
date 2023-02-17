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
            {'à',"a" },
            {'á',"b" },
            {'â',"v" },
            {'ã',"g" },
            {'ä',"d" },
            {'å',"e" },
            {'¸',"yo" },
            {'æ',"j" },
            {'ç',"z" },
            {'è',"i" },
            {'é',"i'" },
            {'ê',"k" },
            {'ë',"l" },
            {'ì',"m" },
            {'í',"n" },
            {'î',"o" },
            {'ï',"p" },
            {'ð',"r" },
            {'ñ',"s" },
            {'ò',"t" },
            {'ó',"y" },
            {'ô',"f" },
            {'õ',"h" },
            {'ö',"c" },
            {'÷',"ch" },
            {'ø',"sh" },
            {'ù',"sh'" },
            {'ú',"'" },
            {'û',"u" },
            {'ü',"'" },
            {'ý',"e" },
            {'þ',"yu" },
            {'ÿ',"ya" },
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