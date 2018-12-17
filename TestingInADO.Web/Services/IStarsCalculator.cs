using System.Collections.Generic;
using TestingInADO.Models;

namespace TestingInADO.Services
{
    public interface IStarsCalculator
    {
        int GetStarsFromRatings(ICollection<RatingComponent> ratings);
    }
}
