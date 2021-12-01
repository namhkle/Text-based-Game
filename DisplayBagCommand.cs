using System;

namespace CombineGame
{
    public class DisplayBagCommand : Command
    {
        public DisplayBagCommand() : base()
        {
            this.name = "v";
        }

        override
        public bool execute(Player player)
        {
            if (!this.hasSecondWord())
            {
                player.displayBag();
            }
            
            return false;
        }
    }
}