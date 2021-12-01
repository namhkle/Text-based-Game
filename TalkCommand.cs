using System;

namespace CombineGame
{
    public class TalkCommand : Command
    {
        public TalkCommand() : base()
        {
            this.name = "talk";
        }


        override
        public bool execute(Player player)
        {
            if (this.hasSecondWord())
            {
                player.equip(this.secondWord);
                NotificationCenter.Instance.postNotification(new Notification("PlayerPickupItem"));
            }

            else
            {
                player.outputMessage("\nTalk to whom?");
            }
            return false;
        }
    }
}