using System;

namespace CombineGame
{
    public class DiscardCommand : Command
    {
        public DiscardCommand() : base()
        {
            this.name = "discard";
        }

        override
        public bool execute(Player player)
        {
            if (this.hasSecondWord())
            {
                player.discard(this.secondWord);
                NotificationCenter.Instance.postNotification(new Notification("PlayerSpeakWord"));
            }
            else
            {
                player.outputMessage("\nPick Up What?");
            }
            return false;
        }
    }
}