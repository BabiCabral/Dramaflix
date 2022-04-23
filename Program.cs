using System;

namespace DIO.Doramaflix
{
    class Program
    {
        static DramaRepository repository = new DramaRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                    ListDramas();
                    break;
                    case "2":
                    InsertDrama();
                    break;
                    case "3":
                    UpdateDrama();
                    break;
                    case "4":
                    DeleteDrama();
                    break;
                    case "5":
                    ViewDrama();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thank you for using our services!");
            Console.ReadLine();
        }

        private static void DeleteDrama()
		{
			Console.Write("Enter the Drama Id: ");
			int indexDrama = int.Parse(Console.ReadLine());

            repository.Delete(indexDrama);
            
		}

        private static void ViewDrama()
		{
			Console.Write("Enter the Drama Id: ");
			int indexDrama = int.Parse(Console.ReadLine());

			var drama = repository.ReturnsById(indexDrama);

			Console.WriteLine(drama);
		}

        private static void UpdateDrama()
		{
			Console.Write("Enter the Drama Id: ");
			int indexDrama = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Enter the genre from the options above: ");
			int inputGenre = int.Parse(Console.ReadLine());

			Console.Write("Enter the Drama Title: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Enter the Drama Year: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the Drama Description: ");
			string inputDescription = Console.ReadLine();

			Drama updateDrama = new Drama(id: indexDrama,
										genre: (Genre)inputGenre,
										title: inputTitle,
										year: inputYear,
										description: inputDescription);

			repository.Update(indexDrama, updateDrama);

		}

        private static void ListDramas()
        {
            Console.WriteLine("List Dramas");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No Drama registered.");
                return;
            }

            foreach (var drama in list)
            {   
                var excluded = drama.returnExcluded(); 
                Console.WriteLine("#ID {0}: - {1} - {2}", drama.returnId(), drama.returntitle(), (excluded ? "*Excluded*" : ""));
            }
        }

        private static void InsertDrama()
		{
			Console.WriteLine("Insert new Drama");

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Enter the genre from the options above: ");
			int inputGenre = int.Parse(Console.ReadLine());

			Console.Write("Enter the Drama Title: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Enter the Drama Year: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the Drama Description: ");
			string inputDescription = Console.ReadLine();

			Drama newDrama = new Drama(id: repository.NextId(),
										genre: (Genre)inputGenre,
										title: inputTitle,
										year: inputYear,
										description: inputDescription);

			repository.Insert(newDrama);
		}

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Doramaflix!");
            Console.WriteLine("Inform the chosen option:");

            Console.WriteLine("1 - List Dramas");
            Console.WriteLine("2 - Insert new Drama");
            Console.WriteLine("3 - Update Drama");
            Console.WriteLine("4 - Delete Drama");
            Console.WriteLine("6 - View Drama");
            Console.WriteLine("7 - Clear screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine("");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
        
    }
}
