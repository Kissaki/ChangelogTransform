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

            using var bodyWriter = new StringWriter();
            foreach (var x in history.GroupBy(x => x.Category))
            {
                var category = x.Key;
                WriteCategory(bodyWriter, category, x.AsEnumerable(), isOpen: category == Category.Misc);
            }

            var style = @"
                th, td {{ text-align: left; }}
                .itemtitle {{ width: 120px; }}
                .itemtitle b {{ white-space: nowrap; }}
                tbody {{ vertical-align: top; }}
            ";
            var html = @$"
            <!DOCTYPE html><html>
            <head>
                <meta charset=""utf-8"">
                <style>{style}</style>
            </head><body>
            Legend: The Admin label is split into tier levels to me more specific.
            T1 = Tier 1: Using the Mumble client in GUI administration features.
            T2 = Tier 2: OS lifecycle management, server-local command line control, Process control, meta-servers (one process multiple servers)
            T3 = Tier 3: Scripting via API, etc
            {bodyWriter.ToString()}
            </body></html>
            ";
            fs.Write(html);
        }

        protected void WriteCategory(TextWriter tw, Category cateory, IEnumerable<HistoryItem> items, bool isOpen)
        {
            var openAttribute = isOpen ? "open" : "";
            tw.Write($@"
                <details {openAttribute}><summary><h2 style=""display:inline"">{CategoryName(cateory)}</h2> ({items.Count()})</summary>
                {CreateTable(items)}
                </details>
            ");
        }
    }
}
