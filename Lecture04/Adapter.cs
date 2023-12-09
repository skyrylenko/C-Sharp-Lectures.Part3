namespace Lecture04.Adapter
{
	public class AdapterClientCode
	{
		public void AdapterCodeRun() 
		{
			// мандрівник
			Driver driver = new Driver();
			// машина
			Auto auto = new Auto();
			// рушаємо в мандри
			driver.Travel(auto);
			// зустрілись з пісками, треба використовувати верблюдів
			Camel camel = new Camel();
			// використовуємо адаптер
			ITransport camelTransport = new CamelToTransportAdapter(camel);
			// продовжуємо шлях пісками пустелі
			driver.Travel(camelTransport);

			Console.WriteLine("");
		}
	}

	interface ITransport
	{
		void Drive();
	}
	// клас машини
	class Auto : ITransport
	{
		public void Drive()
		{
			Console.WriteLine("Машина їде по дорозі");
		}
	}
	class Driver
	{
		public void Travel(ITransport transport)
		{
			transport.Drive();
		}
	}
	// інтерфейс тварини
	interface IAnimal
	{
		void Move();
	}
	// клас верблюда
	class Camel : IAnimal
	{
		public void Move()
		{
			Console.WriteLine("Верблюд іде пісками пустелі");
		}
	}
	// Адаптер від Camel до ITransport
	class CamelToTransportAdapter : ITransport
	{
		Camel camel;
		public CamelToTransportAdapter(Camel c)
		{
			camel = c;
		}

		public void Drive()
		{
			camel.Move();
		}
	}

}
