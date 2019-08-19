using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Transformers.Selectors;
using KCode.ChangelogTransform.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                "7642e722",
                "1e4bb6db",
                "15370fb5",
                "2c490d71",
                "3227b1c9",
                "6e8c8939",
                "bcaa10ac",
                "b25a9069",
                "694dca85",
                "acd8174f",
                "ced3bf8d",
                "83da9564",
                "1250b041",
                "e6b17b56",
                "fac930b3",
                "75feffb3",
                "821486ae",
                "0623c14f",
                "35e58ebb",
                "65c1affb",
                "e614a7b9",
                "e8f627f8",
                "0528883a",
                "f4e3ca98",
                "aedb1a3d",
                "495dfdc0",
                "e9f87a60",
                "75a25c43",
                "1a8175be",
                "1090423e",
                "2062b243",
                "e074dded",
                "bfe43e30",
                "7eb4987c",
                "1e06692e",
                "9f85eeb2",
                "5feef962",
                "8ea17403",
                "63909462",
                "2fdbc837",
                "5dac7e81",
                "ce1df5d3",
                "21673bf4",
                "eaad2da6",
                "40868d47",
                "173b68a2",
                "9db30159", "bd49fa59", "17ddc1a3",
                "3910dc96",
                "143bf861",
                "b4589b45",
                "8b4ed1e1",
                "3643c240",
                "a24b8c30",
                "a59e166c",
                "4e9f4127",
                "0393ed34",
                "0502fa67",
                "25422e7f",
                "b7271c20",
                "6a3f2ef9",
                "5b6bdac5",
                "656be8fe",
                "11b2823a",
                "2f34ff75",
                "d3e1c68b",
                "07559e23",
                "ea372dea",
                "3d050886",
                "f2417826",
                "ad10136d",
                "d6572388",
                "ca2fd07b",
                "e9f3c081",
                "52fd689c",
                "46137d96",
                "c0865e14",
                "0df5c64d",
                "2a106e19",
                "5998cc0a",
                "59275f54",
                "f5429899",
                "039096ac",
                "1be562fe",
                "eca32a03",
                "077cbfd9",
                "11f92440",
                "1773dc71",
                "289d0d4c",
                "e0b384b0",
                "5d036bc9",
                "accc8fda",
                "e95dd303",
                "cae5d6d0",
                "a58d708f",
                "b046d6f1",
                "50764166",
                "aef577f8",
                "92b82cf2",
                "5e7cbcac",
                "a27fbb7b",
                "efd63614",
                "b54166be",
                "bd6a4669",
                "eca5d035",
                "0cffca12",
                "c0c5ba74",
                "449c7974",
                "a6cae4f9",
                "30a91763",
                "7c77b8c0",
                "d3bacc5a",
                "d472e06d",
                "e913a441",
                "3fcd786b",
                "9a2fa244",
                "911f957d",
                "53574722",
                "e79ca504",
                "9d4691cb",
                "d8179372",
                "6770eac8",
                "5564901b",
                "6f434d3e",
                "5db1fa41",
                "04c05785",
                "53c5a917",
                "894ade2a",
                "8bf71ba1",
                "6bfd0392",
                "caa18737",
                "e348e47f",
                "e5ff9c52",
        };

        public static List<ItemMeta> Groups { get; } = new List<ItemMeta>();

        static CommitGroups()
        {
            Feature("[Linux] Add support for logging to syslog").Matches(new Selector(SelectorType.ContainsWord, "syslog")).Add();
            Feature("[Admin T2] Support disabling SuperUser login (the initial and fallback administration account)").Commits("aaf36667", "708ace45").Add();
            Feature("[Admin T3]", "dc3b78c9").Add();
            Feature("TODO from [code]: mumble-app/mumble-exe").Add();
            Feature("[Settings] Support restarting Mumble client to apply setting changes where this is necessary (theme)").Commits("c431d376", "d08336e5", "3f0e2d2c", "459022de", "e061b72a").Add();
            Feature("[User] Per user volume adjustment").Commits("15f47f4f", "bd9bb666", "42c0684c", "a7798709", "1603d085").Add();
            Feature("Per channel user limit").Commits("84b1bcec", "c0879e57", "0b0c074d", "fea39f20").Add();
            Feature("[User] save images from chat log").Commits("b0c9521e", "8722bdd0", "56fc9de7").Add();
            Feature("[Settings] Drop expert mode").Commits("4090c212", "b16983f3").Add();
            Feature("ViewCert: show certificate's SHA-256 fingerprint").Commits("a297a24b", "4f4e5ac2").Add();
            Feature("[Dev][MinGW]").AnyWord("MinGW").Add();
            Improvement("[Admin T2] Human readable-friendly passwords").Commits("9ae2a7f5").Add();
            Feature("Various Features")
                .Commits("6c096c31"
                    , "c05d4de5"
                    , "9be606ef"
                    , "f3a1a6c7"
                    , "012cde52"
                    , "6ac0553a"
                    , "ddd47649"
                    , "bf90fadd"
                    , "cad1bac3"
                    , "65909b89"
                    , "4481729e"
                    , "d66eeebe"
                    , "3eae0dc6"
                )
                .Add();

            Improvement("[Admin T1] Userlist improvements").Commits("c40b0b00", "02ddd914", "d19e266f", "46cb8a37", "07a142d1").Add();
            Improvement("[Admin T1] Allow admins to clear user avatars/textures.").Commits("52d19ac3").Add();
            Improvement("[Settings] ").Commits("7c2d1a3f").Add();
            Improvement("[Accessibility]").Commits("47a81f7b").Add();
            Improvement("XInput").StartsWithAny("XInput").AnyWord("XInput").Add();
            Improvement("[GUI] Various GUI improvements").Commits("c2be406a", "10abf369", "be4ae5b2", "4a99cde5", "46462cd7", "80602a3e", "455ab192", "a4e859e7").Add();
            Improvement("[GUI] CertWizard: Password requirement notice on import").Commits("8f94c763").Add();
            Improvement("Various Documentation Improvements")
                .Commits("83da4f17"
                    , "77b59e5d"
                    , "d793aa11"
                    , "7d4fe6cc"
                    , "a69916bc"
                    , "948331ee"
                )
                .Add();
            Improvement("Various Improvements")
                .Commits("754fc008"
            #region Various Improvements
                    , "679eacd7"
                    , "b422e0a9"
                    , "f07f0c86"
                    , "cde56107"
                    , "d9d81a99"
                    , "3e0112da"
                    , "d3e00dee"
                    , "1eefaab0"
                    , "b2d938ba"
                    , "b7d9387b"
                    , "97cf80de"
                    , "d299360f"
                    , "1375022b"
                    , "dd7cc7ca"
                    , "3c280a66"
                    , "76475381"
                    , "71ff77b2"
                    , "d9785f9f"
                    , "44a08461"
                    , "9cc1c0a7"
                    , "ad19d157"
                    , "5a033b8b"
                    , "525995d1"
                    , "9ba92b58"
                    , "f5affcd4"
                    , "67ed33f3"
                    , "445cdf0e"
                    , "2c0d37f9"
                    , "b2282e74"
                    , "4e459a9b"
                    , "ab78e6c9"
                    , "7fbe61e5"
                    , "6db171ef"
                    , "b4d48ef4"
                    , "ce413bd9"
                    , "e8027bd6"
                    , "8e195e17"
                    , "21cd4ddc"
                    , "c1b6110b"
                    , "f32343d5"
                    , "4862897a"
                    , "9e8a40f6"
                    , "925587af"
                    , "b5825472"
                    , "08af66d5"
                    , "703f8c7f"
                    , "b83316ad"
                    , "33f8448d"
                    , "25ceebb3"
                    , "69cdaee4"
                    , "a2e6cb8c"
            #endregion
                    , "cd8fbbdc"
                    , "a50a120b"
                    , "a1a969e7"
                    , "c522cff0"
                    , "e6cde15c"
                    , "2d6e099d"
                    , "4add9cec"
                    , "b2e37e68"
                    , "0d76ff92"
                    , "153c0aa9"
                    , "b5aef4ca"
                    , "fa818bdf"
                    , "cb952e06"
                    , "dbab0f70"
                    , "871240e7"
                    , "4e430f74"
                    , "65c25009"
                    , "6aba9842"
                    , "5c9a46e9"
                    , "6cd17bdc"
                    , "31254397"
                    , "2c24ee0f"
                    , "a1899695"
                )
                .Add();

            Fix("[GUI] OS-X styling issues").Commits("66d41efd").Add();
            Fix("Various Bugfixes")
                .AnyWord("Fix", "Fixes", "Fixed", "fix")
                .Commits("73a1a98d"
                    , "8ad8812b"
                    , "916dcc0c"
                    , "77233edf"
                    , "ed424afa"
                    , "ea165cde"
                    , "abad339f"
                    , "63f35d6a"
                    // VoiceRecorder
                    , "1c00533b"
                    , "78604d85"
                    , "491789c2"
                    , "06e19e6f"
                    , "a1ff21bd"
                    , "ebf6d23f"
                    , "2612b67d"
                    , "6fe55478"
                    , "612d6b52"
                    , "23fa9b39"
                    , "779496c5"
                    , "d0ced447"
                    , "fd9c7941"
                    , "c45298e4"
                    , "06d3785a"
                    , "c3e29055"
                    , "1a1bd8c1"
                    , "27189b63"
                    , "eb63d0b1"
                    , "4566f092"
                )
                .Add();

            Feature("[Theme]")
                .ContainsAny("theme", "Theme")
                .AnyWord("icon", "icons", "ApplicationPalette")
                .Commits("7fbd9d43", "197f13ed")
                .Add();
            Feature("[Admin][GRPC] Add support for GRPC (Remote Procedure Call API for scripting the server)(CURRENTLY DISABLED)")
                .AnyWord("grpc")
                .ContainsAny("gRPC", "GRPC")
                .Commits("765f7807")
                .Add();
            Improvement("[Admin][SocketRPC]")
                .AnyWord("SocketRPC")
                .Add();
            Improvement("[Dev][Protobuf]")
                .Commits("4fe07a50")
                .Add();

            Improvement("[Translation] Translation updates")
                .AnyWord("translation", "Translation", "translations", ".ts", "MumbleTransifexBot")
                .Commits("52272e28", "de2e0868", "f1eb6425", "e6ac067c")
                .Add();
            Improvement("[Overlay]")
                .StartsWithAny("Overlay", "overlay")
                .AnyWord("overlay", "OverlayClient", "Overlay", "drawOverlay", "overlays", "OverlayPrivateWin", "overlay_exe", "overlay_gl", "OverlayConfig", "mumble_ol", "HardHook", "winhook", "Hooks")
                .Commits("0e358bff", "c1e9102c")
                .Add();
            Improvement("[PositionalAudio]")
                .StartsWithAny("plugins/", "Plugins")
                .ContainsAny("positional audio", "Positional audio", "Positional Audio")
                .AnyWord("PA", "Plugin", "Plugins", "plugins", "plugin")
                .Commits("398b7733", "61ad05c9", "9f6c08b2", "80d03543", "de1d9834", "a235d1a6")
                .Add();
            Improvement("[installer]")
                .AnyWord("installer")
                .Commits("9f5b01b9", "fcc2a390", "e7282052")
                .Add();
            Improvement("[3rdparty]")
                .ContainsAny("3rdparty")
                .Add();
            Improvement("[Admin T1] Show ban message when someone bans").Commits("c522cff0").Add();

            Improvement("[Ice]")
                .AnyWord("Ice", "ice", "MurmurIce")
                .Commits("b595d650")
                .Add();

            Item(Category.Code, "[Code] Various code changes and improvements")
                .Commits(CodeChanges)
                .StartsWithAny("Bump version")
                .ContainsAny("QT_", "Q_")
                .AnyWord("submodule", "build", "compiler.pri", "header guard", "refac", "Refac", "refacs", "Refactor", "Refactoring", "guard define", ".pri", "qmake", "LICENSE", "license", "CHANGES", @"C\+\+11")
                .Add();
            Item(Category.Code, "[Code] Various changes related to copyright and authors")
                .Commits("7a333184", "6e165025", "4b3746ab", "999b59b8", "3434ff89", "37c4749e", "2c2744ea", "80b8e3cf", "dd874ccd", "486381c9", "c59ca21c", "45ad52f1", "cb5e34f9", "ac9fa648", "3ffd9ad3")
                .Add();
            Feature("[Dev][Docs] Replace docs folder with Protocol Documentation")
                .Commits("6eecd624", "eda74f21")
                .AnyWord("protocol documentation")
                .Add();

            Item(Category.Code, "[Build Infrastructure]")
                .AnyWord("scripts", ".pro", "buildenv", "travis-ci", "Travis-CI", "travis", "appveyor")
                .Add();
            Item(Category.Code, "[Tests]")
                .StartsWithAny("src/tests", "tests/", "Test")
                .AnyWord("OverlayTest", "tests")
                .Add();
            Improvement("[Opus]")
                .AnyWord("Opus", "opus")
                .Add();
            Improvement("[Bonjour]")
                .AnyWord("Bonjour", "bonjour")
                .Add();
            Improvement("[Qt 5]")
                .AnyWord("Qt 5", "Qt5")
                .Add();
            Item(Category.Code, "Qt 4")
                .AnyWord("Qt 4", "Qt4")
                .Add();
            Improvement("[Shortcut]")
                .StartsWithAny("GlobalShortcut", "GlobalShortuct")
                .AnyWord("GlobalShortcut", "Shortcut", "shortcut")
                .Add();
            Improvement("[Banlist]")
                .AnyWord("BanList", "Banlist")
                .Add();
            Improvement("[OSInfo]")
                .StartsWithAny("OSInfo")
                .Add();
            Item(Category.G15Lcd, "[G15 LCD]")
                .StartsWithAny("G15")
                .AnyWord("LCD", "G15", "g15helper")
                .Add();

            Improvement("[UI] Filtering")
                .AnyWord("filter", "filtering")
                .Add();
            Improvement("[Text to Speech]")
                .StartsWithAny("TextToSpeech")
                .AnyWord("TextToSpeech", "text-to-speech")
                .Add();
            Item(Category.SSL, "[SSL]")
                .ContainsAny("OPENSSL")
                .AnyWord("SSL", "ssl", "sslCiphers", "sslciphers", "SSLCipherInfo", "lssl", "OpenSSL", "QSslSocket", "QSslSocket", "SSLCipherInfoTable", "OPENSSL")
                .Add();

            Item(Category.Code, "[Hardening] Hardening against accidental or deliberate misuse, security hardening")
                .Commits("b6e17cac", "9837c4dc", "17fa695b", "d9ff1e94", "527d24ed", "e438a05f", "e740ea5e", "996a3df4"
                , "73a1a98d"
                , "fc24262f"
                )
                .Add();

            Improvement("[Admin T3]").Commits("7cff8ca5").Add();
            Feature("Diffie-Hellman").AnyWord("Diffie-Hellman").Add();
        }

        private static Builder Item(Category category, string title) => new Builder(category, title);

        private static Builder Feature(string title) => Item(Category.Features, title);
        private static Builder Feature(string title, string commitHash) => Feature(title).Commits(commitHash);
        private static Builder Improvement(string title) => Item(Category.Improvements, title);
        private static Builder Improvement(string title, string commitHash) => Improvement(title).Commits(commitHash);
        private static Builder Fix(string title) => Item(Category.Bugfixes, title);

        private class Builder
        {
            private readonly Category Category;
            private readonly string Title;
            private readonly List<ISelector> Selectors = new List<ISelector>();

            public Builder(Category category, string title)
            {
                Category = category;
                Title = title;
            }

            public Builder Commits(params string[] hashes) { Selectors.Add(new CommitSelector(hashes)); return this; }
            public Builder Matches(params ISelector[] selector) { Selectors.AddRange(selector); return this; }
            public Builder AnyWord(params string[] words) { Selectors.AddRange(words.Select(word => new Selector(SelectorType.ContainsWord, word))); return this; }
            public Builder StartsWithAny(params string[] words) { Selectors.AddRange(words.Select(word => new Selector(SelectorType.StartsWith, word))); return this; }
            public Builder ContainsAny(params string[] words) { Selectors.AddRange(words.Select(word => new Selector(SelectorType.Contains, word))); return this; }
            public void Add() => Groups.Add(new ItemMeta(Title, Category, Selectors.ToArray()));
        }
    }
}
