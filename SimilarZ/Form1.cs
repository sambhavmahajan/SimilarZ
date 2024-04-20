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

            HashSet<string> wordsSet1 = new HashSet<string>(words1, StringComparer.OrdinalIgnoreCase);
            HashSet<string> wordsSet2 = new HashSet<string>(words2, StringComparer.OrdinalIgnoreCase);

            wordsSet1.ExceptWith(genericWords);
            wordsSet2.ExceptWith(genericWords);

            int similarity = 0;

            foreach (var word in wordsSet1)
            {
                if (wordsSet2.Contains(word))
                {
                    int count1 = CountConsecutiveOccurrences(words1, word);
                    int count2 = CountConsecutiveOccurrences(words2, word);

                    if (count1 >= 3 || count2 >= 3)
                    {
                        similarity += Math.Max(count1, count2);
                    }
                    else if (count1 >= 2 || count2 >= 2)
                    {
                        similarity += 2;
                    }
                    else
                    {
                        similarity++;
                    }
                }
            }

            return similarity;
        }

        private int CountConsecutiveOccurrences(string[] words, string target)
        {
            int count = 0;
            for (int i = 0; i < words.Length - 2; i++)
            {
                if (words[i] == target && words[i + 1] == target && words[i + 2] == target)
                {
                    count++;
                    i += 2;
                }
            }
            return count;
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
