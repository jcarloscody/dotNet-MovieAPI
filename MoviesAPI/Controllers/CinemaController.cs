using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Data.DTOs.MovieThea;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController  : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateMovieTheaterDTO cinemaDto)
        {
            MovieTheater cinema = _mapper.Map<MovieTheater>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.Id }, cinemaDto);
        }

        [HttpGet]
        public IEnumerable<ReadMovieTheaterDTO> RecuperaCinemas([FromQuery] int? enderecoId = null)
        {
            if (enderecoId == null)
            {
                return _mapper.Map<List<ReadMovieTheaterDTO>>(_context.Cinemas.ToList());
            }
            return _mapper.Map<List<ReadMovieTheaterDTO>>(_context.Cinemas.FromSqlRaw($"SELECT Id, Nome, EnderecoId FROM cinemas where cinemas.EnderecoId = {enderecoId}").ToList());
        }


        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            MovieTheater cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadMovieTheaterDTO cinemaDto = _mapper.Map<ReadMovieTheaterDTO>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateMovieTheaterDTO cinemaDto)
        {
            MovieTheater cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            MovieTheater cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
