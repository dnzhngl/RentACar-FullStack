using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.DTOs
{
    public class ChangePasswordDto:IDto
    {
        public int Id { get; set; }
        public string NewPassword { get; set; }
    }
}
