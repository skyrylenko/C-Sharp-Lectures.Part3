﻿namespace Lecture04.Decorator
{
	public class DecoratorClientCode
	{
		public void DecoratorCodeRun() 
		{
			Pizza pizza1 = new ItalianPizza();
			pizza1 = new TomatoPizza(pizza1); // італійська піца з томатами
			Console.WriteLine("Назва: {0}", pizza1.Name);
			Console.WriteLine("Ціна: {0}", pizza1.GetCost());

			Pizza pizza2 = new ItalianPizza();
			pizza2 = new CheesePizza(pizza2);// італійська піца з сиром
			Console.WriteLine("Назва: {0}", pizza2.Name);
			Console.WriteLine("Ціна: {0}", pizza2.GetCost());

			Pizza pizza3 = new BulgerianPizza();
			pizza3 = new TomatoPizza(pizza3);
			pizza3 = new CheesePizza(pizza3);// болгарська піца з томатами і сиром
			Console.WriteLine("Назва: {0}", pizza3.Name);
			Console.WriteLine("Ціна: {0}", pizza3.GetCost());

			Console.WriteLine("");
		}

	}

	abstract class Pizza
	{
		public Pizza(string n)
		{
			this.Name = n;
		}
		public string Name { get; protected set; }
		public abstract int GetCost();
	}

	class ItalianPizza : Pizza
	{
		public ItalianPizza() : base("Італійська піца")
		{ }
		public override int GetCost()
		{
			return 10;
		}
	}
	class BulgerianPizza : Pizza
	{
		public BulgerianPizza()
			: base("Болгарська піца")
		{ }
		public override int GetCost()
		{
			return 8;
		}
	}

	abstract class PizzaDecorator : Pizza
	{
		protected Pizza pizza;
		public PizzaDecorator(string n, Pizza pizza) : base(n)
		{
			this.pizza = pizza;
		}
	}

	class TomatoPizza : PizzaDecorator
	{
		public TomatoPizza(Pizza p)
			: base(p.Name + ", з томатами", p)
		{ }

		public override int GetCost()
		{
			return pizza.GetCost() + 3;
		}
	}

	class CheesePizza : PizzaDecorator
	{
		public CheesePizza(Pizza p)
			: base(p.Name + ", з сиром", p)
		{ }

		public override int GetCost()
		{
			return pizza.GetCost() + 5;
		}
	}
}
