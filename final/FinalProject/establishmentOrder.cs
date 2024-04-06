public class EstablishmentOrder : Order
{
    private int _tableNumber;


    public EstablishmentOrder(int tableNumber, string name, string description) : base(name, description)
    {   
        _tableNumber = tableNumber;
    }

    public override bool FinishOrder()
    {
        return true;
    }

    public override string OrderDetails()
    {
        return $"{_tableNumber}";
    } 
}