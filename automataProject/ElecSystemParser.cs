using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automataProject
{
    public class ElecSystemParser
    {
        public static bool done;

        public static bool trys(string state, int count, int x, Stack<string> stack)
        {
            try
            {
                Stack<string> s;
                if (state == "q0")
                {
                    stack.Push("Z");
                    stack.Push("E");
                    trys("q1", count, x, stack);
                }
                else if (state == "q1")
                {
                    if (x < ElecSystemLexical.lineOfTokens.Length)
                    {
                        switch (stack.Peek())
                        {
                            case "E":
                                {
                                    stack.Pop();
                                    stack.Push("T");
                                    s = new Stack<string>(stack);
                                    trys(state, count, x, stack);
                                    stack = new Stack<string>(s);
                                    if ((!done) && (count <= ElecSystemLexical.lineOfTokens.Length / 3 + 1))
                                    {
                                        stack.Pop();
                                        stack.Push("T"); stack.Push("ser"); stack.Push("E");
                                        count++;
                                        trys(state, count, x, stack);

                                    }
                                    break;
                                }
                            case "T":
                                {
                                    stack.Pop();
                                    stack.Push("U");
                                    s = new Stack<string>(stack);
                                    trys(state, count, x, stack);
                                    stack = new Stack<string>(s);
                                    if ((!done) && (count <= (ElecSystemLexical.lineOfTokens.Length / 3) + 1))
                                    {
                                        stack.Pop();
                                        stack.Push("U"); stack.Push("par"); stack.Push("T");
                                        count++;
                                        s = new Stack<string>(stack);
                                        trys(state, count, x, stack);
                                        stack = new Stack<string>(s);
                                        if (!done)
                                        {
                                            stack.Pop(); stack.Pop(); stack.Pop();
                                        }
                                    }
                                    break;
                                }
                            case "U":
                                {
                                    stack.Pop();
                                    stack.Push("id");
                                    s = new Stack<string>(stack);
                                    trys(state, count, x, stack);
                                    stack = new Stack<string>(s);                                    
                                    if (!done)
                                    {
                                        stack.Pop();
                                        stack.Push(")"); stack.Push("E"); stack.Push("(");
                                        s = new Stack<string>(stack);
                                        trys(state, count, x, stack);
                                        stack = new Stack<string>(s);
                                        if (!done)
                                        {
                                            stack.Pop(); stack.Pop(); stack.Pop();
                                        }
                                    }
                                    break;
                                }
                            case "ser":
                                {
                                    ElecSystemLexical.i = x;
                                    if (ElecSystemLexical.currentToken().TS)
                                    {
                                        stack.Pop();
                                        x = x + 1;
                                        trys(state, count, x, stack);
                                        trys(state, count, x, stack);
                                    }
                                    break;
                                }
                            case "par":
                                {
                                    ElecSystemLexical.i = x;
                                    if (ElecSystemLexical.currentToken().TP)
                                    {
                                        stack.Pop();
                                        x = x + 1;
                                        trys(state, count, x, stack);
                                    }
                                    break;
                                }
                            case "id":
                                {
                                    ElecSystemLexical.i = x;
                                    if (ElecSystemLexical.currentToken().R && ElecSystemLexical.resistances.ContainsKey( ElecSystemLexical.imageToken() ))
                                    {
                                        stack.Pop();
                                        x = x + 1;
                                        trys(state, count, x, stack);
                                    }
                                    break;
                                }
                            case "(":
                                {
                                    ElecSystemLexical.i = x;
                                    if (ElecSystemLexical.currentToken().openBracket)
                                    {
                                        stack.Pop();
                                        count++;
                                        x = x + 1;
                                        trys(state, count, x, stack);
                                    }
                                    break;
                                }
                            case ")":
                                {
                                    ElecSystemLexical.i = x;
                                    if (ElecSystemLexical.currentToken().closeBracket)
                                    {
                                        stack.Pop();
                                        count++;
                                        x = x + 1;
                                        trys(state, count, x, stack);
                                    }
                                    break;
                                }
                        }

                    }
                    else
                    {
                        trys("q2", count, x, stack);
                    }
                }
                else
                {
                    if (stack.Peek() == "Z")
                    {
                        done = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return true;
        }

    }
}
