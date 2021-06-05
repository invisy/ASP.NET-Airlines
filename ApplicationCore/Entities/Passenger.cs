namespace Airlines.ApplicationCore.Entities
{
    public class Passenger  //ValueObject
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string UniquePassportId { get; private set; }
        public int Age { get; private set; }

        public Passenger() {}
        public Passenger(string name, string surname, string patronymic, string uniquePassportId, int age)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            UniquePassportId = uniquePassportId;
            Age = age;
        }
    }
}