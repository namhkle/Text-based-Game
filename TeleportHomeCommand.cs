using System;

namespace CombineGame
{
    public class TeleportHOmeCommand : Command
    {
        public TeleportHOmeCommand() : base()
        {
            this.name = "home";
        }

        override
        public bool execute(Player player)  
        {
            if (!this.hasSecondWord())
            {
                player.teleportHome();
            }
            else
            {
                player.outputMessage("\nYou hasn't unlocked this spell yet");
            }
            return false;
        }
    }
}