using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Application.DtoModels.Game
{
    public class GamePreviewDto
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime? GameStartTime { get; set; }
        public int GameStatus { get; set; }
        public string GameStatusDescription { get; set; }
    }
}
