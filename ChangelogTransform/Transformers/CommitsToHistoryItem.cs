using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Transformers.Mappings;
using KCode.ChangelogTransform.Types;
using System.Collections.Generic;

namespace KCode.ChangelogTransform.Transformers
{
    public static class CommitsToHistoryItem
    {
        public static List<HistoryItem> Transform(List<Commit> commits)
        {
            commits.RemoveAll(c => IgnoredCommits.Commits.Contains(c.Hash));

            var items = new List<HistoryItem>();
            foreach (var itemMeta in CommitGroups.Groups)
            {
                var itemCommits = new List<Commit>();
                foreach (var s in itemMeta.Selectors)
                {
                    var matchedCommits = new List<Commit>();

                    foreach (var c in commits)
                    {
                        if (s.IsMatch(c))
                        {
                            itemCommits.Add(c);
                            matchedCommits.Add(c);
                        }
                    }

                    commits.RemoveAll(x => matchedCommits.Contains(x));
                }

                var item = new HistoryItem(itemMeta.Title, itemMeta.Category, itemCommits.ToArray())
                {
                    Description = itemMeta.Description
                };
                items.Add(item);
            }
                
            foreach (var commit in commits)
            {
                items.Add(new HistoryItem(commit.Title, Category.Misc, commit));
            }

            return items;
        }
    }
}
