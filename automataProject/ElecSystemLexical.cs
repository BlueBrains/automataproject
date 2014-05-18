using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automataProject
{
    class ElecSystemLexical
    {
        public static string[] lineOfTokens;
        public static int i = -1;        
        public static Dictionary<string, double> resistances = new Dictionary<string,double>();
        public static HashSet<string> Tokens = new HashSet<string>();

        public static void automataOne()
        {
            string temp = "";
            int state = 0;
            while (lineOfTokens.Length > i + 1)            
            {
                nextToken();
                if (currentToken().R && state == 0)
                {
                    state++;
                    Tokens.Add(imageToken());
                    temp = imageToken();
                }
                else if (currentToken().V && state == 1)
                {
                    if (imageToken().Contains("e-"))
                    {
                        double num = double.Parse(imageToken().Substring(0, imageToken().IndexOf("e")));
                        double E = double.Parse(imageToken().Substring(imageToken().IndexOf("-") + 1, imageToken().Length - (imageToken().IndexOf("-") + 1)));
                        resistances.Add(temp, num * Math.Pow(10, -E));
                    }
                    else if (imageToken().Contains("e"))
                    {
                        double num = double.Parse(imageToken().Substring(0, imageToken().IndexOf("e")));
                        double E = double.Parse(imageToken().Substring(imageToken().IndexOf("e") + 1, imageToken().Length - (imageToken().IndexOf("e") + 1)));
                        resistances.Add(temp, num * Math.Pow(10, E));
                    }
                    else
                        resistances.Add(temp, double.Parse(imageToken()));
                }
                else
                    throw new OutOfAutomataOne();
            }
            i = -1;
        }
        public static void nextToken() 
        {            
            i++;
        }
        
        public static Token currentToken() 
        {
            if (imageToken() == "ser" )
                return new Token(false, false, false, false, true, false);
            else if ( imageToken() == "par")
                return new Token(false, false, false, false, false, true);
            else if(imageToken() == "(")
                return new Token(false, false, true, false, false, false);
            else if (imageToken() == ")")
                return new Token(false, false, false, true, false, false);
            else if(Char.IsLetter(imageToken()[0]))
                return new Token(true, false, false, false, false, false);
            else if(Char.IsDigit(imageToken()[0]))
            {
                int q = 1;
                for (int i = 1; i < imageToken().Length; i++) {
                    if (Char.IsDigit(imageToken()[i]) && q == 1)
                        continue;
                    else if (imageToken()[i] == 'e' && q == 1)
                        q++;
                    else if (imageToken()[i] == '-' && q == 2)
                        q++;
                    else if (Char.IsDigit(imageToken()[i]) && (q == 2 || q == 3))
                        q++;
                    else if (Char.IsDigit(imageToken()[i]) && q == 4)
                        continue;
                    else
                        throw new OutOfLanguageTokens();
                }
                    return new Token(false, true, false, false, false, false);
            }
            else
                throw new OutOfLanguageTokens();                
        }
        
        public static string imageToken() 
        {
            return lineOfTokens[i];
        }
    }

    public struct Token {

        public bool R , V , openBracket , closeBracket , TS, TP;

        public Token (bool R,bool V,bool openBracket, bool closeBracket, bool TS, bool TP)
        {
            this.R = R;
            this.V = V;
            this.openBracket = openBracket;
            this.closeBracket = closeBracket;
            this.TS = TS;
            this.TP = TP;
        }
        
    }

    public class OutOfLanguageTokens : Exception
    {
        public OutOfLanguageTokens()
            : base("this token doesn't exist in our language !")
        {
        }
    }

    public class OutOfAutomataOne : Exception
    {
        public OutOfAutomataOne()
            : base("this input is not a circuit specification !")
        {
        }
    }

}
