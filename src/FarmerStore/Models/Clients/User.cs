namespace FarmerStore.Models.Clients
{
    public class User : Entity
    {
        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string DocumentId { get; private set; }

        private User(string name, string lastName, string docuementId)
        {
            Name = name;
            LastName = lastName;
            DocumentId = docuementId;
        }

        public static User Build(string name, string lastName, string documentId)
        {
            return new User(name, lastName, documentId);
        }

        ///Cambiar atributos principales del cliente
        public void ChangeMainAttributes(string name, string lastName, string documentId)
        {
            this.Name = name;
            this.LastName = lastName;
            this.DocumentId = documentId;
        }
    }
}
