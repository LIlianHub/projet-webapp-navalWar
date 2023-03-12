
using NavalWar.DTO.Jeu;
using NavalWar.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DAL.Models;
using NavalWar.DTO.Plateau;
using NavalWar.Business.ObjectRequest;

namespace NavalWar.Business.BateauServ
{
    public interface IBateauService
    {
        PlateauBoat? GetPlateauBoatbyPlayerId(int idPlayer);

        EditBoatAnswer AddBoat(AddBoatRequest addBoatRequest);
        EditBoatAnswer RemoveBoat(RemoveBoatRequest removeBoatRequest);
        EditBoatAnswer MoveBoat(MoveBoatRequest moveBoatRequest);
    }
}
