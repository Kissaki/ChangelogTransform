using System;
using System.Text.RegularExpressions;

namespace KCode.ChangelogTransform.Models
{
    [Serializable]
    public class HistoryItem
    {
        public string Hash { get; }
        public string Title { get; }
        public int? PullRequestId { get; }

        public HistoryItem(string hash, string title)
        {
            Hash = hash;
            Title = title;

            PullRequestId = ParsePullRequestId(title);
        }

        private int? ParsePullRequestId(string title)
        {
            var regPr = new Regex("((PR)|(pull request)) #(?<pr>[0-9]+)");
            var prMatch = regPr.Match(title);
            if (prMatch.Success)
            {
                return int.Parse(prMatch.Groups["pr"].Value);
            }
            return null;
        }
    }
}
