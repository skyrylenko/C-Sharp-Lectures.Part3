

namespace Lecture04.ChainOfResponsibility
{
	public class ChainOfResponsibilityClientCode
	{
		public void ChainCodeRun()
		{
			Receiver receiver = new Receiver(false, true, false); //BankTransfer-MoneyTransfer-PayPalTransfer

			PaymentHandler bankPaymentHandler = new BankPaymentHandler();
			PaymentHandler moneyPaymentHadler = new MoneyPaymentHandler();
			PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
			bankPaymentHandler.Successor = paypalPaymentHandler;
			paypalPaymentHandler.Successor = moneyPaymentHadler;

			bankPaymentHandler.Handle(receiver);

			Console.WriteLine("");
		}
	
	}
	class Receiver
	{
		// банківські перекази
		public bool BankTransfer { get; set; }
		// грошові перекази - WesternUnion, Unistream
		public bool MoneyTransfer { get; set; }
		// переказ через PayPal
		public bool PayPalTransfer { get; set; }
		public Receiver(bool bt, bool mt, bool ppt)
		{
			BankTransfer = bt;
			MoneyTransfer = mt;
			PayPalTransfer = ppt;
		}
	}
	abstract class PaymentHandler
	{
		public PaymentHandler Successor { get; set; }
		public abstract void Handle(Receiver receiver);
	}

	class BankPaymentHandler : PaymentHandler
	{
		public override void Handle(Receiver receiver)
		{
			if (receiver.BankTransfer == true)
				Console.WriteLine("Виконуємо банківський переказ");
			else if (Successor != null)
			{
				Console.WriteLine("Банківський переказ неможливий");
				Successor.Handle(receiver);
			}
				
		}
	}
	class PayPalPaymentHandler : PaymentHandler
	{
		public override void Handle(Receiver receiver)
		{
			if (receiver.PayPalTransfer == true)
				Console.WriteLine("Виконуємо переказ через PayPal");
			else if (Successor != null)
			{
				Console.WriteLine("Переказ через PayPal неможливий");
				Successor.Handle(receiver);
			}
		}
	}
	// перекази за допомогою системи грошових переказів
	class MoneyPaymentHandler : PaymentHandler
	{
		public override void Handle(Receiver receiver)
		{
			if (receiver.MoneyTransfer == true)
				Console.WriteLine("Виконуємо переказ через системи грошових переказів");
			else if (Successor != null)
			{
				Console.WriteLine("Переказ через систему грошових переказів неможливий");
				Successor.Handle(receiver);
			}
		}
	}
}
