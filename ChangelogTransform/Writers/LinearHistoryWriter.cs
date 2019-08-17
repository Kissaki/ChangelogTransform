using System;
using System.Collections.Generic;
using System.IO;

namespace changelog_transform.Writers
{
    class LinearHistoryWriter : HistoryWriter
    {
        private FileInfo Target { get; }

        public LinearHistoryWriter(string filename)
        {
            Target = new FileInfo(filename);
        }

        public void Write(List<HistoryItem> history)
        {
            if (Target.Exists)
            {
                Console.WriteLine("Linear history already exists; skipping");
                return;
            }

            using var fs = Target.CreateText();
            fs.Write(CreateTable(history));
        }
    }
}
