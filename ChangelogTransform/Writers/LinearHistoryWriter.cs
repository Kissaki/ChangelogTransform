using KCode.ChangelogTransform.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace KCode.ChangelogTransform.Writers
{
    class LinearHistoryWriter : HistoryWriter
    {
        private FileInfo Target { get; }

        public LinearHistoryWriter(string filename)
        {
            Target = new FileInfo(filename);
        }

        public void Write(List<Commit> history)
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
