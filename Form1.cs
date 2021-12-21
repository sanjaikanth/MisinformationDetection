using Iveonik.Stemmers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace MisinformationCheck
{
    public partial class Form1 : Form
    {
        string strDSourceLocation;
        clsLCS objCls;
        public Form1()
        {
            InitializeComponent();
            strDSourceLocation = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data\SourceDataNews.xlsx");
            objCls = new clsLCS(strDSourceLocation);
            //TestStemmer(new EnglishStemmer(), "jump", "jumping", "jumps", "jumped");
            // TestStemmer(new EnglishStemmer(), "liked");
        }
        private   void TestStemmer(IStemmer stemmer, params string[] words)
        {
            Console.WriteLine("Stemmer: " + stemmer);
            string strText = "";
            foreach (string word in words)
            {
                strText += word + " --> " + stemmer.Stem(word)+@"\n";
            }
            txtResult.Text = strText;
        }
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            //"COVID-19 vaccines are effective"
            Tuple<string, string,int> typleResult= objCls.Descision(txtCheck.Text.Trim());
            lblResultType.Text = typleResult.Item2;
            txtResult.Text = typleResult.Item1;
            lblNumberOfMatches.Text = typleResult.Item3.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
