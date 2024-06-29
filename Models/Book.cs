namespace Electronic_Library1.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
