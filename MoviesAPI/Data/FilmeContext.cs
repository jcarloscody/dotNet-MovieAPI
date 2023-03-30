using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Session>()
            .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });

        builder.Entity<Session>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);

        builder.Entity<Session>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);

        builder.Entity<Address>()
            .HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Movie> Filmes { get; set; }
    public DbSet<MovieTheater> Cinemas { get; set; }
    public DbSet<Address> Enderecos { get; set; }
    public DbSet<Session> Sessoes { get; set; }

}
