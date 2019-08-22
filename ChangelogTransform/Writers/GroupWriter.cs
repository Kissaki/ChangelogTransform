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

            fs.WriteLine(@"<!DOCTYPE html><html><head><meta charset=""utf-8"">");
            fs.WriteLine(@"<style>");
            fs.WriteLine(@"th, td { text-align: left; }");
            fs.WriteLine(@"</style>");
            fs.WriteLine(@"</head><body>");
            fs.WriteLine("Legend: The Admin label is split into tier levels to me more specific.");
            fs.WriteLine("T1 = Tier 1: Using the Mumble client in GUI administration features.");
            fs.WriteLine("T2 = Tier 2: OS lifecycle management, server-local command line control, Process control, meta-servers (one process multiple servers)");
            fs.WriteLine("T3 = Tier 3: Scripting via API, etc");

            foreach (var x in history.GroupBy(x => x.Category))
            {
                var category = x.Key;
                WriteCategory(fs, category, x.AsEnumerable(), isOpen: category == Category.Misc);
            }

            fs.Write("</body></html>");
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
