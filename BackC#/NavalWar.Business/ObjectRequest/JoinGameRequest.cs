namespace NavalWar.Business.ObjectRequest
{
    public class JoinGameRequest
    {

        public string NameP2 { get; set; }
        
        public int IdGame { get; set; }

        public JoinGameRequest(string name, string password, int id)
        {
            NameP2 = name;
            IdGame = id;
        }

        public JoinGameRequest() { }
 
    }
}
