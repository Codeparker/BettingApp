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

        [Required]
        [Display(Name="1")]
        [Range(0.0, double.MaxValue)]
        public double HomeOdd { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        [Display(Name = "2")]
        public double AwayOdd { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        [Display(Name = "X")]
        public double DrawOdd { get; set; }

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss t}", ApplyFormatInEditMode =true)]
        [Required]
        public string GameStartTime { get; set; }

        public int GameStatus { get; set; }

    }

    



}
