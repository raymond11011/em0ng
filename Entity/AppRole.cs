using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Entity
{
    public class AppRole
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         [Key]
         public Guid AppRoleId{get;set;}

         public string AppRoleName{get;set;}
    }
}