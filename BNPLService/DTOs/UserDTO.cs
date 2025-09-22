using System;
using System.ComponentModel.DataAnnotations;

namespace BNPLService.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
       
        public string FullName { get; set; }
        public string Email { get; set; }

    }
}

