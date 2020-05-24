using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Entity
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UsersId {get;set;}

        public IdentityUser IdentityUser {get;set;}

        public Guid? UserId {get;set;}

        public AppRole AppRole {get;set;}

        public Guid? AppRoleId {get;set;}
        
    }
}