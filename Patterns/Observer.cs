using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    //шаблон проектирования, который использует отношение "один ко многим".
    //В этом отношении есть один наблюдаемый объект и множество наблюдателей.
    //И при изменении наблюдаемого объекта автоматически происходит оповещение всех наблюдателей.
    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    class ConcreteObservable : IObservable
    {
        private List<IObserver> observers;
        public ConcreteObservable()
        {
            observers = new List<IObserver>();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.Update();
        }
    }

    interface IObserver
    {
        void Update();
    }
    class ConcreteObserver : IObserver
    {
        public void Update()
        {
        }
    }




}
