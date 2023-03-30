using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieTheater
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public virtual Address Endereco { get; set; }
        public virtual ICollection<Session> Sessoes { get; set; }
    }
}
