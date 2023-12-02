using System.Security.Cryptography;

namespace Lecture03
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			var director = new Director();
			var builder01 = new Builder();
			var builder02 = new Builder();
			var builder03 = new Builder();
			var builder04 = new Builder();
			//Product #1. Minimal
			Console.WriteLine("Build minimal product by Builder01");
			director.Builder = builder01;
			director.BuildMinimalProduct();
			Console.WriteLine(director.GetProduct().ListParts());
			director.GetProduct();
			Console.WriteLine();

			//Product #2. Add garage to minimal product by another Builder02
			Console.WriteLine("Build maximal product by Builder02");
			director.Builder = builder02;
			director.BuildGarage();
			Console.WriteLine(director.GetProduct().ListParts());
			Console.WriteLine();


			//Product #3. Build Full product by separate builders
			director.ResetProduct();
			Console.WriteLine(director.GetProduct().ListParts());
			Console.WriteLine();

			Console.WriteLine("Build Full product by separate builders");
			director.Builder = builder01;
			director.Builder.BuildWalls(director.product);
			Console.WriteLine(director.GetProduct().ListParts());
			director.Builder = builder02;
			director.Builder.BuildWindows(director.product);
			Console.WriteLine(director.GetProduct().ListParts());
			director.Builder = builder03;
			director.Builder.BuildRoof(director.product);
			Console.WriteLine(director.GetProduct().ListParts());
			director.Builder = builder04;
			director.Builder.BuildGarage(director.product);
			Console.WriteLine(director.GetProduct().ListParts());
		}
	}

	public interface IBuilder
	{
		void BuildWalls(Product product);
		void BuildGarage(Product product);
		void BuildWindows(Product product);
		void BuildRoof(Product product);
	}

	public class Product
	{
		private List<object> parts = new List<object>();
		public void Add(string part)
		{
			parts.Add(part);
		}
		public string ListParts()
		{
			var res = string.Empty;
			foreach (var part in parts)
			{
				res += part + ", ";
			}
			res = res.Count() > 0 ? res.Remove(res.Length - 2) : "The construction of the product hasn't started yet!!!";
			return $"Product parts: {res}";
		}
	}

	public class Director
	{
		private IBuilder builder;
		public Product product = new Product();
		public IBuilder Builder { 
			get { return builder; }
			set { builder = value; } 
			}

		public void BuildGarage()
		{
			builder.BuildGarage(product);
		}
		public void BuildMinimalProduct()
		{
			builder.BuildWalls(product);
			builder.BuildWindows(product);
			builder.BuildRoof(product);
		}

		public void BuildFullProduct()
		{
			builder.BuildWalls(product);
			builder.BuildWindows(product);
			builder.BuildRoof(product);
			builder.BuildGarage(product);
		}

		public Product GetProduct()
		{
			return product;
		}

		public void ResetProduct()
		{
			product = new Product();
		}
	}
	public class Builder : IBuilder
	{
		public Builder()
		{
		}

		public void BuildWalls(Product product)
		{
			product.Add("Part A: Walls");
		}

		public void BuildGarage(Product product)
		{
			product.Add("Part B: Garage");
		}

		public void BuildWindows(Product product)
		{
			product.Add("Part C: Windows");
		}

		public void BuildRoof(Product product)
		{
			product.Add("Part D: Roof");
		}
	}
}
