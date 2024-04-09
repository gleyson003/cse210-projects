public abstract class Order
{
    protected string _clientName;
    protected string _description;
    protected bool _served;

    public Order(string name, string description)
    {
        _clientName = name;
        _description = description;
        _served = false;
    }

    public string GetClientName()
    {
        return _clientName;
    }

    public bool GetServerd()
    {
        return _served;
    }

    public string GetDescription()
    {
        return _description;
    }

    public virtual bool FinishOrder()
    {
        _served = true;
        return _served;
    }

    public virtual void setDescription(string description)
    {
        _description = description;
    }

    public abstract string OrderDetails();
}