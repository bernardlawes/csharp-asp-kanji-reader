# Furigana Reader 🈶📖

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
![Platform](https://img.shields.io/badge/platform-ASP.NET%20Core%20Razor%20Pages-lightgrey)
![Status](https://img.shields.io/badge/status-in%20development-yellow)

**Furigana Reader** is a web-based kanji reading assistant built with C# and ASP.NET Core Razor Pages. Paste any Japanese text and instantly view it with **furigana annotations** (readings above the kanji), rendered using semantic HTML `<ruby>` tags.

---

## 🖼 Preview

<div align="left">
  <img src="docs/preview.png" alt="Kanji Reader Preview" width="200"/>
</div>
<div align="left">
  <img src="docs/screeenshot.jpg" alt="Kanji Reader Preview" width="600"/>
</div>


---

## ✨ Features

- 📝 Paste Japanese text to get furigana annotations
- 🧠 Detects kanji using Unicode range (U+4E00–U+9FAF)
- 📚 Uses `<ruby><rt></rt></ruby>` for native furigana rendering
- ⚙️ Built in C# with ASP.NET Core Razor Pages
- 🔐 Runs on `https://localhost` with dev cert

---

## 🔧 Tech Stack

| Layer     | Technology                    |
|-----------|-------------------------------|
| Frontend  | Razor Pages, HTML5, CSS       |
| Backend   | ASP.NET Core 8.0              |
| Language  | C#, Regex, JMdict (planned)   |
| Hosting   | Kestrel / IIS Express (local) |

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022+ or VS Code

### Run Locally

```bash
git clone https://github.com/bernardlawes/csharp-aspnet-kanji-reader.git
cd furigana-reader
dotnet run


Then open:
🌐 https://localhost:5001

📅 Roadmap
 Furigana rendering via Regex + <ruby>

 JMdict-based reading lookup


📄 License
This project is licensed under the MIT License.
See the LICENSE file for details.

🙏 Acknowledgments
EDRDG for the JMdict and Kanjidic datasets

Unicode.org for kanji range references

The ASP.NET community


Built with ❤️ by Bernard Lawes for fellow Japanese learners
