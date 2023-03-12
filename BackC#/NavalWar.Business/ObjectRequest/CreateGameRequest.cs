namespace NavalWar.Business.ObjectRequest
{
    public class CreateGameRequest
    {
        
        public string NameP1 { get; set; }

        public CreateGameRequest(string nameP1, string password)
        {
            NameP1 = nameP1;
        }

        public CreateGameRequest() { }

    }
}
