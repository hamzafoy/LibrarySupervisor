namespace LibrarySupervisor.Models
{
    public class LibraryBook
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Translator { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? PublishingHouse { get; set; }
        public DateTime CreateDate { get; set; }
        public int? Edition { get; set; }
        public string Genre { get; set; }
        public int? PageCount { get; set; }
        public string ISBN { get; set; }
        public int? SeriesId { get; set; }
        public int? SeriesNumber { get; set; }
    }
}
