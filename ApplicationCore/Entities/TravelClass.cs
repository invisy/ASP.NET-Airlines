namespace Airlines.ApplicationCore.Entities
{
    public class TravelClass : BaseEntity<int>
    {
        public string Name { get; set; }
        public float ClassPrice { get; set; }

        public TravelClass(string name, float classPrice)
        {
            Name = name;
            ClassPrice = classPrice;
        }
    }
}