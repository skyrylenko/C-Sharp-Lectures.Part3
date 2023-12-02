using Lecture03.Builder;
using Lecture03.Factory;
using Lecture03.Singleton;

namespace Lecture03
{
	public class Program
	{
		static void Main()
		{
			//Singleton
			Console.WriteLine("************************Singleton************************");
			var singletonApproach = new SingletonMain();
			singletonApproach.Main();
			Console.WriteLine();

			//Builder
			Console.WriteLine("************************Builder************************");
			var builderApproach = new MainBuilder();
			builderApproach.Main();
			Console.WriteLine();

			//Factory Method
			Console.WriteLine("************************Factory Method************************");
			var client = new Client();
			client.ClientCode(new ConcreteCreator1());
			client.ClientCode(new ConcreteCreator2());
		}
	}
}
