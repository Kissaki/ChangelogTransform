﻿using KCode.ChangelogTransform.Transformers.Selectors;
using KCode.ChangelogTransform.Types;
using System.Collections.Generic;
using System.Linq;

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
                "fcb367f8",
                "39c526a7",
                "0dddc437",
                "48277cb2",
                "b230c285",
                "af4b7526",
                "7e15d9e1",
                "c91553c4",
                "c014e04f",
                "f90ef837",
                "02a14f4e",
                "0db712ed",
                "b5ee1f4c",
                "64d28eb0",
                "eda8adec",
                "aa263e92",
                "d41923d5",
                "5a033b8b",
                "525995d1",
        };

        public static List<ItemMeta> Groups { get; } = new List<ItemMeta>();

        static CommitGroups()
        {
            DefineFeatures();
            DefineImprovements();
            DefineFixes();
            DefineCode();
        }

        private static void DefineFeatures()
        {
            Feature("[User] Support per user volume adjustment").Commits("15f47f4f", "bd9bb666", "42c0684c", "a7798709", "1603d085").Add();
            Feature("[User] Support attenuate others on priority speaker", "Our priority speaker functionality offers some control over busy talking for marked individuals; namely lowering the volume of others when the priority speaker talks so you can hear the priority speaker over the others.<br><br>This attenuation is now configurable to also happen for the priority speakers themselves.").Commits("29a65c66").Add();
            Feature("[User][Settings] Support restarting Mumble client to apply setting changes where this is necessary (theme)").Commits("c431d376", "d08336e5", "3f0e2d2c", "459022de", "e061b72a").Add();
            Feature("[User] Support saving images from chat log").Commits("b0c9521e", "8722bdd0", "56fc9de7").Add();
            Feature("[User][Theme] Provide official themes (dark, lite and classic) and improve theme-ability")
                .ContainsAny("theme", "Theme")
                .AnyWord("icon", "icons", "ApplicationPalette")
                .Commits("7fbd9d43", "197f13ed", "54244962")
                .Add();
            Feature("[User] Support sending clipboard content to chat").Commits("c05d4de5").Add();
            Feature("[User] Allow Prefilling Add Server Dialog With HTTP URLs").Commits("3eae0dc6").Add();
            Feature("[User][UI] Support channel filtering").Commits("304bf438", "8f30d0c2", "42d74df5", "15afc05e", "983b6dba", "d35468c7", "679eacd7", "b5d37583", "c0be6cbd").Add();
            Feature("[Client] Distribute x64 (“64 bit”) version", "Supporting a new architecture can be quite a bit of work. We have implemented various spawner processes for adequate Overlay and Positional Audio support, and moved the main client application into a separate assembly. See also the corresponding sections for [PositionalAudio] and [Overlay].").Add();
            Feature("[Client] implement lock file mechanism for Windows").Commits("d0ced447").Add();
            Feature("[User][Removed] Drop support for external images.", "Loading external images without a proxy (e.g. through the server) is a privacy concern, amd less control over what is downloaded. By using external links users could have been tracked.<br>The external images were never add-able in the Send Text Message dialog directly, only through opening its source tab and manually adding html img tags.<br>Sending message-embedded images continues to work.<br>In the future support for external images may be added again, but only with an adequate proxying of images (e.g. the server loads them and provides them to users to protect them).").Commits("31254397").Add();

            Feature("[User][PositionalAudio] Add x64 (64 bit) support").Commits("a0247d71", "19efac30", "51af7852", "f28e9b73", "f63d834c", "ee1a6718", "30ec38da", "b96bd072", "769855b4", "9345abed", "ec3120c1").Add();
            Feature("[User][PositionalAudio] Linux").Commits("2396a998", "d364932d", "4efd506a", "de1d9834", "a235d1a6", "58a7ff54", "f064a8d0").Add();
            Feature("[User][PositionalAudio] Sub Rosa").Commits("c86ce478", "e51921e6").Add();
            Feature("[User][PositionalAudio] Quake Live").Commits("4f7af504", "3a9edb87", "2c659531", "47a6e322", "ccb1ff70", "6f1b8517", "d21de05d", "c738f7b7", "bbceaa6f", "cb8cbd04").Add();
            Feature("[User][PositionalAudio] GTA V").Commits("f38363f2", "44ea8c86", "f4ca0cf2", "046e0ca2", "48ad19e4", "d7b26dd9", "501651b1", "69defe51", "234cbddc").Add();
            Feature("[User][PositionalAudio] Final Fantasy XIV").Commits("8bbb34d7", "0bc6d7d4", "acd664a0").Add();
            Feature("[User][PositionalAudio] Battlefield1").Commits("c1cd99e7", "e9a34bdf", "30c779ca", "c553e046", "4d3d4d86", "50540fdc", "46fb4054").Add();
            Feature("[User][PositionalAudio] Battlefield2: Support ingame squad and voice status identity").Commits("ffa3be97").Add();
            Feature("[User][PositionalAudio] Rocket League").Commits("80d03543", "95b3cc16", "ff09c041", "68606fee", "6a782176", "fbf7900d", "fe3ec08f", "89b0f31c", "6bad7ae4", "e8849a4f", "549197aa", "5e73de90", "208ff152", "1971dd0d", "043a7d7a", "6f843e5e", "3eec33ae", "eb0a2a0f", "48cc538b", "3e1d7ed9").Add();
            Feature("[User][PositionalAudio] Battlefield 4").Commits("a30f1dd4", "d157e718", "691d80ae", "bed423ea", "38dbec19", "e7e61970", "e4c91e2a").Add();
            Feature("[User][PositionalAudio][Removed] Removed Star Wars Online support due to lack of maintainer").Commits("9de6718d").Add();

            Feature("[User][Overlay] Support DirectX 11").Commits("405d6e43").Add();
            Feature("[User][Overlay] Support Clock in Overlay").Commits("5c87dedd", "63e3fd03").Add();
            Feature("[User][Overlay] Configurable FPS and clock position").Commits("8bf9b0a1").Add();
            Feature("[User][Overlay] Add overlay launcher filter").Commits("b1b3d4f5", "2968a92b", "c1e9102c", "b1880294", "57740e7e", "6c446e4e").Add();
            Feature("[User][Overlay] Simultaneous x86 and x64 process support").Commits("3a6c4f0f", "9f1e6050", "cf51bf3b", "93ad74b4", "529f76f4", "d6098796", "8e31de78", "56e7e5a6", "0e358bff", "3018c5e9", "14ac2b36").Add();
            Feature(@"[User][Overlay] Make ""no-overlay"" option available also on Windows").Commits("e42e6ca9").Add();
            Feature(@"[User][Overlay][Removal] Remove usable Mumble client in Overlay").Commits("4f87be8a", "ad6acf22").Add();

            Feature("[User][Settings] Add various configurable message types").Commits("f0fc66b6", "91f5e1cb", "6ed06bdd", "46cb8a37", "07a142d1", "651e4d0d", "2ad8c651", "1098afcc", "07c8e00e").Add();
            Feature("[User][Settings] Add per-message-type setting to toggle window highlight (if not active)").Commits("ce8fd36d").Add();
            Feature("[User][Settings] Drop expert mode", "The expert mode in configuration was initially introduced to make the settings easier and clearer to read, while allowing more proficient users to show all settings.<br>However hidden settings can be confusing and hard to discover. When supporting our users we often had to tell them to enable expert mode for more information or to configure something. This was of course not the intention of it.<br>We decided to drop expert mode in favor of a unified experiance and all options visible. To improve the user experience the layout of the settings themselves should be improved.").Commits("4090c212", "b16983f3").Add();
            Feature("[User][Settings] Configure user dragging (like channel dragging)").Commits("ddd47649").Add();
            Feature("[User][Settings] Configurable input channel mask for selecting which mic channels should be mixed").Commits("4481729e").Add();
            Feature("[User][Settings] Settings: expose 'wasapi/role' setting to allow users to set WASAPI role", @"See <a href=""https://docs.microsoft.com/en-us/windows/win32/coreaudio/device-roles"">upstream Device Roles documentation</a>").Commits("d66eeebe").Add();
            Feature("[User][GUI] Allow hiding Muble from the menu without minimizing").Commits("bf90fadd").Add();
            Feature(@"[User][Audio] Support machine learning noise suppresion <a href=""https://people.xiph.org/~jm/demo/rnnoise/"">RNNoise</a> (Xiph)").Commits("e54f60f4", "17816971", "e3ad9552", "f6a6b661").Add();
            Feature(@"[User][Audio] Support <a href=""https://en.wikipedia.org/wiki/JACK_Audio_Connection_Kit"">JACK</a> audio interface").Commits("1bf549d6", "08d9b9c7", "09c71b4d", "d3cf441c", "d7378675").Add();
            Feature("In certificate information dialog show SHA-256 fingerprint as well").Commits("a297a24b", "4f4e5ac2").Add();

            Feature("[Linux] Support logging to <b>syslog</b>").AnyWord("syslog").Commits("08d7cb3a").Add();
            Feature("[Admin T1] Per channel user limit").Commits("84b1bcec", "c0879e57", "0b0c074d", "fea39f20").Add();
            Feature("[Admin T1] Configurable max channels per server").Commits("23eb3d17").Add();
            Feature("[Admin T1] Show ban message when someone bans").Commits("c522cff0").Add();
            Feature("[Admin T2] Support disabling SuperUser login", "SuperUser is the initial and fallback administration account every server (and vserver) has. After the password has been set it can not be unset to disable login. This prevents the potential attack surface of the account. If necessary the a password can be generted or set again to be able to use it again.").Commits("f990b90d", "aaf36667", "708ace45").Add();
            Feature("[Admin T2] Human readable passwords", "Depending on the font some characters may look very simlilar and consequently are hard to identify by users (for example 1 and l). By excluding ambiguous characters we generate passwords that cause less frustration in those cases.").Commits("9ae2a7f5").Add();
            Feature("[Admin T2] Support systemd").Commits("57396fac", "6db171ef").Add();
            Feature("[Admin T2][SSl] Configurable cipher suites", "Add 'sslCiphers' option to allow server admins full control of Murmur's advertised TLS cipher suites").Commits("a3f93f78", "8ae710b5").Add();
            Feature("[Admin T2][SSL] Configurable Diffie-Hellman parameters").AnyWord("Diffie-Hellman").Commits("4795ae57").Add();
            Feature("[Admin T2][Server] Support PostgreSQL (Only sqlite remains the strictly supported and recommended one. This is secondary support like MySQL.)").Commits("9be606ef").Add();
            Feature("[Admin T2][Server] Support SQLite WAL").Commits("cad1bac3").Add();
            Feature("[Admin T2][Server] Optionally hide OS information from server (“privacy mode”)").Commits("65909b89").Add();
            Feature("[Admin T2][Server] Support for SRV DNS entries").Commits("48f3eb94").Add();

            Feature("[Admin T3] CLI RPC").Commits("bc5852d3", "b928c047").Add();
            Feature("[Admin][GRPC] Add support for GRPC (Remote Procedure Call API for scripting the server)(CURRENTLY DISABLED)", "While the Mumble server can be built with it, the default and provided binaries do not have it enabled yet.")
                .AnyWord("grpc")
                .ContainsAny("gRPC", "GRPC")
                .Commits("765f7807", "41502bb8")
                .Add();
            Feature("[Admin T3] Add “forceExternalAuth” config option to Murmur").Commits("dc3b78c9").Add();

            Feature("[Dev][Docs] Replace docs folder with Protocol Documentation", "The protocol documentation is for anyone trying to communicate with Mumble clients or servers through network packets (rather than through the available APIs).")
                .Commits("6eecd624", "eda74f21")
                .AnyWord("protocol documentation")
                .Add();
            Feature("Use PBKDF2 for user password hashing").Commits("88cf21d6", "15072a45").Add();
            Feature("?TODO [Code] Introduce app and exe separation").Commits("f62db492", "7f976ed1", "b90b4200", "4de645c2").Add();
            Feature("[Dev][MinGW] Support MinGW environment for compilation").AnyWord("MinGW").Add();
            Feature("[Dev][Build] Add Docker image build file").Commits("cbbc3425").Add();
            Feature("[Dev][Build] Provide AppImage (portable software package technology on Linux)").Commits("83bca04f").Add();
            Feature("[SSL][Linux] Support handling multiple OpenSSL versions at the same time").Commits("13bc12d3", "5b82a7a4").Add();

            Feature("Various Features")
                .Commits("6c096c31"
                    , "9be606ef"
                    , "f3a1a6c7"
                    , "012cde52"
                    , "6ac0553a"
                    , "bf90fadd"
                    , "cad1bac3"
                    , "65909b89"
                    , "4481729e"
                    , "d66eeebe"
                    , "3eae0dc6"
                    , "755c2905"
                    , "fd5a9b12"
                    , "6a345f54"
                    , "a5651973"
                    , "44dc94e9"
                    , "80f1623b"
                    , "5b104e09"
                    , "82c27fef"
                    , "76b95d1a"
                )
                .Add();
        }

        private static void DefineImprovements()
        {
            Improvement("[Translation] Translation updates")
                            .AnyWord("translation", "Translation", "translations", @"\.ts", "MumbleTransifexBot")
                            .Commits("52272e28", "de2e0868", "f1eb6425", "e6ac067c", "bc012541", "ce413bd9", "3223c8aa")
                            .Add();
            Improvement("[Settings] Open sound file selection dialog with current path").Commits("7c2d1a3f").Add();
            Improvement("XInput").StartsWithAny("XInput").AnyWord("XInput").Add();
            Improvement("[Accessibility] Improve minimal mode window").Commits("47a81f7b").Add();
            Improvement("[GUI] Various GUI improvements").Commits("c2be406a", "10abf369", "be4ae5b2", "4a99cde5", "46462cd7", "80602a3e", "455ab192", "a4e859e7").Add();
            Improvement("[GUI] CertWizard: Password requirement notice on import").Commits("8f94c763").Add();
            Improvement("[Settings] Show language code in language selection").Commits("2438f31e").Add();
            Improvement("[User][Text-to-Speech] Unix: Use Mumble's language setting, or the system locale for TTS language").Commits("1aae05eb").Add();
            Improvement("[Overlay] Change default overlay avatar alignment to centered").Commits("ed2bf499").Add();
            Improvement("[Overlay] Overlay blacklist default rules").Commits("207f66ce", "2c0c0edd", "e5b6dac2", "f1dbd922", "7f69c512", "df448598", "f732ec4c", "31abc89c", "ef72e3ea", "95222b96", "6e820e8d", "623d2afa", "b7ad9d66", "623d2afa", "b7ad9d66", "15d18eea", "14648736", "248859cf").Add();
            Improvement("[Overlay] Various improvements").Commits("fd782c3c", "8e333b31", "bb0ccc46", "950fa156", "82ca8008").Add();
            Improvement("[PositionalAudio] ").Commits("398b7733", "95214713", "fb1cff62", "5e7706ab", "b0ddb592", "54d3f5a0").Add();
            Improvement("[PositionalAudio] ").Commits("f836ed42", "a3275f57", "730200a9", "61ad05c9", "9f6c08b2", "05cc7e33", "c8d136fe").Add();
            Improvement("[PositionalAudio] ").Commits("0556b6c2", "2733fed4", "0785dea6", "fb3d6c64", "d2a1b5ca", "263607f5", "8ab0c4a6", "b9baebbb", "82f95c63").Add();
            Improvement("[PositionalAudio] ").Commits("a935808b").Add();
            Improvement("[PositionalAudio] ").Commits("f2bfe2f7", "8017a01b", "db12479e").Add();
            Improvement("[PositionalAudio] ").Commits("47d8a4f2").Add();
            Improvement("[Admin T1] Userlist improvements", "Improved UI, search functionality, multi-select, last-seen, inactive-for-timespan filter, live user renames, ").Commits("c40b0b00", "02ddd914", "d19e266f", "cde56107", "51ecb7a3").Add();
            Improvement("[Admin T1] Allow admins to clear user avatars/textures.").Commits("52d19ac3").Add();
            Improvement("[Admin T1][Banlist] Improvements").Commits("bf5927ee", "ac65b31a", "afa6ee4c").Add();
            Improvement("[Admin T3]").Commits("7cff8ca5").Add();
            Improvement("[Admin T3][SocketRPC]")
                .AnyWord("SocketRPC")
                .Add();
            Improvement("[Admin T3][Ice]")
                .AnyWord("Ice", "ice", "MurmurIce")
                .Commits("b595d650")
                .Add();

            Improvement("[installer]")
                .AnyWord("installer")
                .Commits("9f5b01b9", "fcc2a390", "e7282052")
                .Add();

            Improvement("[Dev][Protobuf]")
                .Commits("4fe07a50")
                .Add();
            Improvement("[Opus]")
                .AnyWord("Opus", "opus")
                .Add();
            Improvement("[Bonjour]")
                .AnyWord("Bonjour", "bonjour")
                .Add();
            Improvement("[OSInfo]")
                .StartsWithAny("OSInfo")
                .Add();

            Improvement("Various Documentation Improvements")
                .Commits("83da4f17"
                    , "77b59e5d"
                    , "d793aa11"
                    , "7d4fe6cc"
                    , "a69916bc"
                    , "948331ee"
                    , "df8b774f"
                    , "3e0112da"
                    , "9cc1c0a7"
                )
                .Add();

            Improvement("[User] Improve Connect Dialog").Commits("3c280a66", "71ff77b2", "b2282e74", "4e459a9b", "ab78e6c9", "7fbe61e5", "08af66d5", "66f5ae91", "78d0db8d").Add();
            Improvement("[User][UI] Various Mumble client UI improvements").Commits("b9815665", "dd7cc7ca", "d9d81a99", "d3e00dee", "b2d938ba", "d58990c3", "1375022b", "754fc008", "d9785f9f", "44a08461", "ad19d157", "9ba92b58", "f5affcd4", "67ed33f3", "e8027bd6", "8e195e17", "21cd4ddc", "c1b6110b", "9e8a40f6", "b5825472", "b83316ad", "25ceebb3", "69cdaee4", "e6cde15c", "4add9cec", "153c0aa9", "b5aef4ca", "fa818bdf", "cb952e06", "dbab0f70", "871240e7", "4e430f74", "5c9a46e9", "6cd17bdc", "a1899695", "26c732fb", "9b19e609", "4c82dd5e").Add();
            Improvement("[Admin T1][UI]").Commits("f07f0c86").Add();
            Improvement("[Server]").Commits("4862897a", "97cf80de", "33f8448d", "703f8c7f", "0d76ff92").Add();
            Improvement("Technical changes").Commits("925587af", "b7d9387b", "b422e0a9", "d299360f", "76475381", "445cdf0e", "2c0d37f9", "de27cd7b", "b4d48ef4", "f32343d5", "a2e6cb8c", "cd8fbbdc", "a50a120b", "a1a969e7", "b2e37e68", "65c25009", "6aba9842", "2c24ee0f").Add();
            Improvement("App metadata").Commits("1eefaab0", "2d6e099d").Add();
        }

        private static void DefineFixes()
        {
            Fix("[User][Text-to-Speech] Mac OS-X").Commits("15f76107", "c2f75bbd", "1bd57bd0").Add();
            Fix("[User][Text-to-Speech]").Commits("d3470c30").Add();
            Fix("[User][Recorder] Various recorder fixes").Commits("9a47e050", "2ca559b2", "fc4e1e3b", "8e22f9a2", "fc0e20bb", "329dd4ee", "1c00533b", "4c48f72f").Add();
            Fix("[User][Overlay] Various fixes").Commits("03258363", "10b2d000", "07e055ff", "6e9a7e7c", "3282887f", "da004cf8", "ad1ed221", "b0705324", "ab12d356", "fb56112d", "06e19e6f").Add();
            Fix("[User][UI] Various Mumble client UI fixes").Commits("6e09508e", "5b9e899c", "a6f76100", "75976ec2", "12eac3c6", "13c6e582", "12563866", "2b8fc35f", "f1e3e096", "edaca2ea", "7c4fbee2"
                , "dc87fa23", "cde294f3", "f35ef659", "78d71984", "70451a60", "db4a591c", "97c34f4c", "909c13c5", "549c1551", "5b3a406f", "d2943a5f", "5f43f651", "01a7c583", "f2840525", "13772c13"
                , "fc13fd1c", "ec254df1", "16810dd5", "adcf9fea", "1a95cff6", "15f268cf", "6e709998", "c49301b0", "4e839139", "ed424afa", "ea165cde", "abad339f", "73a1a98d", "8ad8812b", "916dcc0c"
                , "491789c2", "78604d85", "a1ff21bd", "ebf6d23f", "2612b67d", "6fe55478", "612d6b52", "23fa9b39", "779496c5", "b126c4e2", "c45298e4", "06d3785a", "27189b63", "eb63d0b1", "4566f092"
                , "b25db3e1", "86197ff2", "d7ef5178"
            ).Add();
            Fix("[PositionalAudio] Fix double free in WASAPI no positional audio fallback code-path").Commits("fca62787").Add();
            Fix("[PositionalAudio] 'manual' plugin on OS X with Qt 5").Commits("e0b884e6", "be75138d", "3cc24199").Add();
            Fix("[GUI] OS-X styling issues").Commits("66d41efd").Add();
            Fix("[G15] ").Commits("b2f2277d").Add();
            Fix("[G15] Disable G15", "We see a lot of crashes but have no testers and no way to debug/fix the issue for now").Commits("1974ac0f").Add();
            Fix("[Admin T1] Various admin fixes").Commits("44f1055d").Add();
            Fix("[Admin T2] Configurable message flood protection").Commits("44b9004d", "f7221c14", "b44b1f21").Add();
            Fix("[Server] Various server fixes").Commits("58c06f26", "4a67eebc", "7c5a9fb3", "c3236b30", "d39e7739", "d110e564", "f5e03d6c", "bd8f92b9", "fd9c7941", "c3e29055", "1a1bd8c1", "16c1145b").Add();
            Fix("Technical fixes").Commits("26829872", "b4f50507", "e934c1e6", "81698118", "0840dd45", "af38fdb8", "aa90739b", "6195761d", "77233edf", "860ec5c7", "01a5e83b", "8aa2558e", "147be101", "b347f7e7", "ba1a1897", "4bae627e", "0763a3dc", "d15c3f90", "c93b087c", "63f35d6a").Add();
        }

        private static void DefineCode()
        {
            Code("[PositionalAudio]").Commits("a0247d71", "ec3120c1", "ec87aa6b", "44ea8c86", "a3275f57", "c9814aed").Add();
            Code("[Overlay][Temporary]").Commits("2f07778", "8f65051f").Add();
            Code("[Overlay] Various Changes")
                .Commits("0abf7e3c", "14db2e9e", "cab4a3d8", "04b344dc", "3865e8ca", "dfc86384", "123486b4", "1182fc26", "b0705324", "e64fa103", "0e7d8609", "3c787be1", "9d0de38a", "1919b2cd"
                    , "f789386b", "2e5c8a57", "2bc61db6", "3fe7ff4c", "2c0bfa0b", "3b507d57", "967a3251", "1fab580b", "8d3c1f7f", "fcb908b7", "147be101", "c25da2c9", "f5d72ba3", "8eec7cc1"
                    , "a9785932", "bed08691", "2667fe41", "b47b1dac", "087e38a2", "ab12d356", "487fcab9", "840a31de", "06d00f4a", "403aedb3", "8e3168b2", "f4568b9e", "f0ff84f6", "f8b63cd5"
                    , "5d41a786", "b29df64a", "9a18c77d", "2379f1fa", "d63fc6d3", "a66fdeb2", "859da4da", "4fe16648", "66ff6d6d", "e0cb6e01", "e4c80dac", "f931ef1c", "3a356a2a", "5f79a3e4"
                    , "a3e7958f", "114495e5", "53a529cb", "3763d596", "557dbae4", "dce83ca9", "52a76244", "85409667", "f35d0cb9", "238618d3", "3b53aad5", "a0178103", "dd147960", "380cd6bb"
                    , "feb2b21f", "a08c509d", "348d4570", "ea5c0381", "24e437c6", "771657ac", "834365e2"
                )
                .Add();
            Code("[Text-to-Speech] Implement optional QtSpeech-based text-to-speech backend").Commits("b9165ae0").Add();
            Code("[PositionalAudio] add magic values for all previously supported ABIs").Commits("9f327bee").Add();
            Code("[PositionalAudio] Various code changes").Commits("6a2f2bd8", "a20185de", "95214713", "fb1cff62", "ee432795", "47a6e322", "ccb1ff70", "6f1b8517", "bed423ea", "38dbec19", "dab868e6"
                , "b20d9e94", "f657478f", "7a82dc9a", "6be0de43", "48cc538b", "b82b6eb6", "e83d01c7", "fba1d65b", "28bb66e0", "e31b7165", "f3c64b38", "370fae6b", "c9814aed", "f735a632", "308e4f72"
                , "e9c558ff", "e2ad9c05", "c936b99d", "53daac83", "ace19170", "82a8e7de", "fc0ab935", "6e2f7102", "173aa7df", "ee432795"
            ).Add();
            Code("[Code] Copyright, licenses and authors", "Updates to copyright notices and authors")
                .AnyWord("LICENSE")
                .Commits("7a333184", "6e165025", "4b3746ab", "999b59b8", "3434ff89", "37c4749e", "2c2744ea", "80b8e3cf", "dd874ccd", "a2be9156", "486381c9", "c59ca21c", "45ad52f1", "cb5e34f9"
                    , "ac9fa648", "3ffd9ad3", "4976c1ad", "73fe4578", "bc5056cf", "50bc11d0", "a2b7020f", "52f385ce", "acfa0444", "e399de75", "a9384f11", "96d87db4", "2fd6a3cc", "a2be9156"
                )
                .Add();

            Code("[Build Infrastructure]")
                .AnyWord("scripts", @"\.pro", "buildenv", "travis-ci", "Travis-CI", "travis", "appveyor")
                .Commits("17cdab70", "8c149069", "7d649aa5", "d74b5b04", "82fa0e60", "c03d8fcc", "b2529590", "53daac83", "9946dc75", "e562e92e", "a429c763", "630a17ba", "0fdb7c17", "fa98f6d6"
                    , "d4c8abd2", "11b5c285", "e03989ec", "a8d8c136", "c19ac8c0", "ca8f3dd4", "a3187870", "a8d8c136", "fc1af7a1", "031abd01"
                ).Add();
            Code("[Tests]")
                .StartsWithAny("src/tests", "tests/", "Test")
                .AnyWord("OverlayTest", "tests")
                .Commits("fdd837c1", "9e6e6bb6")
                .Add();
            Code("[Infrastructire] Use our own domain for service endpoints").Commits("9db30159", "bd49fa59", "17ddc1a3", "4ed7af93", "acb69be2").Add();
            Code("Qt 4")
                .AnyWord("Qt 4", "Qt4")
                .Commits("1c1dac5e", "ef9ffea5", "46fc40e1", "487e032d", "3283ac2f", "d22a797a")
                .Add();
            Code("[Qt 5]")
                .AnyWord("Qt 5", "Qt5")
                .Commits("6f2552de", "ef6353bf", "d855b67d", "9a426b1d", "c84916f9", "84a8bbcc", "841bff8b", "26b05974", "2bc61db6", "19996c53", "78ac4688", "7e4639c5", "ebbac0bb", "cb1732b6", "c84af26e", "d5600562")
                .Add();
            Code("[Shortcut]")
                .StartsWithAny("GlobalShortcut", "GlobalShortuct")
                .AnyWord("GlobalShortcut", "Shortcut", "shortcut")
                .Commits("8a1e0e85", "ecf543b2", "0dcbf542", "5e005a7c")
                .Add();
            Code("[G15 LCD]").StartsWithAny("G15").AnyWord("LCD", "G15", "g15helper").Add();
            Code("[SSL]")
                .ContainsAny("OPENSSL")
                .AnyWord("SSL", "ssl", "sslCiphers", "sslciphers", "SSLCipherInfo", "lssl", "OpenSSL", "QSslSocket", "QSslSocket", "SSLCipherInfoTable", "OPENSSL")
                .Commits("7141a05c")
                .Add();

            Code("[3rdparty]")
                .ContainsAny("3rdparty")
                .Add();
            Code("[Hardening] Hardening against accidental or deliberate misuse, security hardening")
                .Commits("b6e17cac", "9837c4dc", "17fa695b", "d9ff1e94", "527d24ed", "e438a05f", "e740ea5e", "996a3df4"
                , "73a1a98d"
                , "fc24262f"
                )
                .Add();
            Code("[Code] Fix warnings").Commits("3af16511", "2c892fee", "5acf4af5", "d3d6920d", "51ab40a4", "8ecc3d1e", "e21ce495", "7b882d0b", "68205b93", "39b8b07b", "66ff6d6d", "f9b2db45"
                , "e0cb6e01", "c9c9d0e7", "648f35b0", "b828a0a3", "e4c80dac", "671598b7", "86824a3c", "dd147960", "51bb441c", "76d2ea20", "c495c579", "ec07f61b", "708212ab", "306e1f7a", "a8bed298"
                , "159aad4f", "2757a0c2", "5f79a3e4", "c9814aed", "81b00bfc"
            ).Add();
            Code("[Code] Various code fixes").Commits("2c0bfa0b", "d6ba8cf0", "9f1b01a4", "4c16f25b", "a5009b64", "10c902fa", "234ed23a", "3206530f", "5fb25734", "1070b402", "53107ca4", "68547c9a"
                , "93427aff", "daba32f6", "fcd2de6a", "72cd86c9", "cffa565d", "173aa7df", "94b05db3", "e2ad9c05", "b466faae", "8a10b932", "43109d10", "4eef649e", "5a31a63a", "905461f8", "50fc0ca7"
                , "2667fe41", "8758cf5a", "e414bd3b", "1b2b642f", "54895649", "5a5a3b27", "176c041c", "4411059e", "1b203cdc", "1273ba90", "5039340a", "c38d77e0", "cc0533c6", "99f3de86", "6b7dfc72"
                , "14597920", "11d5305f", "f09e943b", "4bbc5611", "c4691048", "1509f564", "f623a695", "487fcab9", "2d2509f9", "e31b7165", "50206cee", "800947ee", "68fb468b", "e848e562", "f1e298aa"
                , "263a2928", "13e494c6", "a7e7e1b0", "c25da2c9", "80e0f961", "f56143f9", "514100d4", "150d0966", "f44b7df8", "37618b77", "4e53e6f8", "e174f8de", "23b4e859", "04b2635d", "e5d365e5"
                , "6902b222", "6130b349", "a08c509d", "afd86cf9", "3315e01e", "90a904db", "9ff780b5", "742a5d98", "c176974e", "1fb1e9c0"
            ).Add();
            Code("[Code] Various code changes and improvements")
                .Commits(CodeChanges)
                .StartsWithAny("Bump version")
                .ContainsAny("QT_", "Q_")
                .AnyWord("submodule", "build", @"compiler\.pri", "header guard", "refac", "Refac", "refacs", "Refactor", "Refactoring", "guard define", @"\.pri", "qmake", "LICENSE", "license", "CHANGES", @"C\+\+11")
                .Commits("00392d1a", "4efabcea", "6095134b", "a7d103f6", "f05e6571")
                .Add();
        }

        private static Builder Feature(string title, string? description = null) => Item(Category.Features, title, description);
        private static Builder Improvement(string title, string? description = null) => Item(Category.Improvements, title, description);
        private static Builder Fix(string title, string? description = null) => Item(Category.Bugfixes, title, description);
        private static Builder Code(string title, string? description = null) => Item(Category.Code, title, description);
        private static Builder Item(Category category, string title, string? description) => new Builder(category, title, description);

        private class Builder
        {
            private readonly Category Category;
            private readonly string Title;
            private readonly List<ISelector> Selectors = new List<ISelector>();
            private readonly string? Description;

            public Builder(Category category, string title, string? description)
            {
                Category = category;
                Title = title;
                Description = description;
            }

            public Builder Commits(params string[] hashes) { Selectors.Add(new CommitSelector(hashes)); return this; }
            public Builder Matches(params ISelector[] selector) { Selectors.AddRange(selector); return this; }
            public Builder AnyWord(params string[] words) { Selectors.AddRange(words.Select(word => new Selector(SelectorType.ContainsWord, word))); return this; }
            public Builder StartsWithAny(params string[] words) { Selectors.AddRange(words.Select(word => new Selector(SelectorType.StartsWith, word))); return this; }
            public Builder ContainsAny(params string[] words) { Selectors.AddRange(words.Select(word => new Selector(SelectorType.Contains, word))); return this; }
            public void Add() => Groups.Add(new ItemMeta(Title, Category, Description, Selectors.ToArray()));
        }
    }
}
