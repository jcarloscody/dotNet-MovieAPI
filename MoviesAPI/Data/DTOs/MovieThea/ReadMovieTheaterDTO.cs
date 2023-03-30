using MoviesAPI.Data.DTOs.Address;
using MoviesAPI.Data.DTOs.Session;

namespace MoviesAPI.Data.DTOs.MovieThea
{
    public class ReadMovieTheaterDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDTO Endereco { get; set; }
        public ICollection<ReadSessionDTO> Sessoes { get; set; }
    }
}
