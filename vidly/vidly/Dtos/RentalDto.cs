using System.Collections.Generic;

namespace vidly.Dtos
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}