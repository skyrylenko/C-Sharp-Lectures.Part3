using Lecture04.ChainOfResponsibility;
using Lecture04.Adapter;
using Lecture04.Decorator;

namespace Lecture04
{
	internal class Program
	{
		static void Main()
		{
			//Chain-Of-Responsibility
			var chainOfResponsibilityClientCode = new ChainOfResponsibilityClientCode();
			chainOfResponsibilityClientCode.ChainCodeRun();

			//Adapter
			var adapterClientCode = new AdapterClientCode();
			adapterClientCode.AdapterCodeRun();

			//Decorator
			var decoratorClientCode = new DecoratorClientCode();
			decoratorClientCode.DecoratorCodeRun();
		}

	}
}