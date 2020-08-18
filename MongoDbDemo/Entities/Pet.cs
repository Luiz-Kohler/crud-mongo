namespace MongoDbDemo.Entities
{
    public class Pet
    {
        public string Name { get; set; }
        public string Animal { get; set; }

        public Pet(string name, string animal)
        {
            Name = name;
            Animal = animal;
        }

        public Pet() { }
    }
}
