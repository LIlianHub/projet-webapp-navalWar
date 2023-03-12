using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NavalWar.Business.Game;
using NavalWar.DTO;
using NavalWar.DTO.Jeu;
using NavalWar.DTO.User;
using NavalWar.Business.ObjectRequest;
using Newtonsoft.Json;

namespace NavalWar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinController : ControllerBase
    {

        private readonly IGameService _gameService;

        public JoinController(IGameService gameService)
        {
            _gameService = gameService;
        }


        // Rejoindre une partie
        [HttpPost]
        public IActionResult JoinGame([FromBody] JoinGameRequest joinGame)
        {
            AllElementPlayerAnswer retour = _gameService.JoinGame(joinGame.IdGame, joinGame.NameP2);
            if (retour.IdPlayer == -1)
            {
                return BadRequest(retour.Message);
            }
            else
            {
                return Ok(retour);
            }
        }

        // get id player in game
        [HttpGet("{idSession}")]
        public IActionResult GetIdPlayerInGame(int idSession)
        {
            int[] retour =  _gameService.GetIdPlayerInGame(idSession);
            if (retour == null)
            {
                return NotFound("Partie inconnue");
            }
            else
            {
                return Ok(retour);
            }
        }

        // valider sa grille

        [HttpPut]
        public IActionResult ValidateGrid([FromBody] EditValidateRequest editValidateRequest)
        {
            EditValidateAnswer retour =  _gameService.ValideReady(editValidateRequest);
            if (retour.Ok)
            {
                return Ok(retour);
            }
            else
            {
                return BadRequest(retour.Message);
            }
        }

    }
}
