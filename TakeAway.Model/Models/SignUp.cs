using System;
using System.ComponentModel.DataAnnotations;

namespace TakeAway.Model.Models
{
	public class SignUp
	{
        public Guid RegisterId { get; set; }
        [Required]
        [RegularExpression("^[A - Za - z][A - Za - z0 - 9_]{7, 29}$")]
        public string Name { get; set; }
        [RegularExpression("^[a-zA-Z0-9_! #$%&'*+/=?`{|}~^. -]+@[a-zA-Z0-9. -]+$")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        public string Password { get; set; }
    }
}

