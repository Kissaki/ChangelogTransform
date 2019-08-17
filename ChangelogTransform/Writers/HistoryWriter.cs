using System.Collections.Generic;
using System.Text;

namespace changelog_transform.Writers
{
    public class HistoryWriter
    {
        protected string CreateTable(List<HistoryItem> items)
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

        protected string CreateRow(HistoryItem item)
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
