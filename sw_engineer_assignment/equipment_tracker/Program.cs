namespace equipment_tracker;

using equipment_tracker_lib;
class Program
{
    static void Main(string[] args)
    {
        var equipment = new Equipment();

        // A dictionary gets initialized with the possible actions the user can take
        Dictionary<ConsoleKey, Action> actions = new()
        {
            {
                ConsoleKey.A, () =>
                {
                    equipment.AddEquipment();

                    // The first Console.WriteLine() is just to add a line break
                    Console.WriteLine();
                    Console.WriteLine($"Equipment successfully added to: {Equipment.FilePath}");
                }
            },
            {
                ConsoleKey.C, () =>
                {
                    equipment.ChangeStatus();

                    // The first Console.WriteLine() is just to add a line break
                    Console.WriteLine();
                    Console.WriteLine($"Status of equipment successfully changed in: {Equipment.FilePath}");
                }
            },
            {
                ConsoleKey.R, () =>
                {
                    Console.Write("Enter the ID of the equipment: ");
                    int id = int.Parse(Console.ReadLine());

                    equipment.RetrieveStatus(id);
                }
            },
            {
                ConsoleKey.S, () =>
                {
                    equipment.SearchById();
                }
            }
        };
        
        // The Console greets the user and asks for an action
        Console.WriteLine("Welcome to the Equipment Tracker!");
        Console.WriteLine("\n\rWhat would you like to do?");
        Console.WriteLine("A: Add equipment" +
                          "\n\rC: Change status of equipment" +
                          "\n\rR: Retrieve status of equipment" +
                          "\n\rS: Search equipment by ID");
        
        // The user's input gets checked if it matches one of the actions in the dictionary, if not, an exception gets thrown
        if (actions.TryGetValue(Console.ReadKey().Key, out Action? action) && action != null)
        {
            Console.WriteLine();
            try
            {
                action();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
        else
        {
            // The first Console.WriteLine() is just to add a line break
            Console.WriteLine();
            throw new Exception("Invalid action selection.");
        }

        // The user gets asked if they want to perform another action. He can choose to either continue or exit the program
        Console.WriteLine("Would you like to perform another action? (Y/N)");
        var key = Console.ReadKey().Key;
        if (key == ConsoleKey.Y)
        {
            Console.WriteLine();
            Main(args);
        }
        else if (key == ConsoleKey.N)
        {
            Console.WriteLine();
            Console.WriteLine("Goodbye!");
        }
        else
        {
            throw new Exception("Invalid selection.");
        }
    }
}