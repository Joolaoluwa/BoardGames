using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameApi;
using BoardGameApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameApi.Controller;
    [Route("BoardGameList")]
    [ApiController]
    [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
    public class BoardGameController : ControllerBase
    {
        private readonly ILogger<BoardGameController> _logger;

        public BoardGameController(ILogger<BoardGameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public RestDTO<BoardGame[]> Get()
        {
            return new RestDTO<BoardGame[]>()
            {
                 Data = new []
                 {
                    new BoardGame()
                    {
                        Id = 1,
                        Name = "Axis & Allies",
                        Year = 1981,
                        MinPlayers = 2,
                        MaxPlayers = 5
                    },
                    new BoardGame()
                    {
                        Id = 2,
                        Name = "Citadels",
                        Year = 2000,
                        MinPlayers = 2,
                        MaxPlayers = 8 
                    },
                    new BoardGame()
                    {
                        Id = 3,
                        Name = "Terraforming Mars",
                        Year = 2016,
                        MinPlayers = 1,
                        MaxPlayers = 5
                    }
                    },
                    LinkDto = new List<LinkDTO>()
                    {
                        new LinkDTO(
                             Url.Action(null, "BoardGameList", null, Request.Scheme)!,
                            "self",
                            "GET"
                        )
                    }
                };
            } 
    }