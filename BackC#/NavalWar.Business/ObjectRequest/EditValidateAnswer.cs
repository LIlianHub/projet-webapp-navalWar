using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.Business.ObjectRequest
{
    public class EditValidateAnswer
    {
        public bool Ok { get; set; }
        public string Message { get; set; }

        public EditValidateAnswer(bool ok, string message)
        {
            Ok = ok;
            Message = message;
        }
    }
}
