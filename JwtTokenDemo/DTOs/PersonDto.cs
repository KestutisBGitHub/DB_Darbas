using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Darbas.DTOs
{
    public class PersonDTO
    {

        //[Required(ErrorMessage = "* Required Name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "* Required Surname")]
        public string Surname { get; set; }


        //[StringLength(11, MinimumLength = 11, ErrorMessage = "Not 11 chars, do again")]
        //[Required(ErrorMessage = "* Required PersonalCode")]
        public string PersonalCode { get; set; }
        //[Required(ErrorMessage = "* Required PhoneNumber")]
        public string PhoneNumber { get; set; }
        //[Required(ErrorMessage = "* Required Email")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

    }
}
