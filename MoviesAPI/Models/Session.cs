namespace MoviesAPI.Models
{
    public class Session
    {
        public int? FilmeId { get; set; }
        public virtual Movie Filme { get; set; }
        public int? CinemaId { get; set; }
        public virtual MovieTheater Cinema { get; set; }
    }
}
