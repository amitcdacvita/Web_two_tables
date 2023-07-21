namespace Web_two_tables.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}
