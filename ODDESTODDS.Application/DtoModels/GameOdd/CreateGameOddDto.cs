using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Application.DtoModels.GameOdd
{
    public class CreateGameOddDto
    {
        public long? Id { get; set; }
        public double HomeOdd { get; set; }
        public double AwayOdd { get; set; }
        public double DrawOdd { get; set; }
        public int OddStatus { get; set; }

        public long? GameId { get; set; }
        
        

    }
}
