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


        private int CalculateSimilarity(string s1, string s2)
        {
            string[] words1 = s1.Split(new char[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] words2 = s2.Split(new char[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> nonGenericWordsSet1 = new HashSet<string>(words1.Select(w => w.ToLower()).Except(genericWords), StringComparer.OrdinalIgnoreCase);
            HashSet<string> nonGenericWordsSet2 = new HashSet<string>(words2.Select(w => w.ToLower()).Except(genericWords), StringComparer.OrdinalIgnoreCase);

            int nonGenericSimilarity = nonGenericWordsSet1.Intersect(nonGenericWordsSet2).Count();

            return nonGenericSimilarity;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = richTextBox1.Text.ToLower();
            string s2 = richTextBox2.Text.ToLower();

            int similarity = CalculateSimilarity(s1, s2);
            double similarityPercentage = (double)similarity / (s1.Length + s2.Length) * 100;

            progressBar1.Value = (int)similarityPercentage;
            label1.Text = $"{similarityPercentage:F2}%";
        }
    }
}
