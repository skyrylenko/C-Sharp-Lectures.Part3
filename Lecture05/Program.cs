using Lecture05.TemplateMethod;
using Lecture05.Observer;

namespace Lecture05
{
	internal class Program
	{
		static void Main()
		{
			//Template Method
			var templateMethod = new TemplateMethodClientCode();
			templateMethod.TemplateCodeRun();

			//Observer
			var observerClient = new ObserverClientCode();
			observerClient.ObserverCodeRun();
		}
	}
}
