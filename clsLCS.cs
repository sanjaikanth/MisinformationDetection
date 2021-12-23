using Iveonik.Stemmers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisinformationCheck
{
    class clsLCS
    {
        private List<string> lstInfo;
        public string strCheckInfo;
        DataTable dt;
        private int threshouldCount = 5;
        public clsLCS(string StrSource)
        {
            pullAllCOVIDInfo(StrSource);
        }
        private void pullAllCOVIDInfo(string StrSource)
        {
            DataSet ds= Parse(StrSource);

            if(ds.Tables.Count>0)
            {
                dt = ds.Tables[0];
                System.Data.DataColumn LCSCountColumn = new System.Data.DataColumn("LCSCount", typeof(Int32));
                LCSCountColumn.DefaultValue = 0;
                dt.Columns.Add(LCSCountColumn);
            }
        }
        public Tuple<DataTable, string,int> Descision(string strInput)
        {
            Tuple<int, int> result = getLCSCount(strInput);
            int maxMatchingCount = result.Item1;
            DataTable dtResultMatching = dt.AsEnumerable()
                     .Where((row, index) => int.Parse(row["LCSCount"].ToString()) == maxMatchingCount ).CopyToDataTable();            
            string TypeVal = DecideLabel( maxMatchingCount);//  dr["label"].ToString();
            return Tuple.Create((maxMatchingCount == 0) ? null:dtResultMatching, TypeVal, maxMatchingCount) ;
        }
        private string DecideLabel( int maxMatchingCount)
        {
            if(maxMatchingCount<threshouldCount)
            {
                return "Neutral";
            }
            if(dt.Rows.Count>0)
            {
                DataTable dtResult = dt.AsEnumerable()
                      .Where((row, index) => int.Parse(row["LCSCount"].ToString()) == maxMatchingCount).CopyToDataTable(); ;
                int resultCount = dtResult.Rows.Count;
                if(resultCount == 1)// Only one row that has same max LCS count
                {
                    return dtResult.Rows[0]["label"].ToString();
                }
                else// More than one row that has same max LCS count
                {
                    int trueCount= dtResult.AsEnumerable()
                   .Where((row, index) =>  row["label"].ToString() == "Real").Count();
                    int fakeCount = dtResult.AsEnumerable()
                .Where((row, index) => row["label"].ToString() == "Fake").Count();
                    int misInformationCount = dtResult.AsEnumerable()
                .Where((row, index) => row["label"].ToString() == "MisInformative").Count();
                    int disinformationCount = dtResult.AsEnumerable()
                .Where((row, index) => row["label"].ToString() == "Disinformative").Count();
                    int unverifiedCount = dtResult.AsEnumerable()
               .Where((row, index) => row["label"].ToString() == "Neutral").Count();
                    int maxCount = new int[] { trueCount, fakeCount, misInformationCount, disinformationCount, unverifiedCount }.Max();

                    if (trueCount == maxCount)
                        return "Real";
                    else if (fakeCount == maxCount)
                        return "Fake";
                    else if (disinformationCount == maxCount)
                        return "Disinformative";
                    else if (misInformationCount == maxCount)
                        return "MisInformative";
                    else if (unverifiedCount == maxCount)
                        return "Neutral";
                    else
                        return "Neutral";
 
                }
            }
           
           
            return "Neutral";
        }
        private string processingStemming(string strSentence)
        {
            string returnValue = "";
            string[] arrStrToStem = strSentence.Split(new string[] { " " }, StringSplitOptions.None);
            foreach (string strToStem in arrStrToStem)
            {
                returnValue += new EnglishStemmer().Stem(strToStem) + " ";
            }

            return returnValue.Trim();
        }
        public string removeStopwords(string strToRemove)
        {
            string strDSourceLocation = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data\StopWordsSource.txt");
            string strContent = File.ReadAllText(strDSourceLocation).Replace(" ", "");
            List<string> stopwordsList = strContent.Split(new string[] { "," }, StringSplitOptions.None).ToList<string>();
            string strReturnValue = string.Join(" ", strToRemove.Split().Where(w => !stopwordsList.Contains(w, StringComparer.InvariantCultureIgnoreCase)));
            return strReturnValue;
        }
        public Tuple<int, int> getLCSCount(string strInput)
        {
            int maxMatchingCount = 0;
            int index = 0;
            string strCurrentTweet = "";
            //Test Value In the article returnVal = compareString("A B C B D A B", "B D C A B A");
            strInput = removeStopwords(strInput);
            strInput = processingStemming(strInput);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //do calculations
                string strTweet = removeStopwords(dt.Rows[i]["tweet"].ToString());
                strTweet = processingStemming(strTweet);
                int matchingCount = compareString(strInput, strTweet);
                dt.Rows[i]["LCSCount"] = matchingCount;
                if (matchingCount >= maxMatchingCount)
                {
                    //If matching count are same it will take the shortest matchig one.
                    if (matchingCount == maxMatchingCount)
                    {
                        if (GetLength(strTweet) < GetLength(strCurrentTweet) && strCurrentTweet != "")
                        {
                            index = i;
                            maxMatchingCount = matchingCount;
                        }
                    }
                    else
                    {
                        index = i;
                        maxMatchingCount = matchingCount;
                    }

                }
            }
            return Tuple.Create(maxMatchingCount, index);
        }
        private int compareString(string strInput,string strSource)
        {
            int returnVal = 0;
            string[] X= strInput.Split(new string[] { " " }, StringSplitOptions.None);
            string[] Y= strSource.Split(new string[] { " " }, StringSplitOptions.None);
            int m =  X.Length+1;
            int n = Y.Length+1;
            int[,] c = new int[m, n];
            for (int i=1;i<m;i++)
            {
                c[i, 0] = 0;
            }
            for (int j = 1; j < n; j++)
            {
                c[0, j] = 0;
            }
            for(int i=1; i<m;i++)
            {
                for(int j=1;j<n;j++)
                {
                    if(X[i-1]==Y[j-1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                    }
                    else if (c[i - 1, j] >= c[i, j - 1])
                    {
                        c[i, j] = c[i - 1, j];
                    }
                    else
                    {
                        c[i, j] = c[i, j - 1];
                    }
                }
            }
            returnVal = c.Cast<int>().Max();    
            return returnVal;

        }
        static DataSet Parse(string fileName)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; " +
            "data source='" + fileName + "';" +
            "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ";
            DataSet data = new DataSet();

            foreach (var sheetName in GetExcelSheetNames(connectionString))
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    var dataTable = new DataTable();
                    string query = string.Format("SELECT * FROM [{0}]", sheetName);
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    data.Tables.Add(dataTable);
                }
            }

            return data;
        }

        static string[] GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(connectionString);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }

            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            return excelSheetNames;
        }
        private int GetLength(string strIn)
        {
          return  strIn.Split(new string[] { " " }, StringSplitOptions.None).Length;
        }
    }
}
