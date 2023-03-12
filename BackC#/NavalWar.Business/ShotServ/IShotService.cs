
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

namespace NavalWar.Business.ShotServ
{
    public interface IShotService
    {
        PlateauShot? GetPlateauShotbyPlayerId(int idPlayer);
        ShotAnswer Shot(ShotRequest shotRequest);


    }
}
