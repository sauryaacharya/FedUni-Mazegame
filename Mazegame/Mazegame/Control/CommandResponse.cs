using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Control
{
    public class CommandResponse
    {
        private bool finishedGame;
        private String message;

        public CommandResponse(String message)
        {
            this.message = message;
            finishedGame = false;
        }

        public CommandResponse(String message, bool quitFlag)
        {
            this.message = message;
            this.finishedGame = quitFlag;
        }

        public void setMessage(String message)
        {
            this.message = message;
        }

        public String getMessage()
        {
            return message;
        }

        public void setQuitFlag(bool quitFlag)
        {
            this.finishedGame = quitFlag;
        }

        public bool getQuitFlag()
        {
            return finishedGame;
        }
    }
}
