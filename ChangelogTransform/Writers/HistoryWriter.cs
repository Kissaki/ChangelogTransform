using KCode.ChangelogTransform.Models;
using System.Collections.Generic;
using System.Text;

namespace KCode.ChangelogTransform.Writers
{
    public class HistoryWriter
    {
        protected string CreateTable(List<Commit> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<table>");
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

            var commitUrl = $"https://github.com/mumble-voip/mumble/commit/{hash}";
            var commit = @$"<a href=""{commitUrl}"">{hash}</a>";

            var pr = "";
            if (item.PullRequestId.HasValue)
            {
                pr = @$"<a href=""https://github.com/mumble-voip/mumble/pull/{item.PullRequestId}"">#{item.PullRequestId.Value}</a>";
            }

            return $"<tr><td>{commit}</td><td>{pr}</td><td>{title}</td></tr>";
        }
    }
}
