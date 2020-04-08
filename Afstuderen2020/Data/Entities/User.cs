using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Afstuderen2020.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int HouseNumber { get; set; }
        public string HouseNumberAddition { get; set; }
        public string Residence { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PictureId { get; set; }
        public string Role { get; set; }
    }
}
