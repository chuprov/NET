using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    //позволяет инкапсулировать запрос на выполнение определенного действия в виде отдельного объекта.
    //Этот объект запроса на действие и называется командой.
    //При этом объекты, инициирующие запросы на выполнение действия, отделяются от объектов, которые выполняют это действие.

    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
    // конкретная команда
    class ConcreteCommand : Command
    {
        Receiver receiver;
        public ConcreteCommand(Receiver r)
        {
            receiver = r;
        }
        public override void Execute()
        {
            receiver.Operation();
        }

        public override void Undo()
        { }
    }

    // получатель команды
    class Receiver
    {
        public void Operation()
        { }
    }
    // инициатор команды
    class Invoker
    {
        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run()
        {
            command.Execute();
        }
        public void Cancel()
        {
            command.Undo();
        }
    }
    class ClientCommand
    {
        void Main()
        {
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            ConcreteCommand command = new ConcreteCommand(receiver);
            invoker.SetCommand(command);
            invoker.Run();
        }
    }








    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver - Получатель
    class TV
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен!");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен...");
        }
    }

    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }
        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }

    // Invoker - инициатор
    class Pult
    {
        ICommand command;
        public Pult() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }






    // Класс макрокоманды
    class MacroCommand : ICommand
    {
        List<ICommand> commands;
        public MacroCommand(List<ICommand> coms)
        {
            commands = coms;
        }
        public void Execute()
        {
            foreach (ICommand c in commands)
                c.Execute();
        }

        public void Undo()
        {
            foreach (ICommand c in commands)
                c.Undo();
        }
    }

    class Programmer
    {
        public void StartCoding()
        {
            Console.WriteLine("Программист начинает писать код");
        }
        public void StopCoding()
        {
            Console.WriteLine("Программист завершает писать код");
        }
    }

    class Tester
    {
        public void StartTest()
        {
            Console.WriteLine("Тестировщик начинает тестирование");
        }
        public void StopTest()
        {
            Console.WriteLine("Тестировщик завершает тестирование");
        }
    }

    class Marketolog
    {
        public void StartAdvertize()
        {
            Console.WriteLine("Маркетолог начинает рекламировать продукт");
        }
        public void StopAdvertize()
        {
            Console.WriteLine("Маркетолог прекращает рекламную кампанию");
        }
    }

    class CodeCommand : ICommand
    {
        Programmer programmer;
        public CodeCommand(Programmer p)
        {
            programmer = p;
        }
        public void Execute()
        {
            programmer.StartCoding();
        }
        public void Undo()
        {
            programmer.StopCoding();
        }
    }

    class TestCommand : ICommand
    {
        Tester tester;
        public TestCommand(Tester t)
        {
            tester = t;
        }
        public void Execute()
        {
            tester.StartTest();
        }
        public void Undo()
        {
            tester.StopTest();
        }
    }

    class AdvertizeCommand : ICommand
    {
        Marketolog marketolog;
        public AdvertizeCommand(Marketolog m)
        {
            marketolog = m;
        }
        public void Execute()
        {
            marketolog.StartAdvertize();
        }

        public void Undo()
        {
            marketolog.StopAdvertize();
        }
    }

    class Manager
    {
        ICommand command;
        public void SetCommand(ICommand com)
        {
            command = com;
        }
        public void StartProject()
        {
            if (command != null)
                command.Execute();
        }
        public void StopProject()
        {
            if (command != null)
                command.Undo();
        }
    }

}
