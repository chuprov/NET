using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    // предоставляет абстрактный интерфейс для последовательного доступа ко всем элементам составного объекта
    // без раскрытия его внутренней структуры.


    public interface IEnumerator
    {
        bool MoveNext(); // перемещение на одну позицию вперед в контейнере элементов
        object Current { get; }  // текущий элемент в контейнере
        void Reset(); // перемещение в начало контейнера
    }


    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }






    class ClientIterator
    {
        public void Main()
        {
            Aggregate a = new ConcreteAggregate();

            Iterator i = a.CreateIterator();

            object item = i.First();
            while (!i.IsDone())
            {
                item = i.Next();
            }
        }
    }

    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract int Count { get; protected set; }
        public abstract object this[int index] { get; set; }
    }

    class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList _items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count
        {
            get { return _items.Count; }
            protected set { }
        }

        public override object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    class ConcreteIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current;

        public ConcreteIterator(Aggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;
            _current++;

            if (_current < _aggregate.Count)
            {
                ret = _aggregate[_current];
            }
            return ret;
        }

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }






    class Reader
    {
        public void SeeBooks(Library library)
        {
            IBookIterator iterator = library.CreateNumerator();
            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }

    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
    interface IBookNumerable
    {
        IBookIterator CreateNumerator();
        int Count { get; }
        Book this[int index] { get; }
    }
    class Book
    {
        public string Name { get; set; }
    }

    class Library : IBookNumerable
    {
        private Book[] books;
        public Library()
        {
            books = new Book[]
            {
                new Book{Name="Война и мир"},
                new Book {Name="Отцы и дети"},
                new Book {Name="Вишневый сад"}
            };
        }
        public int Count
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get { return books[index]; }
        }
        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }
    class LibraryNumerator : IBookIterator
    {
        IBookNumerable aggregate;
        int index = 0;
        public LibraryNumerator(IBookNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Book Next()
        {
            return aggregate[index++];
        }
    }

}
