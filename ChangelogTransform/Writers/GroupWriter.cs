using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Types;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KCode.ChangelogTransform.Writers
{
    public class GroupWriter : HistoryWriter
    {
        public GroupWriter(string filename)
            : base(filename)
        {
        }

        public void Write(List<HistoryItem> history)
        {
            using var fs = TargetFile.CreateText();

            var isFirst = true;
            foreach (var x in history.GroupBy(x => x.Category))
            {
                var category = x.Key;
                WriteCategory(fs, category, x.AsEnumerable(), isOpen: isFirst);
                isFirst = false;
            }
        }

        protected void WriteCategory(StreamWriter fs, Category cateory, IEnumerable<HistoryItem> items, bool isOpen)
        {
            var openAttribute = isOpen ? "open" : "";
            fs.WriteLine(@$"<details {openAttribute}><summary><h2 style=""display:inline"">{CategoryName(cateory)}</h2> ({items.Count()})</summary>");
            fs.Write(CreateTable(items));
            fs.WriteLine("</details>");
        }

    }
}
