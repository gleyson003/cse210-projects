public class EstablishmentOrder : Order
{
    private int _tableNumber;


    public EstablishmentOrder(int tableNumber, string name, string description) : base(name, description)
    {   
        _tableNumber = tableNumber;
    }

    public override bool FinishOrder()
    {
        _served = true;
        return _served;
    }

    public override void setDescription(string description)
    {
        _description = description;
    }

    public override string OrderDetails()
    {
        return $"The client {_clientName} orders the follow:\n {_description}\n The tablet from this order is {_tableNumber}.";
    } 
}