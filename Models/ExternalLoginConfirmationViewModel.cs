﻿using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Favourite Color")]
        public string MyFavouriteColour { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string CellPhoneNumber { get; set; }

    }
}
