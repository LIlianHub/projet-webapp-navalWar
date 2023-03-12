using Microsoft.AspNetCore.Mvc;
using NavalWar.Business.Game;
using NavalWar.DTO.ObjectElementPlateau;
using NavalWar.DTO.Jeu;
using NavalWar.DTO.User;
using NavalWar.Business.ObjectRequest;
using NavalWar.DTO.Plateau;
using NavalWar.Business.ShotServ;
using Newtonsoft.Json;
using Azure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NavalWar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateauShotController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IShotService _shotService;


        public PlateauShotController(IGameService gameService, IShotService shotService)
        {
            _gameService = gameService;
            _shotService = shotService;
        }

        [HttpGet("{idPlayer}")]
        public IActionResult Get(int idPlayer)
        {
            PlateauShot? retour =  _shotService.GetPlateauShotbyPlayerId(idPlayer);
            if (retour == null)
            {
                return NotFound("Joueur Inconnu");
            }
            else
            {
                return Ok(retour);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShotRequest shotRequest)
        {
            // si on est dans la phase partie
            if (_gameService.GetEtatGame(shotRequest.IdSession) == 1)
            {
                // si c'est bien le tour du joueur
                if (_gameService.GetPlayerTour(shotRequest.IdSession) == shotRequest.IdPlayer)
                {
                    ShotAnswer retour = _shotService.Shot(shotRequest);
                    if (retour.IsHit == null)
                    {
                        return BadRequest(retour.Reponse);
                    }
                    else
                    {
                        return Ok(retour);
                    }
                }
                return BadRequest("Ce n'est pas votre tour");
            }
            return BadRequest("La partie n'a pas commencé");
        }
    }
}
