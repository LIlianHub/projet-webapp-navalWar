using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NavalWar.Business.Game;
using NavalWar.DTO;
using NavalWar.DTO.Jeu;
using NavalWar.DTO.User;
using NavalWar.Business.ObjectRequest;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NavalWar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly IGameService  _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        // Création d'une partie
        [HttpPost]
        public IActionResult CreateGame([FromBody] CreateGameRequest createGame)
        {
            return Ok(_gameService.CreateGame(createGame.NameP1));
        }

        // getEtat partie

        [HttpGet("{idSession}")]
        public IActionResult GetEtatGame(int idSession)
        {
            int? retour =  _gameService.GetEtatGame(idSession);
            if (retour == null)
            {
                return NotFound("Partie introuvable");
            }
            else
            {
                return Ok(retour);
            }
        }
    }
}
