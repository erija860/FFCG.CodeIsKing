using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFCG.G5.GameOfLife.WebApplication.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}