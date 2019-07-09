namespace FindBookDomain.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Specifications Specifications { get; set; }
    }
}