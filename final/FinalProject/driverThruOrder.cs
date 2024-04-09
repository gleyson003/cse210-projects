public class DriverThruOrder : Order
{
    private string _carModel;
    private string _carColor;
    private string _carPlate;


    public DriverThruOrder(string carModel, string carColor, string carPlate, string name, string description) : base(name, description)
    {
        _carModel = carModel;
        _carColor = carColor;
        _carPlate = carPlate;
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
        return $"The client {_clientName} orders the follow:\n {_description}\n The car of this order is a {_carModel} {_carColor} with the plate {_carPlate}.";
    } 
}