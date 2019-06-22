using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ODDESTODDS.Application.DtoModels.Game
{
    public class CreateGameDto
    {
        
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string HomeTeam { get; set; }
        [Required]
        [MaxLength(50)]
        public string AwayTeam { get; set; }

        public double HomeOdd { get; set; }
        public double AwayOdd { get; set; }
        public double DrawOdd { get; set; }

        public DateTime? GameStartTime { get; set; }
        [Required]
        [Range(0, 4)]
        public int GameStatus { get; set; }

    }

    



}
