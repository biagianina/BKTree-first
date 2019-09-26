using System;

namespace BKTree
{
    class Program
    {
        static void Main()
        {
            string[] dictionary =
            {
                "hell", "help", "shel", "smell",
                "fell", "felt", "oops", "pop", "oouch", "halt"
            };
            CreateBKTree tree = new CreateBKTree();
            for (int i = 0; i < dictionary.Length; i++)
            {
                tree.Add(dictionary[i]);
            }

            const int tolerance = 2;
            foreach (var match in tree.Match("helt", tolerance))
            {
                Console.WriteLine(match);
            }
        }
    }
}
