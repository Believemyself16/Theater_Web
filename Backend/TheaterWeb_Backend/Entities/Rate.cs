namespace Movie_Web.Entities {
    public class Rate {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
