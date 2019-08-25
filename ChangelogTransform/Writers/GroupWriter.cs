using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KCode.ChangelogTransform.Writers
{
    public class GroupWriter : HistoryWriter
    {
        public GroupWriter(string filename)
            : base(filename)
        {
        }

        public void Write(List<HistoryItem> history)
        {
            using var fs = TargetFile.CreateText();

            using var bodyWriter = new StringWriter();
            foreach (var x in history.GroupBy(x => x.Category))
            {
                var category = x.Key;
                WriteCategory(bodyWriter, category, x.AsEnumerable(), isOpen: category == Category.Misc);
            }

            var style = @"
                .item { display: grid; grid-template: ""title"" auto
""desc"" auto
""prs"" auto
""commits"" auto / auto
;
                    border: 1px solid darkgrey;
                    border-radius: 4px;
                    margin: 1em 0 0.4em 0;
                    padding: 0.4em;
                }
                .item-title { grid-area: title; margin: 0; line-height: 1.8em; }
                .item-desc { grid-area: desc; margin-bottom: 0.4em; line-height: 1.8em; }
                .item-prs { grid-area: prs; }
                .item-commits { grid-area: commits; }
                .item-commits > details { display: inline-block; }
                .item-prs, .item-commits { margin-bottom: 4px; font-size: 0.8em; line-height: 1.8em; }
                .item-prs > .pr-link,
                .item-commits > details > summary > * { background-color: lightgrey; border-radius: 4px; margin-right: 2px; padding: 2px 4px; }
            ";
            var html = @$"
            <!DOCTYPE html><html>
            <head>
                <meta charset=""utf-8"">
                <style>{style}</style>
            </head><body>
                <h1>Mumble 1.3.0 Changes</h1>
                <div>
                    Legend: The Admin label is split into tier levels to me more specific.<br>
                    T1 = Tier 1: Using the Mumble client in GUI administration features.<br>
                    T2 = Tier 2: OS lifecycle management, server-local command line control, Process control, meta-servers (one process multiple servers)<br>
                    T3 = Tier 3: Scripting via API, etc
                </div>
                {bodyWriter.ToString()}
            </body></html>
            ";
            fs.Write(html);
        }

        protected void WriteCategory(TextWriter tw, Category cateory, IEnumerable<HistoryItem> items, bool isOpen)
        {
            var openAttribute = isOpen ? "open" : "";
            tw.Write($@"
                <section class=""category"">
                    <details class=""items"" {openAttribute}><summary><h2 style=""display:inline"">{CategoryName(cateory)}</h2> ({items.Count()})</summary>
                    {ToHtml(items)}
                    </details>
                </section>
            ");
        }

        protected string ToHtml(IEnumerable<HistoryItem> items)
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.AppendLine(ToHtml(item));
            }
            return sb.ToString();
        }

        protected string ToHtml(HistoryItem item)
        {
            var title = item.Title;
            var desc = item.Description ?? "";
            var prIds = item.Commits.Where(x => x.PullRequestId.HasValue);
            var prs = prIds.Count() == 0 ? "None" : string.Join("", prIds.Select(x => CreateCommitPrLink(x.PullRequestId ?? throw new InvalidOperationException())));
            var commits = CreateCommitDetails(item.Commits);

            return @$"
            <div class=""item"">
                <h3 class=""item-title"">{title}</h3>
                <div class=""item-desc"">{desc}</div>
                <div class=""item-prs"">Pull Requests: {prs}</div>
                <div class=""item-commits"">Commits: {commits ?? "None"}</div>
            </div>
            ";
        }

        protected string? CreateCommitDetails(params Commit[] commits)
        {
            if (!commits.Any())
            {
                return null;
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
            var summary = string.Join("", hashlist);
            var details = string.Join("", detaillist);
            return $@"<details><summary>{summary}</summary><ul class=""commitlist"">{details}</ul>";
        }
    }
}
