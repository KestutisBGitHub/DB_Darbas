namespace DB_Darbas
{
    public class Location
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "* Required City")]
        public string City { get; set; }
        //[Required(ErrorMessage = "* Required Street")]
        public string Street { get; set; }
        //[Required(ErrorMessage = "* Required HouseNr")]
        public string HouseNr { get; set; }
        //[Required(ErrorMessage = "* Required AppartmentNr")]
        public string AppartmentNr { get; set; }
        public List<Person> Persons { get; private set; }
    }
}
