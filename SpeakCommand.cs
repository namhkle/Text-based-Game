using System;

namespace CombineGame
{
    public class SpeakCommand : Command
    {
        public SpeakCommand() : base()
        {
            this.name = "speak";
        }
       

        override
        public bool execute(Player player)
        {
            if (this.hasSecondWord())
            {
                player.speak(this.secondWord);
                NotificationCenter.Instance.postNotification(new Notification("PlayerSpeakWord"));
            }
            else
            {
                player.outputMessage("\nSpeak What?");
            }
            return false;
        }
    }
}