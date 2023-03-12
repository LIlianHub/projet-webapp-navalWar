using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NavalWar.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.User;
using System.Text.Json;
using NavalWar.DTO.Plateau;
using Newtonsoft.Json;
using NavalWar.DTO.Bateau;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NavalWar.DAL.Outils
{
    public class PlayerOutils
    {   
        // Json serialization settings
        private static JsonSerializerSettings SettingsJsonSerialization = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            
        };

        /* Classe */
        public static Player ToDTO(PlayerDb playerdb)
        {
            PlateauBoat plateauBoat = JsonConvert.DeserializeObject<PlateauBoat>(playerdb.plateauBoat, SettingsJsonSerialization);
            plateauBoat.RepairBoatsAfterSerialization();
            PlateauShot plateauShot = JsonConvert.DeserializeObject<PlateauShot>(playerdb.plateauShot, SettingsJsonSerialization);
            ListBoatForStart listBoatForStart = JsonConvert.DeserializeObject<ListBoatForStart>(playerdb.listeBoatForStart, SettingsJsonSerialization);
            return new Player(playerdb.Name, plateauBoat, plateauShot, listBoatForStart, playerdb.IsWinner);
        }

        public static PlayerDb ToDb(Player player)
        {
            return new PlayerDb()
            {
                Name = player.Name,
                plateauBoat = JsonConvert.SerializeObject(player.PlateauBoat, SettingsJsonSerialization),
                plateauShot = JsonConvert.SerializeObject(player.PlateauShot, SettingsJsonSerialization),
                listeBoatForStart = JsonConvert.SerializeObject(player.ListBoatForStart, SettingsJsonSerialization),
                IsWinner = player.IsWinner
            };
        }

        public static PlateauBoat ToDTOPlateauBoat(string plateauBoat)
        {
            PlateauBoat plateauBoatDto = JsonConvert.DeserializeObject<PlateauBoat>(plateauBoat, SettingsJsonSerialization);
            plateauBoatDto.RepairBoatsAfterSerialization();
            return plateauBoatDto;

        }

        public static PlateauShot ToDTOPlateauShot(string plateauShot)
        {
            return JsonConvert.DeserializeObject<PlateauShot>(plateauShot, SettingsJsonSerialization);
        }

        public static string ToDbPlateauBoat(PlateauBoat plateauBoat)
        {
            return JsonConvert.SerializeObject(plateauBoat, SettingsJsonSerialization);
        }

        public static string ToDbPlateauShot(PlateauShot plateauShot)
        {
            return JsonConvert.SerializeObject(plateauShot, SettingsJsonSerialization);
        }

        public static ListBoatForStart ToDTOListBoatStart(string listBoat)
        {
            return JsonConvert.DeserializeObject<ListBoatForStart>(listBoat, SettingsJsonSerialization);
        }
        public static string ToDbListBoatStart(ListBoatForStart listBoat)
        {
            return JsonConvert.SerializeObject(listBoat, SettingsJsonSerialization);
        }
    }
}
