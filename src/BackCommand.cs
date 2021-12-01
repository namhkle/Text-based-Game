using System.Collections;
using System.Collections.Generic;

namespace CombineGame
{
    public class BackCommand : Command
    {

        public BackCommand() : base()
        {
            this.name = "back";
        }

        override
        public bool execute(Player player)
        {
            player.backTo();

            return false;
        }
    }
}
