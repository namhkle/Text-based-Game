using System.Collections;
using System.Collections.Generic;
using System;

namespace CombineGame
{
    public abstract class Command
    {
        private string _name;
        public string name { get { return _name; } set { _name = value; } }

        private string _secondWord;
        public string secondWord { get { return _secondWord; } set { _secondWord = value; } }

        private string _thirdWord;
        public string thirdWord { get { return _thirdWord; } set { _thirdWord = value; } }

        private string _fourthWord;
        public string fourthWord { get { return _fourthWord; } set { _fourthWord = value; } }

        public Command()
        {
            this.name = "";
            this.secondWord = null;
            this.thirdWord = null;
            this.fourthWord = null;
        }

        public bool hasSecondWord()
        {
            return this.secondWord != null;
        }

        public bool hasThirdWord()
        {
            return this.thirdWord != null;
        }

        public bool hasFourthWord()
        {
            return this.fourthWord != null;
        }

        public abstract bool execute(Player player);

    }
}
