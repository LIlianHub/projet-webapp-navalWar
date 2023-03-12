using NavalWar.DTO.User;

namespace NavalWar.Business.ObjectRequest
{
    public class CreateGameAnswer
    {
        
        public int IdGame { get; set; }
        public Player Player { get; set; }
        public int IdPlayer { get; set; }


        public CreateGameAnswer(int idGame, Player player, int idPlayer)
        {
            IdGame = idGame;
            Player = player;
            IdPlayer = idPlayer;
        }

    }
}
