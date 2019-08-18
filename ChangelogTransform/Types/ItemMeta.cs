using KCode.ChangelogTransform.Transformers.Selectors;

namespace KCode.ChangelogTransform.Types
{
    public class ItemMeta
    {
        public string Title { get; }
        public Category Category { get; }
        public ISelector[] Selectors { get; }

        public ItemMeta(string title, Category category, params ISelector[] selectors)
        {
            Title = title;
            Category = category;
            Selectors = selectors;
        }
    }
}
