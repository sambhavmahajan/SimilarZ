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
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }
        private HashSet<string> genericWords = new HashSet<string>
        {
            "a", "an", "and", "as", "at", "be", "by", "for", "from", "has", "have",
            "he", "her", "him", "his", "in", "is", "it", "its", "of", "on", "or",
            "that", "the", "their", "there", "they", "this", "to", "was", "were",
            "which", "with", "you"
        };
        private int similar(string x, string Y)
        {
            int res = 0;
            string s1 = richTextBox1.Text.ToString();
            string s2 = richTextBox2.Text.ToString();
            HashSet<string> words = new HashSet<string>();
            string[] words1 = s1.Split(new char[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in words1)
            {
                words.Add(s);
            }
            foreach (string s in words)
            {
                if (genericWords.Contains(s) == false)
                {
                    if (words.Contains(s))
                    {
                        res++;
                    }
                }
            }
            return res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int res = similar(richTextBox1.Text.ToString().ToLower(), richTextBox2.Text.ToString().ToLower());
            progressBar1.Value = res / (richTextBox1.Text.Length + richTextBox2.Text.Length) * 2;
        }
    }
}
