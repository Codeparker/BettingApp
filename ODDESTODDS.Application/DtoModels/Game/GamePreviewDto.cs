using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Application.DtoModels.Game
{
    public class GamePreviewDto :GameOdd.GameOddPreviewDto
    {
        public string TeamDescription { get; set; }
       
        public DateTime? GameStartTime { get; set; }
        public int GameStatus { get; set; }
        public string GameStatusDescription { get; set; }


    }
}
