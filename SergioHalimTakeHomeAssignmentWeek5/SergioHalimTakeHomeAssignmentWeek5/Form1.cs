using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SergioHalimTakeHomeAssignmentWeek5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!File.Exists(Directory.GetCurrentDirectory() + "/Wordle Word List.txt"))
            {
                MessageBox.Show("Data Wordle tidak ditemukan.");
            }
            else
            {
                bool trap = false;
                try
                {
                    int nomor = int.Parse(textBoxHowMuchGuess.Text);
                    if (nomor >= 3)
                    {
                        trap = true;
                    }
                    else
                    {
                        MessageBox.Show("Number harus lebih dari sama dengan 3.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Inputan harus number.");
                }

                if (trap)
                {
                    Form2 form2 = new Form2(int.Parse(textBoxHowMuchGuess.Text));
                    form2.ShowDialog();
                }
            }
        }
    }
}
