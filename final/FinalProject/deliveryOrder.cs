public class DeliveryOrder : Order
{
    private string _address;

    public DeliveryOrder(string address, string name, string description) : base(name, description)
    {
        _address = address;
    }

    public override bool FinishOrder()
    {
        return true;
    }

    public override string OrderDetails()
    {
        return _address;
    } 
}