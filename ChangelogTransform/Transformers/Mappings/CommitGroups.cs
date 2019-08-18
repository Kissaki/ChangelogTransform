using KCode.ChangelogTransform.Transformers.Selectors;
using KCode.ChangelogTransform.Types;
using System.Collections.Generic;

namespace KCode.ChangelogTransform.Transformers.Mappings
{
    public static class CommitGroups
    {
        private static string[] CodeChanges = new string[]
        {
                "8b044264",
                "14597920",
                "708212ab",
                "f09e943b",
                "487ed147",
                "bb47083b",
                "b0707fd1",
                "9450d669",
                "f4c54b24",
                "b004a4ce",
                "676bb0e3",
                "33069f82",
                "46fc3ccf",
                "84bc19c8",
                "7b68d0ce",
                "2c07833d",
                "84be1eb1",
                "36217acc",
                "2cec7bae",
                "1011d530",
                "5f98a656",
                "229f0419",
                "39697c79",
                "192135db",
                "f5141076",
                "67914c3c",
                "b5ee1f4c",
                "2ac3b67b",
                "da6c2444",
                "34943628",
                "1caaec76",
                "a0ebded7",
                "c52dedce",
                "1f6ddaf3",
                "22d87409",
                "abdb5ac1",
                "4f7ede51",
                "cdcf77c0",
                "769855b4",
                "8540e08a",
                "d1a19d46",
                "9d668ebc",
                "34daf712",
                "12eb2643",
                "fc5fd45f",
                "83218f11",
                "e9e2680f",
                "4a149f8f",
                "b4f0c66c",
                "236e9874",
                "1bd6c883",
                "b78f34d0",
                "124b1ceb",
                "6a07cbd1",
                "2418b806",
                "a7dd1b77",
                "21a15190",
                "e24cfe6c",
                "0f072ef0",
                "c005fe34",
                "15fbe1d7",
                "d9e0d08f",
                "9ee9e8ad",
                "faddfda5",
                "40ca9b45",
        };

        public static List<ItemMeta> Groups { get; } = new List<ItemMeta>
        {
            new ItemMeta("[Linux] Add support for logging to syslog", Category.Features, new Selector(SelectorType.ContainsWord, "syslog")),
            new ItemMeta("[Admin] Support disabling SuperUser login (the initial and fallback administration account)", Category.Features, new Selector(SelectorType.CommitHash, "aaf36667"), new Selector(SelectorType.CommitHash, "708ace45")),
            new ItemMeta("[Admin] Userlist improvements", Category.Improvements, new CommitSelector("c40b0b00", "02ddd914")),
            new ItemMeta("[Admin] Allow admins to clear user avatars/textures.", Category.Improvements, new CommitSelector("52d19ac3")),
            new ItemMeta("[Settings] ", Category.Improvements, new CommitSelector("7c2d1a3f")),
            new ItemMeta("[Dev][Docs] Replace docs folder with Protocol Documentation", Category.Features, new CommitSelector("6eecd624", "eda74f21")),

            new ItemMeta("[Code] Various code changes and improvements", Category.Code, new CommitSelector(CodeChanges)),
        };
    }
}
