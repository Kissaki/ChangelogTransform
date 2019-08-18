using KCode.ChangelogTransform.Models;
using System;
using System.Collections.Generic;

namespace KCode.ChangelogTransform.Writers
{
    class LinearHistoryWriter : HistoryWriter
    {
        public LinearHistoryWriter(string filename)
            : base(filename)
        {
        }

        public void Write(List<Commit> history)
        {
            using var fs = TargetFile.CreateText();
            fs.Write(CreateTable(history));
        }
    }
}
