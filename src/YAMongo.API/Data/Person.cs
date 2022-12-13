namespace YAMongo.API.Data
{
    public class Person
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public override string ToString()
        {
            return $"Name:{Name}, Id:{Id}";
        }
    }
}
