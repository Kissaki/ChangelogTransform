using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Transformers;
using KCode.ChangelogTransform.Types;
using System;
using System.Collections.Generic;
using System.IO;

namespace KCode.ChangelogTransform.Writers
{
    class CategoryHistoryWriter : HistoryWriter
    {
        private readonly ItemCategorizer Categorizer = new ItemCategorizer();

        public CategoryHistoryWriter(string filename)
            : base(filename)
        {
        }

        internal void Write(List<Commit> history)
        {
            Categorize(history);

            Console.WriteLine("Categorized:");
            foreach (Category category in CategoryValues)
            {
                Console.WriteLine($"* {Enum.GetName(typeof(Category), category)} {Categorizer.Categories[category].Count}");
            }

            WriteCategories(Categorizer.Categories);
        }

        protected void WriteCategories(Dictionary<Category, List<Commit>> categories)
        {
            using var fs = TargetFile.CreateText();
            fs.WriteLine("<h1>Categorized Changes</h1>");

            var isFirst = true;
            foreach (Category category in CategoryValues)
            {
                var items = categories[category];
                WriteCategory(fs, category, items, isOpen: isFirst);
                isFirst = false;
            }
        }

        protected void WriteCategory(StreamWriter fs, Category cateory, List<Commit> items, bool isOpen)
        {
            var openAttribute = isOpen ? "open" : "";
            fs.WriteLine(@$"<details {openAttribute}><summary><h2 style=""display:inline"">{CategoryName(cateory)}</h2> ({items.Count})</summary>");
            fs.Write(CreateTable(items));
            fs.WriteLine("</details>");
        }

        private void Categorize(List<Commit> history)
        {
            foreach (var item in history)
            {
                Categorizer.Add(item);
            }
        }
    }
}
