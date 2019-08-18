using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KCode.ChangelogTransform.Writers
{
    public abstract class HistoryWriter
    {
        protected static Category[] CategoryValues = Enum.GetValues(typeof(Category)).Cast<Category>().ToArray();
        protected static string CategoryName(Category category) => Enum.GetName(typeof(Category), category) ?? throw new InvalidOperationException();

        protected FileInfo TargetFile { get; }

        protected HistoryWriter(string filename)
        {
            TargetFile = new FileInfo(filename);
        }

        protected string CreateTable(IEnumerable<Commit> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><th>Commit</th><th>PR</th><th>Title</th></tr>");
            foreach (var line in items)
            {
                sb.AppendLine(CreateRow(line));
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }

        protected string CreateRow(Commit item)
        {
            var hash = item.Hash;
            var title = item.Title;

            var commit = CreateCommitHashLink(hash);

            var pr = "";
            if (item.PullRequestId.HasValue)
            {
                pr = CreateCommitPrLink(item.PullRequestId.Value);
            }

            return $"<tr><td>{commit}</td><td>{pr}</td><td>{title}</td></tr>";
        }

        protected string CreateCommitHashLink(string hash)
        {
            var commitUrl = $"https://github.com/mumble-voip/mumble/commit/{hash}";
            return @$"<a href=""{commitUrl}"">{hash}</a>";
        }

        protected string CreateCommitPrLink(int id)
        {
            return @$"<a href=""https://github.com/mumble-voip/mumble/pull/{id}"">#{id}</a>";
        }

        protected string CreateTable(IEnumerable<HistoryItem> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><th>Title</th><th>Commits</th><th>PRs</th></tr>");
            foreach (var line in items)
            {
                sb.AppendLine(CreateRow(line));
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }

        protected string CreateRow(HistoryItem item)
        {
            var title = item.Title;
            var commits = string.Join(", ", item.Commits.Select(x => CreateCommitHashLink(x.Hash)));
            var prs = string.Join(", ", item.Commits.Where(x => x.PullRequestId.HasValue).Select(x => CreateCommitPrLink(x.PullRequestId ?? throw new InvalidOperationException())));

            return $"<tr><td>{title}</td><td>{commits}</td><td>{prs}</td></tr>";
        }
    }
}
