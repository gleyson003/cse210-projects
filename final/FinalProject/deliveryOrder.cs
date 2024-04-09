public class DeliveryOrder : Order
{
    private string _address;

    public DeliveryOrder(string address, string name, string description) : base(name, description)
    {
        _address = address;
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
        return $"The client {_clientName} orders the follow:\n {_description}\n The address delivery is {_address}.";
    } 
}