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

        private Dictionary<string, List<int>> MapIndicesToWords(string[] words)
        {
            Dictionary<string, List<int>> indexMap = new Dictionary<string, List<int>>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();
                if (!indexMap.ContainsKey(word))
                {
                    indexMap[word] = new List<int>();
                }
                indexMap[word].Add(i);
            }
            return indexMap;
        }

        public int CalculateConsecutiveSimilarity(string s1, string s2)
        {
            string[] separators = { " ", ",", ".", "?", "!", ";" };
            string[] words1 = s1.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] words2 = s2.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<int>> wordIndicesMap1 = MapIndicesToWords(words1);
            Dictionary<string, List<int>> wordIndicesMap2 = MapIndicesToWords(words2);

            int res = 0;
            int currentConsecutiveSimilarity = 0;

            foreach (var word in wordIndicesMap1.Keys)
            {
                if (wordIndicesMap2.ContainsKey(word))
                {
                    List<int> indices1 = wordIndicesMap1[word];
                    List<int> indices2 = wordIndicesMap2[word];

                    int index1Index = 0;
                    int index2Index = 0;
                    while (index1Index < indices1.Count && index2Index < indices2.Count)
                    {
                        int index1 = indices1[index1Index];
                        int index2 = indices2[index2Index];

                        if (index2 - index1 == index2Index - index1Index)
                        {
                            currentConsecutiveSimilarity++;
                        }
                        else
                        {
                            if (currentConsecutiveSimilarity >= 2)
                            {
                                res += currentConsecutiveSimilarity;
                            }
                            currentConsecutiveSimilarity = 0;
                        }

                        index1Index++;
                        index2Index++;
                    }
                }
            }

            if (currentConsecutiveSimilarity >= 2)
            {
                res += currentConsecutiveSimilarity;
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
