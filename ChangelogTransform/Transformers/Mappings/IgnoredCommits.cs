﻿using System.Collections.Generic;

namespace KCode.ChangelogTransform.Transformers.Mappings
{
    public static class IgnoredCommits
    {
        public static List<string> Commits = new List<string>
        {
            // commit and revert
            "2a106e19", "460f5502",
            // This was a wrongfully added pull-merge merge commit merging mumble master into a local branch, and then pushing that back to master.
            // The two second-level merge commits should be listed instead: bc012541, 73fe4578
            "0c157216",
            // Easter egg fix
            "8d3521ce",
        };
    }
}
