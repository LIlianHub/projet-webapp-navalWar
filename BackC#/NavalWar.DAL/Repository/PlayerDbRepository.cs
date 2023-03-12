using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DAL.Models;
using NavalWar.DTO.User;
using NavalWar.DAL.Outils;
using NavalWar.DTO.Plateau;
using NavalWar.DTO.Bateau;

namespace NavalWar.DAL.Repository
{
    public class PlayerDbRepository : IPlayerDbRepository
    {

        private readonly NavalContext _context;

        public PlayerDbRepository(NavalContext context)
        {
            _context = context;
        }

        public void AddPlayer(PlayerDb player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void RemovePlayer(int id)
        {
            var player = _context.Players.Find(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
            }
        }


        public Player? GetPlayer(int id)
        {
            var session = _context.Players.FirstOrDefault(p => p.ID == id);
            if (session != null)
            {
                Console.WriteLine("up");
                return PlayerOutils.ToDTO(session);
            }
            return null;

        }

        public PlateauBoat? getPlateauBoat(int idPlayer)
        {
            var player = _context.Players.FirstOrDefault(p => p.ID == idPlayer);
            if (player != null)
            {
                return PlayerOutils.ToDTOPlateauBoat(player.plateauBoat);
            }
            return null;
        }

        public PlateauShot? getPlateauShot(int idPlayer)
        {
            var player = _context.Players.FirstOrDefault(p => p.ID == idPlayer);
            if (player != null)
            {
                return PlayerOutils.ToDTOPlateauShot(player.plateauShot);
            }
            return null;
        }

        public void UpdatePlayerName(int id, Player modif)
        {
            //update player in db
            var player = _context.Players.First(p => p.ID == id);
            if (player != null)
            {
                player.Name = modif.Name;
                _context.SaveChanges();
            }
        }

        public void UpdatePlayerPlateauBoat(int id, PlateauBoat modif)
        {
            var player = _context.Players.First(p => p.ID == id);
            if (player != null)
            {
                player.plateauBoat = PlayerOutils.ToDbPlateauBoat(modif);
                _context.SaveChanges();
            }
        }

        public void UpdatePlayerPlateauShot(int id, PlateauShot modif)
        {
            //update player in db
            var player = _context.Players.First(p => p.ID == id);
            if (player != null)
            {
                player.plateauShot = PlayerOutils.ToDbPlateauShot(modif);
                _context.SaveChanges();
            }
        }

        public ListBoatForStart? GetListBoatForStart(int idPlayer)
        {
            var player = _context.Players.First(p => p.ID == idPlayer);
            if (player != null)
            {
                return PlayerOutils.ToDTOListBoatStart(player.listeBoatForStart);
            }
            return null;
        }

        public void UpdateListBoatForStart(int idPlayer, ListBoatForStart modif)
        {
            //update player in db
            var player = _context.Players.First(p => p.ID == idPlayer);
            if (player != null)
            {
                player.listeBoatForStart = PlayerOutils.ToDbListBoatStart(modif);
                _context.SaveChanges();
            }
        }

        public void SetIsWinner(int idPlayer, bool isWinner)
        {
            //update player in db
            var player = _context.Players.First(p => p.ID == idPlayer);
            if (player != null)
            {
                player.IsWinner = isWinner;
                _context.SaveChanges();
            }
        }



    }
}
