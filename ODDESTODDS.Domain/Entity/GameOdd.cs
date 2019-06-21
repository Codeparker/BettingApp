using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Domain.Entity
{
    public class GameOdd : BaseEntity
    {

       
        public double HomeOdd { get; set; }
        public double AwayOdd { get; set; }
        public double DrawOdd { get; set; }
        public int OddStatus { get; set; }


        public long GameInfoId { get; set; }
        public virtual GameInfo GameInfo { get; set; }
    }
}
