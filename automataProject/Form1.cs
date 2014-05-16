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

namespace automataProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] specification = null;
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
            while (specification[line] != "circuit")
            {
                ElecSystemLexical.lineOfTokens = specification[line].Split(' ');
                ElecSystemLexical.automataOne();
                line++;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
