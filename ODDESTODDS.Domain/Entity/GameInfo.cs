using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Domain.Entity
{
    public class GameInfo: BaseEntity
    {
        public virtual GameOdd GameOdd { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
       
        public DateTime? GameStartTime { get; set; }
       
        public int GameStatus { get; set; }

      



    }
   
    
}
