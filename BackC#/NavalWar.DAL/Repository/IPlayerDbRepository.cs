using NavalWar.DAL.Models;
using NavalWar.DTO.Bateau;
using NavalWar.DTO.Plateau;
using NavalWar.DTO.User;

namespace NavalWar.DAL.Repository
{
    public interface IPlayerDbRepository
    {
        void AddPlayer(PlayerDb player);
        Player? GetPlayer(int id);
        void RemovePlayer(int id);
        void UpdatePlayerName(int id, Player modif);

        public PlateauShot? getPlateauShot(int idPlayer);
        public PlateauBoat? getPlateauBoat(int idPlayer);
        void UpdatePlayerPlateauBoat(int id, PlateauBoat modif);
        void UpdatePlayerPlateauShot(int id, PlateauShot modif);
        ListBoatForStart? GetListBoatForStart(int idPlayer);
        void UpdateListBoatForStart(int idPlayer, ListBoatForStart modif);
        void SetIsWinner(int idPlayer, bool isWinner);

    }
}