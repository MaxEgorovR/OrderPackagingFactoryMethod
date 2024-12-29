using System;

namespace OrderSet
{
    internal class Program
    {
        // Factory Method
        static void Main(string[] args)
        {
            Console.WriteLine("Choise the delivery type:\n1 - Pizza\n2 - Sushi\n3 - Burger");
            int choise = int.Parse(Console.ReadLine());
            Delivery delivery = choise == 1 ? new PizzaDelivery() : choise == 2 ? new SushiDelivery() : new BurgerDelivery();
            delivery.Deliver();

        }

        public abstract class Food
        {
            public abstract void Prepare();
        }

        public class Pizza : Food
        {
            public override void Prepare()
            {
                Console.WriteLine("Pizza is prepared with cheese and sauce");
            }
        }

        public class Sushi : Food
        {
            public override void Prepare()
            {
                Console.WriteLine("Sushi is prepared with feesh and rice");
            }
        }

        public class Burger : Food
        {
            public override void Prepare()
            {
                Console.WriteLine("Burger is prepared with bun, cutlet and cheese");
            }
        }

        public abstract class Packaging
        {
            public abstract Food Package();
        }

        public class SushiPackaging : Packaging
        {
            public override Food Package()
            {
                Console.WriteLine("Sushi will be packed in a container");
                return new Sushi();
            }
        }

        public class BurgerPackaging : Packaging
        {
            public override Food Package()
            {
                Console.WriteLine("Burger will be packed in a package");
                return new Burger();
            }
        }

        public class PizzaPackaging : Packaging
        {
            public override Food Package()
            {
                Console.WriteLine("Pizza will be packed in a box");
                return new Pizza();
            }
        }

        public abstract class Delivery
        {
            public abstract Packaging CreatePackaging();

            public void Deliver()
            {
                var packaging = CreatePackaging();
                var food = packaging.Package();
                food.Prepare();
                Console.WriteLine("Delivery is completed");
            }
        }


        public class PizzaDelivery : Delivery
        {
            public override Packaging CreatePackaging()
            {
                return new PizzaPackaging();
            }
        }

        public class SushiDelivery : Delivery
        {
            public override Packaging CreatePackaging()
            {
                return new SushiPackaging();
            }
        }

        public class BurgerDelivery : Delivery
        {
            public override Packaging CreatePackaging()
            {
                return new BurgerPackaging();
            }
        }


    }
}
