using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.Business.ObjectRequest
{
    public class EditValidateRequest
    {
        public int IdSession { get; set; }
        public int Player1or2 { get; set; }

        public EditValidateRequest(int idSession, int player1or2)
        {
            IdSession = idSession;
            Player1or2 = player1or2;
        }
    }
}
