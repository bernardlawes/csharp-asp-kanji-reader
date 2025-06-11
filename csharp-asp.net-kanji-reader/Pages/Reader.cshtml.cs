using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using csharp_asp.net_kanji_reader.Dictionary;
using System.Text;

public class ReaderModel : PageModel
{
    private static JMDictParser _parser;

    [BindProperty]
    public string InputText { get; set; }

    public string OutputHtml { get; set; }

    static ReaderModel()
    {
        _parser = new JMDictParser("Data/JMdict.xml");

    }

    private bool ContainsKanji(string text)
    {
        foreach (char c in text)
        {
            if (c >= '\u4E00' && c <= '\u9FAF') // CJK Unified Ideographs
                return true;
        }
        return false;
    }

    public void OnGet() { }

    public void OnPost()
    {
        if (string.IsNullOrWhiteSpace(InputText)) return;

        var output = new StringBuilder();
        int i = 0;

        while (i < InputText.Length)
        {
            int maxMatchLen = 0;
            JMDictEntry? bestEntry = null;

            // Try longest substrings first (up to 10 characters)
            for (int len = Math.Min(10, InputText.Length - i); len > 0; len--)
            {
                var sub = InputText.Substring(i, len);
                var entry = _parser.Lookup(sub);

                if (entry != null && entry.Readings.Count > 0)
                {
                    bestEntry = entry;
                    maxMatchLen = len;
                    break;
                }
            }

            if (bestEntry != null)
            {
                var word = InputText.Substring(i, maxMatchLen);
                var reading = bestEntry.Readings.First();

                if (ContainsKanji(word))
                {
                    output.Append($"<ruby class=\"with-ruby\">{word}<rt>{reading}</rt></ruby>");
                }
                else
                {
                    output.Append(word); // It's kana only — output raw
                }

                i += maxMatchLen;
            }
            else
            {
                var currentChar = InputText[i].ToString();

                if (ContainsKanji(currentChar))
                {
                    output.Append($"<span class=\"unmatched\" title=\"Not found in dictionary\">{currentChar}</span>");
                }
                else
                {
                    output.Append(currentChar);
                }

                i++;
            }
        }

        OutputHtml = output.ToString();
    }


}
