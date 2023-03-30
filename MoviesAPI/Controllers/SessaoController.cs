using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data.DTOs.Session;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessionDTO dto)
        {
            Session sessao = _mapper.Map<Session>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, sessao);
        }

        [HttpGet]
        public IEnumerable<ReadSessionDTO> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessionDTO>>(_context.Sessoes.ToList());
        }

        [HttpGet("{filmeId}/{cinemaId}")]
        public IActionResult RecuperaSessoesPorId(int filmeId, int cinemaId)
        {
            Session sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
            if (sessao != null)
            {
                ReadSessionDTO sessaoDto = _mapper.Map<ReadSessionDTO>(sessao);

                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}
