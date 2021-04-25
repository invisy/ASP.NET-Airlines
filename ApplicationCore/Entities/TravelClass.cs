namespace Airlines.ApplicationCore.Entities
{
    public class TravelClass : BaseEntity<int>
    {
        public string Name { get; private set; }
        public float ClassPrice { get; private set; }

        public TravelClass(string name, float classPrice)
        {
            Name = name;
            ClassPrice = classPrice;
        }
    }
}