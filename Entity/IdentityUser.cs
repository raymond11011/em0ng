
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Entity
{
    public class IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UserId {get;set;}

        public string EmailAddress {get;set;}

        public string FirstName {get;set;}

        public string LastName {get;set;}

        public string Address {get;set;}

        public string Gender {get;set;}

        public DateTime Birthdate {get;set;}

        public int Age {get;set;}
    }
}