using System;

namespace CombineGame
{
    public class EquipCommand : Command
    {
        public EquipCommand() : base()
        {
            this.name = "equip";
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
                player.outputMessage("\nEquipd What?");
            }
            return false;
        }
    }
}