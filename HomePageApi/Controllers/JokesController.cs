using System.Collections.Generic;
using System.Linq;
using GulnesApi.Data.Jokes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GulnesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GulnesClientPolicy")]
    public class JokesController : ControllerBase
    {

        private readonly IJokeRepository _jokeRepository;

        public JokesController(IJokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }

        [HttpGet]
        public ActionResult<List<Joke>> Get()
        {
            return _jokeRepository.GetJokes().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Joke> Get(int id)
        {
            return _jokeRepository.GetJoke(id);
        }

        [HttpPost]
        public void Post([FromBody] Joke joke)
        {
            _jokeRepository.AddJoke(joke);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _jokeRepository.DeleteJoke(id);
        }
    }
}
