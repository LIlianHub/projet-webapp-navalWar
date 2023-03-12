using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NavalWar.Business.Game;
using NavalWar.DTO;
using NavalWar.DTO.Jeu;
using NavalWar.DTO.User;
using NavalWar.Business.ObjectRequest;

namespace NavalWar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RejoinController : ControllerBase
    {

        private readonly IGameService _gameService;

        public RejoinController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpPost("{idSession}")]
        public IActionResult Post(int idSession, [FromBody] int Player1or2)
        {
            //Console.WriteLine("RejoinController: " + idSession + " " + Player1or2);
            if (Player1or2 == 1 || Player1or2 == 2)
            {
                AllElementPlayerAnswer retour = _gameService.GetAllPlayerInfo(idSession, Player1or2);
                if (retour.IdPlayer == -1)
                {
                    return NotFound("Joueur inconnu");
                }
                else
                {
                    return Ok(retour);
                }

            }
            return BadRequest("Player 1 ou 2 uniquement");
        }

        [HttpGet("{idSession}")]
        public IActionResult Get(int idSession)
        {
            int retour = _gameService.GetPlayerTour(idSession);
            if (retour == -1)
            {
                return NotFound("Session inconnu");
            }
            else
            {
                return Ok(retour);
            }
        }
        
    }
}
