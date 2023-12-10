namespace Lecture05.Observer
{
	public class ObserverClientCode
	{
		public void ObserverCodeRun()
		{
			Stock stock = new Stock();
			Bank bank = new Bank("Приватбанк", stock);
			Broker broker = new Broker("Петро Галушка", stock);
			// імітація торгів
			stock.Market();
			// брокер припиняє спостерігати за торгами
			broker.StopTrade();
			// імітація торгів
			stock.Market();
 
			Console.WriteLine();
		}
	}
	interface IObserver
	{
		void Update(Object ob);
	}

	interface IObservable
	{
		void RegisterObserver(IObserver o);
		void RemoveObserver(IObserver o);
		void NotifyObservers();
	}

	class Stock : IObservable
	{
		StockInfo sInfo; // інформація про торги

		List<IObserver> observers;
		public Stock()
		{
			observers = new List<IObserver>();
			sInfo = new StockInfo();
		}
		public void RegisterObserver(IObserver o)
		{
			observers.Add(o);
		}

		public void RemoveObserver(IObserver o)
		{
			observers.Remove(o);
		}

		public void NotifyObservers()
		{
			foreach (IObserver o in observers)
			{
				o.Update(sInfo);
			}
		}

		public void Market()
		{
			Random rnd = new Random();
			sInfo.USD = rnd.Next(35, 45);
			sInfo.Euro = rnd.Next(45, 50);
			Console.WriteLine("Курс євро на торгах {0}", sInfo.Euro);
			Console.WriteLine("Курс долара на торгах {0}", sInfo.USD);
			NotifyObservers();
		}
	}

	class StockInfo
	{
		public int USD { get; set; }
		public int Euro { get; set; }
	}

	class Broker : IObserver
	{
		public string Name { get; set; }
		IObservable stock;
		public Broker(string name, IObservable obs)
		{
			this.Name = name;
			stock = obs;
			stock.RegisterObserver(this);
		}
		public void Update(object ob)
		{
			StockInfo sInfo = (StockInfo)ob;

			if (sInfo.USD > 30)
				Console.WriteLine("Брокер {0} продає долари;  Курс долару: {1}", this.Name, sInfo.USD);
			else
				Console.WriteLine("Брокер {0} купує долари;  Курс долару: {1}", this.Name, sInfo.USD);
		}
		public void StopTrade()
		{
			stock.RemoveObserver(this);
			stock = null;
		}
	}

	class Bank : IObserver
	{
		public string Name { get; set; }
		IObservable stock;
		public Bank(string name, IObservable obs)
		{
			this.Name = name;
			stock = obs;
			stock.RegisterObserver(this);
		}
		public void Update(object ob)
		{
			StockInfo sInfo = (StockInfo)ob;

			if (sInfo.Euro > 40)
				Console.WriteLine("Банк {0} продає євро;  Курс євро: {1}", this.Name, sInfo.Euro);
			else
				Console.WriteLine("Банк {0} купує євро;  Курс євро: {1}", this.Name, sInfo.Euro);
		}
	}

}
