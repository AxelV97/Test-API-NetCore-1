using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingCore.Data;
using TestingCore.Models;
using TestingCore.DTO;
using Microsoft.EntityFrameworkCore;

namespace TestingCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly TestingCoreContext _context;
        private readonly IMapper _mapper;

        public MoviesController(TestingCoreContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Genre).
                ToList().
                Select(_mapper.Map<Movie, MovieDTO>);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetMovie(int Id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Movie, MovieDTO>(movieInDb));
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Movie movie = _mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;

            return CreatedAtAction(nameof(GetMovie), new { Id = movie.Id }, movieDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateMovie(int Id, MovieDTO movieDTO)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _mapper.Map(movieDTO, movieInDb);
            _context.SaveChanges();

            return Ok("The record was updated successfully!");
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteMovie(int Id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Remove(movieInDb);
            _context.SaveChanges();

            return Ok("The record was deleted successfully!");
        }
    }
}
