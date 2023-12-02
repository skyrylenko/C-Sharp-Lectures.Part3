namespace Lecture03.Factory
{
	public class Client
	{
		public void ClientCode(Creator creator)
		{
			Console.WriteLine(creator.NewOperation());
		}
	}

	public class ConcreteCreator1 : Creator
	{
		public ConcreteCreator1()
		{
			Console.WriteLine("ConcreteCreator1");
		}
		public override IProduct FactoryMethod()
		{
			return new ConcreteProduct1();
		}
	}

	public class ConcreteCreator2 : Creator
	{
		public ConcreteCreator2()
		{
			Console.WriteLine("ConcreteCreator2");
		}
		public override IProduct FactoryMethod()
		{
			return new ConcreteProduct2();
		}
	}

	public abstract class Creator
	{
		public abstract IProduct FactoryMethod();
		public string NewOperation()
		{
			var product = FactoryMethod();
			var result = $"Creator : {product.Operation()}";
			return result;
		}
	}

	public interface IProduct
	{
		string Operation();
	}

	public class ConcreteProduct1 : IProduct
	{
		public string Operation()
		{
			return "ConcreteProduct1";
		}
	}

	public class ConcreteProduct2 : IProduct
	{
		public string Operation()
		{
			return "ConcreteProduct2";
		}
	}
}
