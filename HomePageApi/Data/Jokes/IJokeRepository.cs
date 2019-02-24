using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GulnesApi.Data.Jokes
{
    public interface IJokeRepository
    {
        void AddJoke(Joke joke);

        IEnumerable<Joke> GetJokes();

        Joke GetJoke(int id);

        void DeleteJoke(int id);
    }
}
