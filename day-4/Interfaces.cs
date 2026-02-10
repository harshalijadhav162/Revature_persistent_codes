public interface IElectricityProvider
{
    void SupplyService();
}

public class ElectricityOnlySupplier : IElectricityProvider
{
    public void SupplyService()
    {
        Console.WriteLine("Electricity supplied");
    }
}
