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
using static System.Net.Mime.MediaTypeNames;

namespace SergioHalimTakeHomeAssignmentWeek5
{
    public partial class Form2 : Form
    {
        public int jumlah;
        public MyTextBox[,] textBoxData;
        public string[] datawordle;
        public int position = 0;
        public string randomWord;
        public char[] splitWord;
        public Form2(int jumlah)
        {
            InitializeComponent();
            this.jumlah = jumlah;
            textBoxData = new MyTextBox[jumlah, 5];
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string content = File.ReadAllText(Directory.GetCurrentDirectory() + "/Wordle Word List.txt");
            datawordle = content.Split(',');

            // Membuat instance kelas Random
            Random rand = new Random();

            // Mengambil sebuah string secara random dari array datawordle
            randomWord = datawordle[rand.Next(datawordle.Length)];
            splitWord = randomWord.ToCharArray();

            int y = 100;
            for (int i = 0; i < jumlah; i++)
            {
                int x = 100;
                for (int j = 0; j < 5; j++)
                {
                    textBoxData[i, j] = new MyTextBox("textBox-" + i + "-" + j, 50, 50, x, y);
                    this.Controls.Add(textBoxData[i, j]);
                    x += 55;
                }
                y += 55;
            }
        }

        public class MyTextBox : TextBox
        {
            public MyTextBox(String name, int sizex, int sizey, int posx, int posy)
            {
                // Set some default properties for the button
                this.Text = "";
                this.Multiline = true;
                this.Width = sizex;
                this.Height = sizey;
                this.Name = name;
                this.Location = new Point(posx, posy);
                this.TabStop = false;
                this.TextAlign = HorizontalAlignment.Center;
                this.Font = new Font(Font.FontFamily, 30);
                this.ReadOnly = true;
                this.BackColor = Color.White;
            }
        }

        public void clickButton(object sender, EventArgs e)
        {
            var btn = sender as Button;
            String text = btn.Text;

            if(text == "Enter")
            {
                int trapCocok = 0;
                string checkText = textBoxData[position, 0].Text + textBoxData[position, 1].Text + textBoxData[position, 2].Text + textBoxData[position, 3].Text + textBoxData[position, 4].Text;
                if(Array.IndexOf(datawordle, checkText.ToLower()) != -1)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (textBoxData[position, j].Text.ToLower() == splitWord[j].ToString())
                        {
                            textBoxData[position, j].BackColor = Color.LightGreen;
                            trapCocok++;
                        }
                        else
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                if (textBoxData[position, j].Text.ToLower() == splitWord[j].ToString())
                                {
                                    textBoxData[position, j].BackColor = Color.LightYellow;
                                }
                            }
                        }
                    }

                    if(trapCocok == 5)
                    {
                        MessageBox.Show("Berhasil");
                    }

                    position = position + 1;
                }
                else
                {
                    MessageBox.Show(checkText + " is not on the Word List");
                }
            }
            else if(text == "Delete")
            {
                bool trap = true;
                for (int j = 0; j < 5; j++)
                {
                    if (textBoxData[position, j].Text == "")
                    {
                        if(j > 0)
                        {
                            textBoxData[position, j - 1].Text = "";
                            trap = false;
                        }
                    }
                }
                if (trap)
                {
                    textBoxData[position, 4].Text = "";
                }
            }
            else
            {
                if (position < jumlah)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (textBoxData[position, j].Text == "")
                        {
                            textBoxData[position, j].Text = text; break;
                        }
                    }
                }
            }
        }
    }
}
