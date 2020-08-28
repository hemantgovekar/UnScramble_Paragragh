using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Anagram_Check
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileDetails = File.ReadAllLines("words_alpha.txt");

            Dictionary<string, string> _dict1 = new Dictionary<string, string>();

            foreach (var word1 in fileDetails)
            {
                if (!_dict1.ContainsKey(word1))
                    _dict1.Add(word1, String.Concat(word1.OrderBy(c => c)));
            }

            //foreach (var item in _dict1)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}

            HashSet<string> blogWords = new HashSet<string>();
            int i = 0;
            using (StreamReader sr = new StreamReader("blog.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string[] words = line.Split();

                    foreach (var word in words)
                    {
                        var blogword = String.Concat(word.OrderBy(c => c));

                        try
                        {
                            var keyVal = _dict1.FirstOrDefault(x => x.Value == blogword).Key.Trim() == "" ? "XXXX" : _dict1.FirstOrDefault(x => x.Value == blogword).Key;
                            Console.Write(keyVal + " ");
                            i++;

                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }




            Console.ReadLine();
        }
    }
}
