using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        static DataTable table = new DataTable();


        static void Main(string[] args)
        {
            convertToMyFormat();


        }


        static void convertToMyFormat()
        {

         
                using (
                    StreamReader reader =
                        new StreamReader(@"C:\Users\Oreoluwa\Desktop\dataset_assign4\dataset\poker.train"))
                {

                    string line;
                    int rowNum = 0;
                    table.Columns.Add("Label");
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] row = line.Split(' ');
                        table.Rows.Add();   //add row
                        table.Rows[rowNum][0] = row[0];
                        foreach (string s in row)
                        {
                            if (s != row[0])
                            {
                                string[] attrVal = s.Split(':');
                                int attributeNum = int.Parse(attrVal[0]);
                                increaseNumColumns(attributeNum);
                                //call increaseColumn function to increase the number of columns to attribute if the current size is less than it
                                table.Rows[rowNum][attributeNum] = double.Parse(attrVal[1]);//value always 1 sometimes e.g for breast_cancer dataset
                            }
                            //Console.WriteLine(
                        }
                        rowNum++;

                        // table.Rows.Add(row[4], double.Parse(row[0]), double.Parse(row[1]), double.Parse(row[2]), double.Parse(row[3]));
                        //   List<string> label = trainingdata.Split('\n').Select(s => s.Trim()).Where(s => s.EndsWith(input)).ToList();
                        //  NaiveBayesianClassifier<string, string> classifier = new NaiveBayesianClassifier<string, string>();
                        //   var set = classifier.AddTokenClass(input, label.Select(s => s.Split('\t').Select(s2 => s2.Trim()).Where(s2 => s2 != "")));
                    }
                }
                using (
            System.IO.StreamWriter writer =
                new System.IO.StreamWriter(
                    @"C:\Users\Oreoluwa\Downloads\naive-bayes-java-master\naive-bayes-java-master\data\poker_train"))
                {

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            if (j == 0)
                            {
                                writer.Write(table.Rows[i][j]);

                            }
                            else
                            {
                                writer.Write("	" + table.Rows[i][j]);

                            }

                        }
                        writer.WriteLine();

                    }
                
                }


        }


        static void increaseNumColumns(int columnSize)
        {
            int currentSize = table.Columns.Count;
            while (currentSize < columnSize + 1)
            {
                currentSize++;
                table.Columns.Add(currentSize.ToString());
            }


        }

        private static void convertToHisFormat()
        {


            using (
                System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\Users\Oreoluwa\Desktop\dataset_assign4\dataset\poker.test"))
            {

                using (
                    StreamReader reader =
                        new StreamReader(@"C:\Users\Oreoluwa\Downloads\naive-bayes-java-master\naive-bayes-java-master\data\poker_test"))
                {
                    string line;
                    // int rowNum = 0;
                    //table.Columns.Add("Label");
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] row = line.Split('	');

                        // table.Rows.Add();   //add row
                        //  table.Rows[rowNum][0] = row[0];
                        writer.Write(row[0]);
                        int attrIndex = 1;
                        foreach (string s in row)
                        {


                            if (s != row[0])
                            {
                                if (int.Parse(s) != 0)
                                {
                                    // string[] attrVal = s.Split(':');
                                    // int attributeNum = int.Parse(attrVal[0]);
                                     writer.Write(" " + attrIndex + ":" + s);
                                    //writer.Write(" " + s);

                                }
                                // increaseNumColumns(attributeNum);
                                //call increaseColumn function to increase the number of columns to attribute if the current size is less than it
                                //  table.Rows[rowNum][attributeNum] = double.Parse(attrVal[1]);
                                //   //value always 1 sometimes e.g for breast_cancer dataset
                                attrIndex++;
                            }

                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
