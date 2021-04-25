namespace Airlines.ApplicationCore.Entities
{
    public class City : BaseEntity<int>
    {
        public string Name { get; private set; }

        public City(string name)
        {
            Name = name;
        }
    }
}