using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SimilarZ
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        public int CalculateConsecutiveSimilarity(string s1, string s2)
        {
            int res = 0;
            string[] separators = { " ", ",", ".", "?", "!", ";" };
            string[] words1 = s1.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] words2 = s2.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            for (int i = 0; i < words1.Length; i++)
            {
                int j = 0;
                while (j < words2.Length)
                {
                    if (words1[i] == words2[j])
                    {
                        int tempJ = j;
                        while (i < words1.Length && tempJ < words2.Length && words1[i] == words2[tempJ])
                        {
                            count++;
                            i++;
                            tempJ++;
                        }
                        if (count >= 3)
                        {
                            res += count;
                        }
                        count = 0;
                    }
                    j++;
                }
            }

            return res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = richTextBox1.Text.ToLower();
            string s2 = richTextBox2.Text.ToLower();

            int res = CalculateConsecutiveSimilarity(s1, s2);

            double similarityPercentage = ((double)res) / (s1.Split(' ').Length) * 100;
 
            progressBar1.Value = (int)similarityPercentage;
            label1.Text = $"{similarityPercentage:F2}%";
        }
    }
}
