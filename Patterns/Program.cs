using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            //Factory Method
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();

            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();

            Console.ReadLine();



            //Abstract Factory
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero voin = new Hero(new VoinFactory());
            voin.Hit();
            voin.Run();

            Console.ReadLine();



            //Prototype
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.Read();


            //Builder
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());

            Console.Read();

            //Strategy
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

            Console.ReadLine();


        }
    }
}
