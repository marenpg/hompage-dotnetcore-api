using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GulnesApi.Data.Jokes
{
    public class Joke
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(140, ErrorMessage = "The given joke is too long.")]
        public string JokeText { get; set; }
    }
}
