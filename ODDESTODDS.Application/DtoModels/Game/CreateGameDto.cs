using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Application.DtoModels.Game
{
    public class CreateGameDto
    {
        public long Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public string HomeOdd { get; set; }
        public string AwayOdd { get; set; }
        public string DrawOdd { get; set; }

        public DateTime? GameStartTime { get; set; }
        public DateTime? GameEndTime { get; set; }
        public int GameStatus { get; set; }

        public string GameStatusDescription { get; set; }
    }

    



}
