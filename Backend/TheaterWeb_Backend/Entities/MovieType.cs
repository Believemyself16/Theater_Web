namespace Movie_Web.Entities {
    public class MovieType {
        public int Id { get; set; }
        public string MovieTypeName { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Movie> Movies { get; set;}
    }
}
