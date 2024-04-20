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
        private HashSet<string> genericWords = new HashSet<string>
        {
            "a", "an", "and", "as", "at", "be", "by", "for", "from", "has", "have",
            "he", "her", "him", "his", "in", "is", "it", "its", "of", "on", "or",
            "that", "the", "their", "there", "they", "this", "to", "was", "were",
            "which", "with", "you"
        };

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


        private int CalculateConsecutiveSimilarity(string s1, string s2)
        {
            string[] separators = { " ", ",", ".", "?", "!", ";" };
            string[] words1 = s1.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] words2 = s2.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> nonGenericWordsSet1 = new HashSet<string>(words1.Select(w => w.ToLower()).Except(genericWords), StringComparer.OrdinalIgnoreCase);
            HashSet<string> nonGenericWordsSet2 = new HashSet<string>(words2.Select(w => w.ToLower()).Except(genericWords), StringComparer.OrdinalIgnoreCase);

            int res = 0;
            int currentConsecutiveSimilarity = 0;

            for (int i = 0; i < words1.Length; i++)
            {
                if (nonGenericWordsSet1.Contains(words1[i]) && nonGenericWordsSet2.Contains(words1[i]))
                {
                    currentConsecutiveSimilarity++;
                }
                else
                {
                    if (currentConsecutiveSimilarity > 2) res += currentConsecutiveSimilarity;
                    currentConsecutiveSimilarity = 0;
                }
            }

            return res;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = richTextBox1.Text.ToLower();
            string s2 = richTextBox2.Text.ToLower();

            int res = CalculateConsecutiveSimilarity(s1, s2);

            double similarityPercentage = (double)res / (s1.Split(' ').Length) * 100;

            progressBar1.Value = (int)similarityPercentage;
            label1.Text = $"{similarityPercentage:F2}%";
        }
    }
}
