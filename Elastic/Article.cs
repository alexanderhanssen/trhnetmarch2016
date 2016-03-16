using System;

namespace Elastic
{
    internal class Article
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string[] Places { get; set; }
        public string[] Topics { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}
