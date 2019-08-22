using KCode.ChangelogTransform.Transformers.Selectors;

namespace KCode.ChangelogTransform.Types
{
    public class ItemMeta
    {
        public string Title { get; }
        public Category Category { get; }
        public ISelector[] Selectors { get; }
        public string? Description { get; }

        public ItemMeta(string title, Category category, string? description, params ISelector[] selectors)
        {
            Title = title;
            Category = category;
            Selectors = selectors;
            Description = description;
        }
    }
}
