using KCode.ChangelogTransform.Models;
using System.Collections.Generic;
using System.Text;

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
    }
}
