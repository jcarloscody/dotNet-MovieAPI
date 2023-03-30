using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs.Movie;

public class UpdateFilmeDto
{
    [Required(ErrorMessage = "Necessita por o Título")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(100, ErrorMessage = "O tamanho ñ pode exceder a 100")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "Obrigatório por a duração")]
    [Range(60, 180, ErrorMessage = "Fora do range")]
    public int Duracao { get; set; }
}
