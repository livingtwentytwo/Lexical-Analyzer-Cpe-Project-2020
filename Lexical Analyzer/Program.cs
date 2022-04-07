using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lexical_Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            TokenAnalyzer analyzer = new TokenAnalyzer();
            int inputLength;

            var fileStream = new FileStream(@"C:\Users\USER\Desktop\Everything\test.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line != String.Empty)
                    {
                        string[] inputArray = line.Split(' ');
                        inputLength = inputArray.Length;

                        for (int i = 0; i < inputLength; i++)
                        {
                            if (i == inputLength - 1)
                            {
                                string data;
                                data = inputArray[i].Substring(0, inputArray[i].Length - 1);
                                analyzer.input_check(data);
                            }
                            else
                            {
                                analyzer.input_check(inputArray[i]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                    }

                }
            }        
            
            Console.ReadKey();
        }
    }
}
