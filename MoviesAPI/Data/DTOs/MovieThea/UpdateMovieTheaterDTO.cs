using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs.MovieThea
{
    public class UpdateMovieTheaterDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Nome { get; set; }
    }
}
