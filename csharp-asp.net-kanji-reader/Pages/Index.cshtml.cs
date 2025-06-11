using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

public class IndexModel : PageModel
{
    [BindProperty]
    public string InputText { get; set; }

    public string OutputHtml { get; set; }

    public void OnGet() { }

    public void OnPost()
    {
        // Dummy example: wrap each Kanji in <ruby> tags with fake furigana
        // Replace with your real kanji + furigana logic
        if (!string.IsNullOrWhiteSpace(InputText))
        {
            OutputHtml = Regex.Replace(InputText, @"[\u4E00-\u9FAF]", m =>
            {
                var kanji = m.Value;
                var fakeReading = "ふり"; // Replace with dictionary lookup
                return $"<ruby>{kanji}<rt>{fakeReading}</rt></ruby>";
            });
        }
    }
}
