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
            var title = item.Title;

            var commitLink = CreateCommitHashLink(item);

            var pr = "";
            if (item.PullRequestId.HasValue)
            {
                pr = CreateCommitPrLink(item.PullRequestId.Value);
            }

            return $"<tr><td>{commitLink}</td><td>{pr}</td><td>{title}</td></tr>";
        }

        protected string CreateTable(IEnumerable<HistoryItem> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<table>");
            sb.AppendLine(@"<tr><th class=""itemtitle"">Title</th><th class=""pullrequests"">PRs</th><th class=""commithashes"">Commits</th></tr>");
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
            var desc = item.Description != null ? $"<br/>{item.Description}" : "";
            var prs = string.Join(", ", item.Commits.Where(x => x.PullRequestId.HasValue).Select(x => CreateCommitPrLink(x.PullRequestId ?? throw new InvalidOperationException())));

            return @$"<tr><td class=""itemtitle""><b>{title}</b>{desc}</td><td class=""pullrequests"">{prs}</td><td class=""commithashes"">{CreateCommitDetails(item.Commits)}</td></tr>";
        }

        protected string CreateCommitPrLink(int id)
        {
            return @$"<a href=""https://github.com/mumble-voip/mumble/pull/{id}"">#{id}</a>";
        }

        protected string CreateCommitDetails(params Commit[] commits)
        {
            if (!commits.Any())
            {
                return "";
            }

            var hashlist = new List<string>();
            var detaillist = new List<string>();
            foreach (var c in commits)
            {
                var hash = CreateCommitHashLink(c);
                var detail = $"<li>{hash}: {c.Title}</li>";
                hashlist.Add(hash);
                detaillist.Add(detail);
            }
            var summary = string.Join(", ", hashlist);
            var details = string.Join("", detaillist);
            return $@"<details><summary>{summary}</summary><ul class=""commitlist"">{details}</ul>";
        }

        protected string CreateCommitHashLink(Commit commit)
        {
            var commitUrl = $"https://github.com/mumble-voip/mumble/commit/{commit.Hash}";
            return @$"<a href=""{commitUrl}"" title=""{commit.Title}"">{commit.Hash}</a>";
        }
    }
}
