namespace FarmerStore.Models.Clients
{
    public class Client : Entity
    {
        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string DocumentId { get; private set; }

        private Client(string name, string lastName, string docuementId)
        {
            Name = name;
            LastName = lastName;
            DocumentId = docuementId;
        }

        public static Client Build(string name, string lastName, string documentId)
        {
            return new Client(name, lastName, documentId);
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
