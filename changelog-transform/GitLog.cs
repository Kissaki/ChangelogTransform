using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace changelog_transform
{
    class GitLog
    {
        public DirectoryInfo RepoPath { get; }
        public string Source { get; }
        public string Target { get; }

        public GitLog(DirectoryInfo di, string fromRef, string toRef)
        {
            RepoPath = di;
            Source = fromRef;
            Target = toRef;
        }
    }
}
