using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Application.DtoModels.GameOdd
{
    public class GameOddPreviewDto
    {
        public long? Id { get; set; }
        public double HomeOdd { get; set; }
        public double AwayOdd { get; set; }
        public double DrawOdd { get; set; }
        public int OddStatus { get; set; }


        public string OddStatusDescription { get; set; }
    }
}
