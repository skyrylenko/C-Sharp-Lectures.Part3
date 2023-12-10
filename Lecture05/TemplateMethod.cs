namespace Lecture05.TemplateMethod
{
	public class TemplateMethodClientCode
	{
		public void TemplateCodeRun()
		{
			School school = new School();
			University university = new University();
			Homeless homeless = new Homeless();
			school.Learn();
			university.Learn();
			homeless.Learn();

			Console.WriteLine();
		}


	}
	abstract class Education
	{
		public void Learn()
		{
			Enter();
			Study();
			PassExams();
			GetDocument();
		}
		public abstract void Enter();
		public abstract void Study();
		public virtual void PassExams()
		{
			Console.WriteLine("Здаємо випускний iспит");
		}
		public abstract void GetDocument();
	}

	class School : Education
	{
		public override void Enter()
		{
			Console.WriteLine("====Школа====");
			Console.WriteLine("Йдемо до першого класу");
		}

		public override void Study()
		{
			Console.WriteLine("Вiдвiдуємо уроки, робимо домашнє завдання");
		}

		public override void GetDocument()
		{
			Console.WriteLine("Отримуємо атестат про середню освiту");
			Console.WriteLine("========");
			Console.WriteLine("");
		}
	}

	class University : Education
	{
		public override void Enter()
		{
			Console.WriteLine("====Унiверситет====");
			Console.WriteLine("Здаємо вступний iспит i вступаємо до ВИШ");
		}

		public override void Study()
		{
			Console.WriteLine("Відвідуємо лекцiї");
			Console.WriteLine("Проходимо практику");
		}

		public override void PassExams()
		{
			Console.WriteLine("Здаємо екзамен за спецiальнiстю");
		}

		public override void GetDocument()
		{
			Console.WriteLine("Отримуємо диплом про вищу освiту");
			Console.WriteLine("========");
			Console.WriteLine("");
		}
	}

	class Homeless : Education
	{
		public new void Learn()
		{
			Console.WriteLine("====Режим \"Я i так розумний\"====");
			Console.WriteLine("Не хочу вчитися");
		}
		public override void Enter()
		{
			Console.WriteLine("========");
		}

		public override void GetDocument()
		{
			Console.WriteLine("========");
		}

		public override void Study()
		{
			Console.WriteLine("========");
			Console.WriteLine("");
		}
	}
}
