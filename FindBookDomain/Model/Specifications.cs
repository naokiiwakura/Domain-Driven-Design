using System.Collections.Generic;

namespace FindBookDomain.Model
{
    public class Specifications
    {
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public List<string> Illustrator { get; set; }
        public List<string> Genres { get; set; }
    }
}