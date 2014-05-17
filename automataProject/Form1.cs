using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
namespace automataProject
{
    public partial class Form1 : Form
    {
        string[] specification = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (fromFile.Checked) {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar + "testfile.txt";
                if (!File.Exists(filePath))
                {
                    try
                    {
                        throw new FileNotFound();
                    }
                    catch (FileNotFound exc)
                    {
                        MessageBox.Show(exc.Message);

                    }
                    finally
                    {
                        string content =
                            "R1 10" + Environment.NewLine
                            + "R2 12e3" + Environment.NewLine
                            + "R3 123e-12" + Environment.NewLine
                            + "circuit";
                        File.WriteAllText(filePath, content);
                    }

                }
                specification = File.ReadAllLines(filePath);            
            }
            else if (fromTextBox.Checked)
            {
                specification = Specification.Lines;
            }
            
            int line = 0;
            ElecSystemLexical.resistances.Clear();
            try
            {
                while (specification[line] != "circuit")
                {
                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex(@"[ ]{2,}", options);
                    specification[line] = regex.Replace(specification[line], @" ");
                    if (specification[line][specification[line].Length - 1] == ' ')
                        specification[line] = specification[line].Substring(0, specification[line].Length - 1);
                    ElecSystemLexical.lineOfTokens = specification[line].Split(' ');                    
                    ElecSystemLexical.automataOne();
                    line++;
                }
            }
            catch (OutOfAutomataOne exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch (OutOfLanguageTokens exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {            
            string s = specification[specification.Length - 1];
            //s.Replace("(", " ( ");
            //s.Replace(")", " ) ");           
            try
            {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            s = regex.Replace(s, @" ");
            if (s[s.Length-1]==' ')
                s = s.Substring(0,s.Length -1);
            ElecSystemLexical.lineOfTokens = s.Split(' ');
            method();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Please re-enter you electric circuit and be carful to add 'SPACES' at end of each OPRANDS or BRACKETS",
                "Format Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }            
        }
        public void method()
        {
            Stack<String> operation = new Stack<String>();
            Stack<Double> values = new Stack<Double>();
            Stack<Char> brackets = new Stack<Char>();  
            while (ElecSystemLexical.i < ElecSystemLexical.lineOfTokens.Length-1)
	            {
                    ElecSystemLexical.nextToken();
                    if (ElecSystemLexical.currentToken().R)
                    {
                        if ((brackets.Count == 0) && (operation.Count != 0))
                            values.Push(calculate(values.Pop(), ElecSystemLexical.resistances[ElecSystemLexical.imageToken()], operation.Pop()));
                        else
                            values.Push(ElecSystemLexical.resistances[ElecSystemLexical.imageToken()]);
                    }

                        else if (ElecSystemLexical.currentToken().openBracket)
                        {
                            brackets.Push(ElecSystemLexical.imageToken()[0]);
                            operation.Push(ElecSystemLexical.imageToken());
                        }
                        else if (ElecSystemLexical.currentToken().closeBracket)
                        {
                            brackets.Pop();
                            String u = operation.Pop();
                            while (u != "(")
                            {
                                values.Push(calculate(values.Pop(), values.Pop(), u));
                                u = operation.Pop();
                            }
                        }
                        else
                            operation.Push(ElecSystemLexical.imageToken());
                    }


            while (operation.Count != 0)
            {
                values.Push(calculate(values.Pop(), values.Pop(), operation.Pop()));
            }
            ElecSystemLexical.i = -1;
            MessageBox.Show(values.Pop().ToString());
        }

        Double calculate(Double X, Double Y, String op)
        {
            if (op == "ser")
                return X + Y;
            else
                return (X * Y) / (X + Y);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
			string[][] Edges = { new string[] {"q0","q1","?"},
				new string[] {"q1","q1","E"},
				new string[] {"q1","q2","iel,iel/E"},
				new string[] {"q2","f","E,Z/E"},
				new string[] {"q2","q1","E"},
				new string[] {"q1","q3","So???"},
				new string[] {"q3","q1","E"},
				new string[] {"q1","q4","Par,Bar/E"},
				new string[] {"q4","q1","E"},
				new string[] {"q1","q5","C,C/E"},
				new string[] {"q5","q1","E"},
				new string[] {"q1","q6","l,l/E"},
				new string[] {"q6","q1","E"},
				new string[] {"q6","f","E,Z/E"} };
            Graph mygraph = new Graph(Edges);
            Form form2 = new Form();
            form2.Controls.Add(mygraph.viewr);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = specification[specification.Length - 1];
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            s = regex.Replace(s, @" ");
            if (s[s.Length - 1] == ' ')
                s = s.Substring(0, s.Length - 1);
            ElecSystemLexical.lineOfTokens = s.Split(' ');            
            ElecSystemParser.done = false;
            Stack<string> stack = new Stack<string>();
            ElecSystemParser.trys("q0", 0, 0, stack);
            ElecSystemLexical.i = -1;
            MessageBox.Show(ElecSystemParser.done.ToString());
        }
    }
	
    
    public class FileNotFound : Exception
    {
        public FileNotFound()
            : base("there is a new file in your desktop called teslfile , please write your program there ")
        {
        }
    }

}
