using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    //шаблон проектирования, который определяет набор алгоритмов, инкапсулирует каждый из них и обеспечивает их взаимозаменяемость.
    //В зависимости от ситуации мы можем легко заменить один используемый алгоритм другим.
    //При этом замена алгоритма происходит независимо от объекта, который использует данный алгоритм.
    public interface IStrategy
    {
        void Algorithm();
    }

    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        { }
    }

    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        { }
    }

    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.Algorithm();
        }
    }




    interface IMovable
    {
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }
    class Car
    {
        protected int passengers; // кол-во пассажиров
        protected string model; // модель автомобиля

        public Car(int num, string model, IMovable mov)
        {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }
        public IMovable Movable { private get; set; }
        public void Move()
        {
            Movable.Move();
        }
    }



}
