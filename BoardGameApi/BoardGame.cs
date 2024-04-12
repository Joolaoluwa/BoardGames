using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGameApi
{
    public class BoardGame
    {
        public int Id{get; set;}
        public string? Name { get; set; }
        public int? Year { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
    }
}