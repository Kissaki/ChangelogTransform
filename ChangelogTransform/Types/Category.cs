namespace KCode.ChangelogTransform.Types
{
    public enum Category
    {
        // Everything uncategorized
        Misc,

        // New features
        Features,
        // Improvements - could be split into GUI, admin, user, hidden/expert, etc
        Improvements,
        // Fixed bugs
        Bugfixes,

        // Code formatting, being able to compile on different platforms, code improvements - could be split up further
        Code,
    };
}
