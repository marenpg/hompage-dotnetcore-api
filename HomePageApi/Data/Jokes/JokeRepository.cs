using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GulnesApi.Data.Jokes
{
    public class JokeRepository : IJokeRepository
    {
        private readonly GulnesContext _db;

        public JokeRepository(GulnesContext db)
        {
            _db = db;
        }

        public void AddJoke(Joke joke)
        {
            _db.Add(joke);
            _db.SaveChanges();
        }

        public IEnumerable<Joke> GetJokes()
        {
            return _db.Jokes;
        }

        public Joke GetJoke(int id)
        {
            return _db.Jokes.FirstOrDefault(j => j.Id == id);
        }

        public void DeleteJoke(int id)
        {
            var joke = GetJoke(id);
            if (joke == null) return;

            _db.Jokes.Remove(joke);
            _db.SaveChanges();
        }
    }
}
