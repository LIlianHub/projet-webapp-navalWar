using Microsoft.AspNetCore.Mvc;
using NavalWar.Business.Game;
using NavalWar.DTO.ObjectElementPlateau;
using NavalWar.DTO.Jeu;
using NavalWar.DTO.User;
using NavalWar.Business.ObjectRequest;
using NavalWar.DTO.Plateau;
using NavalWar.Business.BateauServ;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NavalWar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateauBoatController : ControllerBase
    {
        private readonly IBateauService _bateauService;
        private readonly IGameService _gameService;

        public PlateauBoatController(IBateauService bateauService, IGameService gameService)
        {
            _bateauService = bateauService;
            _gameService = gameService;
        }

        [HttpGet("{IdPlayer}")]
        public IActionResult Get(int IdPlayer)
        {
            PlateauBoat? retour = _bateauService.GetPlateauBoatbyPlayerId(IdPlayer);
            if (retour == null)
            {
                return NotFound("Joueur inconnu");
            }
            else
            {
                return Ok(retour);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddBoatRequest addBoatRequest)
        {
            if (_gameService.GetEtatGame(addBoatRequest.IdSession) == 0)
            {
                if (_gameService.IsPlayerReady(addBoatRequest.IdSession, addBoatRequest.Player1or2) == false)
                {
                    EditBoatAnswer retour = _bateauService.AddBoat(addBoatRequest);
                    if (retour.IsPlaced == null)
                    {
                        return BadRequest(retour.Message);
                    }
                    else
                    {
                        return Ok(retour);
                    }
                }
                return BadRequest("Vous avez validé votre grille");
            }
            return BadRequest("La partie n'est pas en cours de création");
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] RemoveBoatRequest removeBoatRequest)
        {
            if(_gameService.GetEtatGame(removeBoatRequest.IdSession) == 0)
            {
                if (_gameService.IsPlayerReady(removeBoatRequest.IdSession, removeBoatRequest.Player1or2) == false)
                {
                    EditBoatAnswer retour = _bateauService.RemoveBoat(removeBoatRequest);
                    if (retour.IsPlaced == null)
                    {
                        return BadRequest(retour.Message);
                    }
                    else
                    {
                        return Ok(retour);
                    }
                }
                return BadRequest("Vous avez validé votre grille");
            }
            return BadRequest("La partie n'est pas en cours de création");

        }

        [HttpPut]
        public IActionResult Put([FromBody] MoveBoatRequest moveBoatRequest)
        {
            if (_gameService.GetEtatGame(moveBoatRequest.IdSession) == 0)
            {
                if (_gameService.IsPlayerReady(moveBoatRequest.IdSession, moveBoatRequest.Player1or2) == false)
                {
                    EditBoatAnswer retour = _bateauService.MoveBoat(moveBoatRequest);
                    if (retour.IsPlaced == null)
                    {
                        return BadRequest(retour.Message);
                    }
                    else
                    {
                        return Ok(retour);
                    }
                }
                return BadRequest("Vous avez validé votre grille");
            }
            return BadRequest("La partie n'est pas en cours de création");

        }
    }
}
