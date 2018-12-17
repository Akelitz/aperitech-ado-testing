using System.Collections.Generic;
using System.Linq;
using TestingInADO.Models;

namespace TestingInADO.Services
{
    public class StarsCalculator : IStarsCalculator
    {
        public int GetStarsFromRatings(ICollection<RatingComponent> ratings)
            => (ratings?.Any() ?? false) ? (int)(ratings.Average(r => r.Value)) : 0;
    }
}
