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
            var matchedCommits = new List<Commit>();
            foreach (var itemMeta in CommitGroups.Groups)
            {
                var itemCommits = new List<Commit>();
                foreach (var s in itemMeta.Selectors)
                {
                    foreach (var c in commits)
                    {
                        if (s.IsMatch(c))
                        {
                            itemCommits.Add(c);
                            matchedCommits.Add(c);
                        }
                    }
                }
                items.Add(new HistoryItem(itemMeta.Title, itemMeta.Category, itemCommits.ToArray()));
            }

            commits.RemoveAll(x => matchedCommits.Contains(x));
                
            foreach (var commit in commits)
            {
                Category category;
                if (!CommitCategories.CommitMappingTransformed.TryGetValue(commit.Hash, out category))
                {
                    category = Category.Misc;
                }
                items.Add(new HistoryItem(commit.Title, category, commit));
            }

            return items;
        }
    }
}
