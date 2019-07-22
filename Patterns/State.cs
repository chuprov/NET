using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    //позволяет объекту изменять свое поведение в зависимости от внутреннего состояния
    class ProgramState
    {
        static void Main()
        {
            ContextState context = new ContextState(new StateA());
            context.Request(); // Переход в состояние StateB
            context.Request();  // Переход в состояние StateA
        }
    }
    abstract class State
    {
        public abstract void Handle(Context context);
    }
    class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }
    class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }

    class ContextState
    {
        public State State { get; set; }
        public ContextState(State state)
        {
            this.State = state;
        }
        public void Request()
        {
            this.State.Handle(this);
        }
    }



  
    class Water
    {
        public IWaterState State { get; set; }

        public Water(IWaterState ws)
        {
            State = ws;
        }

        public void Heat()
        {
            State.Heat(this);
        }
        public void Frost()
        {
            State.Frost(this);
        }
    }

    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }

    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем лед в жидкость");
            water.State = new LiquidWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Продолжаем заморозку льда");
        }
    }
    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем жидкость в пар");
            water.State = new GasWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Превращаем жидкость в лед");
            water.State = new SolidWaterState();
        }
    }
    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Повышаем температуру водяного пара");
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Превращаем водяной пар в жидкость");
            water.State = new LiquidWaterState();
        }
    }

}
