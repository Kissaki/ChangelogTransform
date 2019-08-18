using KCode.ChangelogTransform.Types;
using System.Collections.Generic;
using System.Linq;

namespace KCode.ChangelogTransform.Transformers.Mappings
{
    public static class CommitCategories
    {
        private static Dictionary<Category, string[]> CommitMapping = new Dictionary<Category, string[]>
        {
            { Category.Features, new string[] {
                "c40b0b00",
                "304bf438",
                "7c2d1a3f",
                "405d6e43",
                "52d19ac3",
                "fd5a9b12",
                "6a345f54",
                "29a65c66",
                "02ddd914",
                // syslog
                "30023c5b",
                // syslog
                "322ed8a1",
                // syslog
                "08d7cb3a",
                // syslog
                "094ab1e1",
                // disable su
                "f990b90d",
                // disable su
                "aaf36667",
                // disable su
                "708ace45",
                "f0fc66b6",
                "88cf21d6",
                "a5651973",
                "44dc94e9",
                "bc5852d3",
                "80f1623b",
                "dede3178",
                "57396fac",
                "5b104e09",
                "de27cd7b",
            } },
            { Category.Improvements, new string[] {
                "679eacd7",
                "b422e0a9",
                "f07f0c86",
                "cde56107",
                "d9d81a99",
                "3e0112da",
                "d3e00dee",
                "1eefaab0",
                "b2d938ba",
                "b7d9387b",
                "97cf80de",
                "d299360f",
                "1375022b",
                "dd7cc7ca",
                "3c280a66",
                "76475381",
                "71ff77b2",
                "d9785f9f",
                "44a08461",
                "9cc1c0a7",
                "ad19d157",
                "5a033b8b",
                "525995d1",
                "9ba92b58",
                "f5affcd4",
                "67ed33f3",
                "445cdf0e",
                "2c0d37f9",
                "b2282e74",
                "4e459a9b",
                "ab78e6c9",
            } },
            { Category.Bugfixes, new string[] {
                "77233edf",
                "ed424afa",
                "ea165cde",
                "abad339f",
                "63f35d6a",
                // VoiceRecorder
                "1c00533b",
                "78604d85",
            } },
            { Category.Hardening, new string[] {
                "b6e17cac",
                "9837c4dc",
                "17fa695b",
                "d9ff1e94",
                "527d24ed",
                "e438a05f",
                "e740ea5e",
                "996a3df4",
            } },
            { Category.BuildInfrastructure, new string[] {
                "7d649aa5",
                "d74b5b04",
                "82fa0e60",
                "c03d8fcc",
                "b2529590",
                "53daac83",
                "9946dc75",
                "e562e92e",
                "a429c763",
                "630a17ba",
                "0fdb7c17",
            } },
            { Category.Code, new string[] {
            } },
            { Category.Translation, new string[] {
                "52272e28",
                "8632246f",
                "de2e0868",
                "f1eb6425",
            } },
            { Category.PositionalAudio, new string[] {
                "398b7733",
                "61ad05c9",
                "9f6c08b2",
                "9f327bee",
                "19efac30",
            } },
            { Category.Thirdparty, new string[] {
                "3aa91793",
            } },
            { Category.Installer, new string[] {
                "fcc2a390",
                "e7282052",
            } },
            { Category.Theme, new string[] {
                "7fbd9d43",
            } },
            { Category.Overlay, new string[] {
                "0e358bff",
            } },
            { Category.ProtocolDocumentation, new string[] {
                "6eecd624",
                "eda74f21",
            } },
        };
        public static Dictionary<string, Category> CommitMappingTransformed = CommitMapping.SelectMany(x => x.Value, (x, y) => new KeyValuePair<string, Category>(y, x.Key)).ToDictionary(x => x.Key, x => x.Value);
    }
}
