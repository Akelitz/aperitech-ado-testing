using System.Collections.Generic;
using System.Diagnostics;

namespace TestingInADO.Models
{
    [DebuggerDisplay("{Id} : {Title} : {Year}")]
    public class MovieModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public IList<RatingComponent> Ratings { get; set; } = new List<RatingComponent>();
    }
}
