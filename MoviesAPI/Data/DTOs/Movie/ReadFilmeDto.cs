using MoviesAPI.Data.DTOs.Session;

namespace MoviesAPI.Data.DTOs.Movie;

public class ReadFilmeDto
{

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    public ICollection<ReadSessionDTO> Sessoes { get; set; }

}
