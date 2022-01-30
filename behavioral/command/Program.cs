using System;
using System.Collections.Generic;

namespace command
{
    class Program
    {
        static void Main(string[] args)
        {
            IRemoteControl remoteControl = new RemoteControl();
            remoteControl.ExecuteCommand(new LightsOnCommand());
            remoteControl.ExecuteCommand(new GarageDoorOpenCommand());
            remoteControl.Undo();
            remoteControl.Undo();
        }
    }

    public interface IRemoteControl
    {
        void ExecuteCommand(ICommand command);

        void Undo();
    }

    public class RemoteControl : IRemoteControl
    {
        private Stack<ICommand> history = new Stack<ICommand>();
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            history.Push(command);
        }

        public void Undo()
        {
            ICommand command = history.Pop();
            command.Undo();
        }
    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class LightsOnCommand: ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Lights On");
        }

        public void Undo()
        {
            Console.WriteLine("Lights Off");
        }
    }

    public class LightsOffCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Lights Off");
        }

        public void Undo()
        {
            Console.WriteLine("Lights On");
        }
    }

    public class GarageDoorOpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Garage Door Opened");
        }

        public void Undo()
        {
            Console.WriteLine("Garage Door Closed");
        }
    }

    public class GarageDoorCloseCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Garage Door Closed");
        }

        public void Undo()
        {
            Console.WriteLine("Garage Door Opened");
        }
    }
}
