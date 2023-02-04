namespace Application.Tests.TestData
{
    public class DeliveryAddressesTestData
    {
        public static DeliveryAddresses GetDeliveryAddress()
        {
            return new DeliveryAddresses("Biuro");
        }
    }

    public struct DeliveryAddresses
    {
        public string Name { get; set; }

        public DeliveryAddresses(string name)
        {
            Name = name;
        }
    }
}
