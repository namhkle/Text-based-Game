using System;

namespace CombineGame
{
    public class ObtainCommand : Command
    {
        public ObtainCommand() : base()
        {
            this.name = "obtain";
        }


        override
        public bool execute(Player player)
        {
            if (this.hasSecondWord())
            {
                player.obtain(this.secondWord);
                NotificationCenter.Instance.postNotification(new Notification("PlayerPickupItem"));

                if (this.hasThirdWord())
                {
                    player.obtain(this.thirdWord);
                    NotificationCenter.Instance.postNotification(new Notification("PlayerPickupItem"));

                    if (this.hasFourthWord())
                    {
                        player.obtain(this.fourthWord);
                        NotificationCenter.Instance.postNotification(new Notification("PlayerPickupItem"));
                    }
                }
            }
           
            else
            {
                player.outputMessage("\nObtain What?");
            }
            return false;
        }
    }
}