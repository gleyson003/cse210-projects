public abstract class Order
{
    protected string _clientName;
    protected string _description;

    public Order (string name, string description)
    {
        _clientName = name;
        _description = description;
    }

    public string GetClientName()
    {
        return _clientName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public abstract bool FinishOrder();

    public abstract string OrderDetails();
}