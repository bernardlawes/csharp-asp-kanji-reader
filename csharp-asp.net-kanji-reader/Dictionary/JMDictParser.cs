/*namespace csharp_asp.net_kanji_reader.KanjiReader.Dictionary
{
    public class JMDictParser
    {
    }
}
*/

// Basic JMDict parser for ASP.NET Core project
// Focuses on reading kanji + reading pairs and definitions

using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csharp_asp.net_kanji_reader.Dictionary
{
    public class JMDictEntry
    {
        public List<string> Kanji { get; set; } = new();
        public List<string> Readings { get; set; } = new();
        public List<string> Glosses { get; set; } = new();
    }

    public class JMDictParser
    {
        private readonly Dictionary<string, JMDictEntry> _entries = new();

        public JMDictParser(string jmdictPath)
        {
            LoadEntries(jmdictPath);
        }

        private void LoadEntries(string path)
        {
            var doc = XDocument.Load(path);

            foreach (var entry in doc.Descendants("entry"))
            {
                var kanjiElems = entry.Elements("k_ele").Elements("keb").Select(k => k.Value).ToList();
                var readingElems = entry.Elements("r_ele").Elements("reb").Select(r => r.Value).ToList();
                var glosses = entry.Elements("sense").Elements("gloss").Select(g => g.Value).ToList();

                // Pick primary string to index by (kanji or reading)
                var key = kanjiElems.FirstOrDefault() ?? readingElems.FirstOrDefault();

                if (!string.IsNullOrEmpty(key) && !_entries.ContainsKey(key))
                {
                    _entries[key] = new JMDictEntry
                    {
                        Kanji = kanjiElems,
                        Readings = readingElems,
                        Glosses = glosses
                    };
                }
            }
        }

        public JMDictEntry? Lookup(string word)
        {
            return _entries.TryGetValue(word, out var entry) ? entry : null;
        }
    }
}

