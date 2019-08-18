using KCode.ChangelogTransform.Transformers.Selectors;
using KCode.ChangelogTransform.Types;
using System.Collections.Generic;

namespace KCode.ChangelogTransform.Transformers.Mappings
{
    public static class CommitGroups
    {
        public static List<ItemMeta> Groups { get; } = new List<ItemMeta>
        {
            new ItemMeta("syslog", Category.Features, new Selector(SelectorType.ContainsWord, "syslog")),
            new ItemMeta("disable SuperUser", Category.Features, new Selector(SelectorType.CommitHash, "aaf36667"), new Selector(SelectorType.CommitHash, "708ace45")),
        };
    }
}
