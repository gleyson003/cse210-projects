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
        return true;
    }

    public override string OrderDetails()
    {
        return _carModel;
    } 
}