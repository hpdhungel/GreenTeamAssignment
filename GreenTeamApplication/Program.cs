using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace GreenTeamApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nProvide me file name?");
            var name = Console.ReadLine();
            string filePath = ($"/Users/hpdhungel/Projects/GreenTeamApplication/GreenTeamApplication/CSV/{name}.csv");
            var validEmails = new List<string>();
            var invalidEmails = new List<string>();

            if (File.Exists(filePath))
            {
                using (TextFieldParser parser = new TextFieldParser($"{filePath}"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            Console.Write($"{field}");
                        }

                        string email = fields[2];
                        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                        Regex re = new Regex(strRegex);
                        if (re.IsMatch(email))
                        {
                            validEmails.Add(email);
                        }
                        else
                        {
                            invalidEmails.Add(email);
                        }

                    }
                }

                Console.WriteLine($"\nValid Emails:({validEmails.Count})");
                for (int i = 0; i < validEmails.Count; i++)
                { 
                Console.WriteLine(validEmails[i]);
                }

                Console.WriteLine($"\nInvalid Emails:({invalidEmails.Count})");
                for (int i = 0; i < invalidEmails.Count; i++)
                {
                    Console.WriteLine(invalidEmails[i]);
                }
              
            }
            else
            {
                Console.WriteLine("No file found");
            }
        }
    }
}

