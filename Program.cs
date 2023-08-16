using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
internal class Program : ProgramBase
{

    public class Reservation
    {
        public Reservation()
        {
        }

        public string Name { get; set; }
        public int NumberOfNights { get; set; }
        public bool RoomService { get; set; }



        public double Totalcost
        {
            get
            {

                double cost;
                if (NumberOfNights >= 1 && NumberOfNights <= 3)
                {
                    cost = NumberOfNights * 100;
                }
                else if (NumberOfNights >= 4 && NumberOfNights <= 10)
                {
                    cost = NumberOfNights * 80.5;
                }
                else
                {
                    cost = NumberOfNights * 75.3;
                }

                if (RoomService.ToLower() == "yes")
                {
                    cost += (cost * 0.10);
                }

                return cost;
            }
        }

        class Program
        {
            static List<Customer> customers = new List<Customer>();

            static void Main(string[] args)
            {
                Console.WriteLine("\t\t\tWelcome to Sydney Hotel");

                while (true)
                {
                    InputCustomerDetails();
                    Console.WriteLine("________________________________________");

                    Console.WriteLine("Press 'q' to exit or any other key to continue:");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "q")
                    {
                        break;
                    }
                }

                DisplaySummary();
                FindHighestAndLowestSpending();
            }

            static void InputCustomerDetails()
            {
                Console.WriteLine("Enter Customer Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Number of Nights (1-20):");
                int numberOfNights = 0;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out numberOfNights) && numberOfNights >= 1 && numberOfNights <= 20)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of nights. Please enter a number between 1 and 20:");
                    }
                }

                Console.WriteLine("Enter 'yes' if you want room service, otherwise enter 'no':");
                string roomService = Console.ReadLine();

                customers.Add(new Customer(name, numberOfNights, roomService));
            }

            static void DisplaySummary()
            {
                Console.WriteLine("\t\t\tSummary of Reservations");
                Console.WriteLine("Name\t\tNumber of Nights\t\tRoom Service\t\tCharge");

                foreach (Customer customer in customers)
                {
                    double cost = customer.CalculateTotalCost();
                    Console.WriteLine($"{customer.Name}\t\t{customer.NumberOfNights}\t\t\t{customer.RoomService}\t\t\t{cost}");
                }
            }

            private static void FindHighestAndLowestSpending()
            {
                double highestSpending = double.MinValue;
                double lowestSpending = double.MaxValue;
                string highestSpendingCustomer = "";
                string lowestSpendingCustomer = "";

                foreach (Customer customer in customers)
                {
                    double cost = customer.CalculateTotalCost();

                    if (cost > highestSpending)
                    {
                        highestSpending = cost;
                        highestSpendingCustomer = customer.Name;
                    }

                    if (cost < lowestSpending)
                    {
                        lowestSpending = cost;
                        lowestSpendingCustomer = customer.Name;
                    }
                }

                Console.WriteLine("Customer spending the most is " + highestSpendingCustomer + " $" + highestSpending);
                Console.WriteLine("Customer spending the least is " + lowestSpendingCustomer + " $" + lowestSpending);
            }
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}