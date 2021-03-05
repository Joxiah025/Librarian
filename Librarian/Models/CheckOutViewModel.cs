using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Librarian.Models
{
    public class CheckOutViewModel
    {
            [Required(ErrorMessage = "Borrower's name is required")]
            [Display(Name = "Borrower Name")]
            public string BorrowerName { get; set; }
            [Required(ErrorMessage = "Mobile number is required")]
            [Phone]
            [Display(Name = "Mobile Number")]
            public string PhoneNumber { get; set; }
            [Required(ErrorMessage = "National ID is required")]
            [Display(Name = "National ID")]
            [StringLength(11, ErrorMessage = "National ID must be 11 digits")]
            public string NationalId { get; set; }
    }
}
