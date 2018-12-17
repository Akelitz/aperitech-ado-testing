using System.Diagnostics;

namespace TestingInADO.Models
{
    [DebuggerDisplay("{Id} : {MovieId} : {Value}")]
    public class RatingComponent
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public MovieModel Movie { get; set; }

        public int Value { get; set; }
    }
}