﻿using System.Collections;
using System.Collections.Generic;
using System;

namespace CombineGame
{
    public class CommandWords
    {
        Dictionary<string, Command> commands;
        private static Command[] commandArray = { new GoCommand(), new BackCommand(), new QuitCommand(), new SpeakCommand(), new ObtainCommand(), new DiscardCommand(), new DisplayBagCommand(), new TeleportHOmeCommand()};

        public CommandWords() : this(commandArray)
        {
        }

        public CommandWords(Command[] commandList)
        {
            commands = new Dictionary<string, Command>();
            foreach (Command command in commandList)
            {
                commands[command.name] = command;
            }
            Command help = new HelpCommand(this);
            commands[help.name] = help;
        }

        public Command get(string word)
        {
            Command command = null;
            commands.TryGetValue(word, out command);
            return command;
        }

        public string description()
        {
            string commandNames = "";
            Dictionary<string, Command>.KeyCollection keys = commands.Keys;
            foreach (string commandName in keys)
            {
                commandNames += " " + commandName;
            }
            return commandNames;


        }
    }
}
