namespace AdressBook.Commands
{
    public class HomeAddress : IComand
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public int BuldingNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
