using System;
using System.Text.RegularExpressions;
using System.Web;

namespace KCode.ChangelogTransform.Models
{
    [Serializable]
    public class Commit
    {
        public string Hash { get; }
        public string Title { get; }
        public string TitleUnsafe { get; }
        public int? PullRequestId { get; }

        public Commit(string hash, string title)
        {
            Hash = hash;
            Title = HttpUtility.HtmlEncode(title);
            TitleUnsafe = title;

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
