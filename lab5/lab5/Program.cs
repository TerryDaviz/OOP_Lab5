using System;
using System.Collections.Generic;

namespace lab4
{
    internal class Program
    {
        public interface ICloneable
        {
            bool DoClone();
        }

        public interface ISpeak
        {
            void Speak();
        }

        private static void Main(string[] args)
        {
            Lion lion = new Lion();
            Console.WriteLine("lion is predator: ");
            Console.WriteLine(lion.IsPredator);
            Birds bird = new Birds();
            Owl owl = new Owl();
            Crocodile crocodile = new Crocodile(11, 125, "amogus");
            Console.WriteLine("crocodile speak:");
            crocodile.Speak();
            Shark shark = new Shark();
            Console.WriteLine("Shark says: ");
            shark.Speak();
            Tiger tigar = new Tiger();
            Console.WriteLine("Tiger says:");
            tigar.Speak();
            ICloneable dyadya = new DyadyaTolya();
            dyadya.DoClone();

            Animals aboba = new DyadyaTolya();
            bool isDyadya = aboba is DyadyaTolya;
            Console.WriteLine("is dyadya:" + isDyadya);

            Animals fishb = new Fish();
            Fish fishbb = fishb as Fish;
            Console.WriteLine("fishb says: ");
            fishbb.Speak();
            Console.WriteLine("IAmPrinting: ");
            Printer print = new Printer();
            print.IAmPrinting(fishbb);

            Animals[] arr = { owl, tigar, aboba, bird };
            foreach (Animals x in arr)
            {
                print.IAmPrinting(x);
            }
            B b = new B();
            Clone clone = new Clone();
            Console.WriteLine("clone.DoClone: " + clone.DoClone());

            Eagle eagle = new Eagle(3, 5, "abobus");
            Container container = new Container();
            container.AddToContainer(lion);
            container.AddToContainer(shark);
            container.ShowList();
        }

        public struct Eagle
        {
            private int _age;
            private string _name;
            private int _weight;

            public Eagle(int age, int weight, string name)
            {
                this._age = age;
                this._weight = weight;
                this._name = "";
            }

            public int Age => this._age;
            public string Name => this._name;
            public int Weigth => this._weight;
        }

        public class A
        {
            public A()
            {
                Console.WriteLine("a");
            }
        }

        public abstract class Animals : ISpeak
        {
            protected int age;
            protected string name;
            protected int weigth;

            public Animals()
            {
                this.age = 0;
                this.name = null;
                this.weigth = 0;
            }

            public int Age
            {
                get => this.age;
                set => this.age = value;
            }

            public string Name
            {
                get => this.name;
                set => this.name = value;
            }

            public int Weight
            {
                get => this.weigth;
                set => this.weigth = value;
            }

            public virtual void Speak()
            {
            }

            public override string ToString()
            {
                return "class animals";
            }
        }

        public class B : A
        {
            public B() : base()
            {
            }
        }

        public abstract class BaseClone
        {
            public abstract bool DoClone();
        }

        public class Birds : Animals
        {
            private bool _hasWings;

            public Birds()
            {
                this._hasWings = true;
            }

            public bool HasWings => this._hasWings;

            public override void Speak()
            {
                Console.WriteLine("owo");
            }

            public override string ToString()
            {
                Console.WriteLine("class Birds");
                return "class Birds";
            }
        }

        public class Clone : BaseClone
        {
            public override bool DoClone()
            {
                return false;
            }
        }

        public class Container
        {
            private List<Animals> _list;

            public void AddToContainer(Animals newElem)
            {
                this._list.Add(newElem);
            }

            public void ShowList()
            {
                foreach (Animals x in this._list)
                {
                    Console.WriteLine(x + " ");
                }
            }
        }

        public class DyadyaTolya : Animals, ICloneable, ISpeak
        {
            public bool DoClone()
            {
                return true;
            }

            public override void Speak()
            {
                Console.WriteLine("Ty cho na?");
            }
        }

        public class Printer
        {
            public void IAmPrinting(Animals someObj)
            {
                someObj.ToString();
            }
        }

        private class Crocodile : Animals
        {
            public Crocodile(int age, int weigth, string name)
            {
                Age = age;
                Weight = weigth;
                Name = name;
            }

            public override void Speak()
            {
                Console.WriteLine("yo bro");
            }

            public override string ToString()
            {
                Console.WriteLine("class crocodile");
                return "class crocodile";
            }
        }

        private class Fish : Animals
        {
            protected bool _canSwim;

            public Fish()
            {
                this._canSwim = true;
            }

            public override void Speak()
            {
                Console.WriteLine("bruh");
            }

            public override string ToString()
            {
                Console.WriteLine("class Fish");
                return "class Fish";
            }
        }

        private class Lion : Mammals
        {
            public Lion()
            {
                IsPredator = true;
            }

            public override void Speak()
            {
                Console.WriteLine("lev klichka tigar");
            }

            public override string ToString()
            {
                Console.WriteLine("class Lion");
                return base.ToString();
            }
        }

        private class Mammals : Animals
        {
            protected bool _isMammal;
            protected bool _isPredator;

            public Mammals()
            {
                this._isMammal = true;
            }

            public bool IsMammal => this._isMammal;

            public bool IsPredator
            {
                get => this._isPredator;
                set => this._isPredator = value;
            }
        }

        private class Owl : Birds
        {
            public Owl()
            {
            }

            public override void Speak()
            {
                Console.WriteLine("kurlyk kurlyk");
            }

            public override string ToString()
            {
                Console.WriteLine("class Owl");
                return base.ToString();
            }
        }

        private class Parrot : Birds
        {
            public override void Speak()
            {
                Console.WriteLine("ispantsyyyy");
            }

            public override string ToString()
            {
                Console.WriteLine("class Parrot");
                return base.ToString();
            }
        }

        private sealed class Shark : Fish, ISpeak
        {
            public bool DoClone()
            {
                return true;
            }

            public override void Speak()
            {
                Console.WriteLine("baby shark turururu");
            }

            public override string ToString()
            {
                Console.WriteLine("Class Shark");
                return base.ToString();
            }
        }

        private class Tiger : Mammals
        {
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override void Speak()
            {
                Console.WriteLine("meow");
            }

            public override string ToString()
            {
                return "class Tiger";
            }
        }
    }
}