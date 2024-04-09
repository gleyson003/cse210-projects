public class OrderManager
{
    private List<Order> _orders;
    private int _orderToServe;

    public OrderManager()
    {
        _orders = new List<Order>();
        _orderToServe = 0;
    }

    public void Start()
    {
        int userChoice = 0;

        Console.WriteLine($"Welcome to the Order Manager!");
        do
        {
            Console.WriteLine($"\nMenu Options:");
            Console.WriteLine("  1. Create New Order");
            Console.WriteLine("  2. List Orders");
            Console.WriteLine("  3. Resume Order");
            Console.WriteLine("  4. Edit Order");
            Console.WriteLine("  5. Delete Order");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            //Validator to the user input
            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 6)
            {
                Console.WriteLine("Invalid choice. Please select a valid option (1-6).");
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
                    OrderResume();
                    break;
                case 4:
                    EditOrder();
                    break;
                case 5:
                    DeleteOrder();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option (1-6).");
                    break;
            }

        } while (userChoice != 6);
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
            if (orderType == 1)
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

        _orderToServe++;

        Console.WriteLine("\nOrder Created. See it in the menu 2 - Orders list.");
        Thread.Sleep(3000);
        Console.Clear();
    }

    public void ListOrders()
    {
        int index = 1;

        Console.Clear();

        if (_orders.Count > 0)
        {
            foreach (Order o in _orders)
            {
                if (o.GetServerd())
                {
                    Console.WriteLine($"{index} - Served? [X]\n {o.OrderDetails()}\n");
                    index++;
                }
                else
                {
                    Console.WriteLine($"{index} - Served? []\n {o.OrderDetails()}\n");
                    index++;
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("There are not order to show!");
            Thread.Sleep(3000);
            Console.Clear();
        }

    }

    public void EditOrder()
    {
        if (_orders.Count > 0)
        {
            Console.Clear();

            int editOption;

            while (true)
            {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("    1. Finishing order");
                Console.WriteLine("    2. Editing order details");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out editOption) || (editOption != 1 && editOption != 2))
                {
                    Console.WriteLine("Invalid option. Please choose either 1 or 2.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("\nThe orders are: ");
            ListOrders();
            int orderIndex = 0;

            if (editOption == 1)
            {
                Console.Write("Which order do you want to finish? ");
                int orderEditedChoose = int.Parse(Console.ReadLine());

                orderIndex = orderEditedChoose - 1;

                if (orderIndex >= 0 && orderIndex < _orders.Count)
                {
                    Order orderEdited = _orders[orderIndex];

                    orderEdited.FinishOrder();

                    _orderToServe--;

                    Console.WriteLine($"\nThe order {orderEditedChoose} was served!");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid order index. Please choose a valid order to Edit.");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }
            else if (editOption == 2)
            {
                Console.Write("Which order do you want to edit description? ");
                int orderEditedChoose = int.Parse(Console.ReadLine());

                orderIndex = orderEditedChoose - 1;

                if (orderIndex >= 0 && orderIndex < _orders.Count)
                {
                    Console.Write("Enter the new description: ");
                    string newDescription = Console.ReadLine();

                    _orders[orderIndex].setDescription(newDescription);

                    Console.WriteLine($"\nThe description from the order {orderEditedChoose} was updated successfully!");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid order index. Please choose a valid order to Edit.");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("There are not order to Edit!");
            Thread.Sleep(3000);
            Console.Clear();
        }
    }

    public void OrderResume()
    {
        Console.Clear();
        Console.WriteLine($"There are {_orders.Count - _orderToServe} served.");

        if (_orderToServe > 0)
        {
            Console.WriteLine($"{_orderToServe} more to serve all.");
        }
        else
        {
            Console.WriteLine($"No order to serve.");
        }
    }

    public void DeleteOrder()
    {
        if (_orders.Count > 0)
        {
            Console.Clear();

            Console.WriteLine("The orders are: ");
            ListOrders();

            Console.Write("Which order do you want to delete? ");
            int orderToDeleteIndex = int.Parse(Console.ReadLine()) - 1;

            if (orderToDeleteIndex >= 0 && orderToDeleteIndex < _orders.Count)
            {
                _orders.RemoveAt(orderToDeleteIndex);

                Console.WriteLine("\nOrder deleted successfully!");
                Thread.Sleep(3000);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid order index. Please choose a valid order to delete.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("There are not order to Delete!");
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}