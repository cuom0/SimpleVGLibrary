//A code by cuom0_ (GitHub)
namespace VerificaCuomo21102024
{
    internal class Program
    {
        struct Videogame
        {
            //Le valutazioni ho scelto che andranno da 0 a 10
            public string? name; //Titolo
            public string? genre; //Genere
            public int[,] ratings; //Valutazioni

            public Videogame()
            {
                name = "";
                genre = "";
                ratings = new int[3, 3];
            }
        }

        static Videogame GameAdd(int r, int c)
        {
            Videogame game = new Videogame();
            Console.Clear();
            Console.WriteLine("Add a Videogame to the Library:");

            Console.Write("\nName:");
            game.name = Console.ReadLine();

            Console.Write("\nGenre:");
            game.genre = Console.ReadLine();

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    int rating;
                    do
                    {
                        Console.Write($"Write the rating of the {i + 1}° player and its {j + 1}° rating category (Only integer values from 0 to 10): ");
                        rating = Convert.ToInt32(Console.ReadLine());

                        if (rating < 0 || rating > 10)
                        {
                            Console.WriteLine("Error! Rating must be between 0 and 10. Retry..");
                        }

                    } while (rating < 0 || rating > 10);

                    game.ratings[i, j] = rating;
                }
            }
            return game;
        }

        static void Main()
        {
            int choice;
            int vidQt = 3, vidAdd = 0, r = 3, c = 3;
            Videogame[] library = new Videogame[vidQt];

            do
            {
                Console.WriteLine("Welcome to Steam");
                Console.WriteLine("\t1) Add a Game to the Steam Library\n\t2) Visualize your library\n\t3) Exit");

                do
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 1 || choice > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Error. Choose a valid option.");
                    }
                } while (choice < 1 || choice > 3);

                switch (choice)
                {
                    case 1:
                        if (vidAdd < vidQt)
                        {
                            library[vidAdd] = GameAdd(r, c);
                            vidAdd++;
                            Console.WriteLine("Click enter to continue...");
                        }
                        else
                        {
                            Console.WriteLine("Library is full. You can't add more games.");
                        }
                        break;

                    case 2:
                        if (vidAdd > 0)
                        {
                            for (int i = 0; i < vidAdd; i++)
                            {
                                int sum = 0;
                                Console.WriteLine($"Game name:\n{library[i].name}:\n\tGenre: {library[i].genre}\n");
                                for (int s = 0; s < r; s++)
                                    for (int j = 0; j < c; j++)
                                    {
                                        Console.WriteLine($"Player {s + 1} rated the {j + 1}° category: {library[i].ratings[s, j]}");
                                        sum += library[i].ratings[s, j];
                                    }
                                double avg = sum / (double)(r * c);
                                Console.WriteLine($"\nThe average rating of {library[i].name} is {avg};");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Add a game first!");
                        }
                        Console.WriteLine("Click enter to continue...");
                        break;

                    case 3:
                        Console.WriteLine("Exiting Steam...");
                        break;
                }

            } while (choice != 3);
        }
    }
}
//GitHub: "Simple Video game Library in C#"