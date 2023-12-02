namespace Lecture03
{
	public sealed class Singleton
	{

		/*	//Main method
				Thread p1 = new Thread(() =>
				{
					var s1 = Singleton.GetSingleton("Test 1");
					Console.WriteLine(s1.Value);
				});
				Thread p2 = new Thread(() =>
				{
					var s1 = Singleton.GetSingleton("Test 2");
					Console.WriteLine(s1.Value);
				});

				p1.Start();
				p2.Start();

				p1.Join();
				p2.Join();
		 */
		private static readonly object _lock = new object();
		private Singleton() { }
		private static Singleton singleton;
		public string Value { get; set; }

		public static Singleton GetSingleton(string value)
		{
			if (singleton == null)
			{ 
				lock (_lock)
				{ 
					if (singleton == null) {
				
						singleton = new Singleton();
						singleton.Value = value;
					}
				}
			}
			return singleton;
		}
	}
}
