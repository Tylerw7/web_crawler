# 🕷️ C# Web Crawler (Console App)

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=for-the-badge&logo=mongodb&logoColor=white)
![Async](https://img.shields.io/badge/Async%2FAwait-007ACC?style=for-the-badge)
![HTML Parsing](https://img.shields.io/badge/HTML%20Parsing-FF6F00?style=for-the-badge)

A **multi-page web crawler** built as a **C# .NET console application**.  
It crawls websites starting from a seed URL, extracts page content and links, and stores the results in **MongoDB**.

This project was built to **deeply understand how web crawlers work**, including concurrency, async pipelines, HTML parsing, and persistence — not just to scrape data.

---

## ✨ Features

- 🚀 Asynchronous crawling using `async/await`
- 🔗 URL queue with duplicate prevention
- 🌐 Relative + absolute URL normalization
- 🧠 In-memory visited set (hash-based)
- 📄 HTML parsing (title, body content, links)
- 🗄️ MongoDB storage for crawled pages
- 📊 Crawl limits (max pages)
- 🧪 Designed for learning & extensibility

---

## 🧠 How It Works (High-Level)

1. **Seed URL** is added to a queue
2. The crawler:
   - Fetches the page HTML
   - Parses links and text content
   - Normalizes relative URLs
   - Avoids revisiting already crawled pages
3. Parsed pages are stored in MongoDB
4. Crawling continues until:
   - The queue is empty **or**
   - The max page limit is reached

---

## 📁 Project Structure

ConsoleApp1/
├── Program.cs # App entry point
├── Crawler/
│ └── WebCrawlerEngine.cs # Core crawling logic
├── Data/
│ ├── Database.cs # MongoDB connection & inserts
│ └── Webpage.cs # Webpage data model
├── Utils/
│ └── UrlNormalizer.cs # Relative → absolute URL handling
├── .env # MongoDB connection string
├── ConsoleApp1.csproj
└── README.md




---

## 🛠️ Technologies Used

- **C#**
- **.NET (Console App)**
- **MongoDB & MongoDB.Driver**
- **HtmlAgilityPack**
- **Async/Await**
- **DotNetEnv** for environment variables

---

## ⚙️ Setup & Installation

### 1️⃣ Clone the repository
```bash
git clone https://github.com/yourusername/csharp-web-crawler.git
cd csharp-web-crawler


dotnet restore

MONGODB_URI=mongodb+srv://<username>:<password>@cluster0.mongodb.net/?appName=Cluster0


dotnet run

{
  "Url": "https://example.com/about",
  "Title": "About Us",
  "Content": "We are a company that..."
}



