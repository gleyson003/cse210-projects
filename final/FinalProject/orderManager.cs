public class OrderManager
{
    private List<Order> _orders;
    private int _orderTotal;

    public OrderManager()
    {
        _orders = new List<Order>();
    }

    public void Start()
    {
        int userChoice = 0;
        
        Console.WriteLine($"Welcome to the Order Manager!");
        do
        {
            Console.WriteLine($"Menu Options:");
            Console.WriteLine("  1. Create New Order");
            Console.WriteLine("  2. List Orders");
            Console.WriteLine("  3. Edit Order");
            Console.WriteLine("  4. Delete Order");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            //I added a validator to the user input
            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 5)
            {
                Console.WriteLine("Invalid choice. Please select a valid option (1-5).");
                Console.Write("Select a choice from the menu: ");
            }

            switch (userChoice)
            {
                case 1:
                    CreateOrder();
                    break;
                case 2:
                    ListOrders();
                    break;
                case 3:
                    EditOrder();
                    break;
                case 4:
                    DeleteOrder();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option (1-5).");
                    break;
            }

        } while (userChoice != 5);
    }

    public void CreateOrder()
    {
        int orderType = 0;
        string orderClientName = "";
        string orderDescription = "";
        bool isValidOrderType = false;

        //I added a validator to the user input
        while (!isValidOrderType)
        {
            Console.WriteLine($"\nThe types of order are:");
            Console.WriteLine("  1. Establishment Order");
            Console.WriteLine("  2. Driver-thru Order");
            Console.WriteLine("  3. DeliveryOrder");
            Console.Write("Which type of order would you like to create? ");

            if (int.TryParse(Console.ReadLine(), out orderType))
            {
                if (orderType >= 1 && orderType <= 3)
                {
                    isValidOrderType = true;
                }
                else
                {
                    Console.WriteLine("Invalid goal type. Please enter a valid type (1, 2, or 3).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer (1, 2, or 3).");
            }
        }

        Console.Write("What is the order's client name? ");
        orderClientName = Console.ReadLine();

        Console.Write("What is a short description of it (foods, drinks, etc.)? ");
        orderDescription = Console.ReadLine();

        bool userIncorrectValue = true;
        while (userIncorrectValue)
        {
            if(orderType == 1)
            {
                
                Console.Write("What is the table's number? ");
                int tableNumber = int.Parse(Console.ReadLine());

                EstablishmentOrder establishmentOrder = new EstablishmentOrder(tableNumber, orderClientName, orderDescription);
                _orders.Add(establishmentOrder);

                userIncorrectValue = false;
            } 
            else if (orderType == 2)
            {   
                Console.Write("What is the car's model? ");
                string carModel = Console.ReadLine();

                Console.Write("What is the car's color? ");
                string carColor = Console.ReadLine();

                Console.Write("What is the car's plate? ");
                string carPlate = Console.ReadLine();

                DriverThruOrder driverOrder = new DriverThruOrder(carModel, carColor, carPlate, orderClientName, orderDescription);
                _orders.Add(driverOrder);

                userIncorrectValue = false;
            }
            else if (orderType == 3) 
            {
                Console.WriteLine("What is the client's address from this order?");
                string address = Console.ReadLine();

                DeliveryOrder deliveryOrder = new DeliveryOrder(address, orderClientName, orderDescription);
                _orders.Add(deliveryOrder);

                userIncorrectValue = false;
            }
            else
            {
                Console.WriteLine("Invalid goal type. Please enter a valid type.");
                orderType = int.Parse(Console.ReadLine());
            }
        }
        
        Console.WriteLine("\nOrder Created. See it in the menu 2 - Orders list.");
        Thread.Sleep(5000);
        Console.Clear();       
    }
    
    public void ListOrders()
    {

    }

    public void EditOrder()
    {

    }

    public void DeleteOrder()
    {

    }
}