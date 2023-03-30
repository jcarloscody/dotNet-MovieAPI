using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs.MovieThea
{
    public class CreateMovieTheaterDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
    }
}
