using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ODDESTODDS.Application.DtoModels.Game
{
    public class GamePreviewDto : GameOdd.GameOddPreviewDto
    {
        public new long Id { get; set; }
        public string TeamDescription { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime? GameStartTime { get; set; }
        public int GameStatus { get; set; }
        public string GameStatusDescription { get; set; }

        public  long OddId { get; set; }


    }
}
