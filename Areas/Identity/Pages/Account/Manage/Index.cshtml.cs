using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {


            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string Firstname { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Last name")]
            public string Lastname { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Address")]
            public string DeliveryAddress { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "City")]
            public string DeliveryCity { get; set; }
            
            
            [Display(Name = "Zip")]
            public int DeliveryZip { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //var firstName = user.Firstname;
            //var lastName = user.Lastname;
            //var address = user.DeliveryAddress;
            //var city = user.DeliveryCity;
            //var zip = user.DeliveryZip;
            
            Username = userName;

            Input = new InputModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                DeliveryAddress = user.DeliveryAddress,
                DeliveryCity = user.DeliveryCity,
                DeliveryZip = user.DeliveryZip,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.Firstname != user.Firstname)
            {
                user.Firstname = Input.Firstname;
            }

            if (Input.Lastname != user.Lastname)
            {
                user.Lastname = Input.Lastname;
            }

            if (Input.DeliveryAddress != user.DeliveryAddress)
            {
                user.DeliveryAddress = Input.DeliveryAddress;
            }

            if (Input.DeliveryCity != user.DeliveryCity)
            {
                user.DeliveryCity = Input.DeliveryCity;
            }

            if (Input.DeliveryZip != user.DeliveryZip)
            {
                user.DeliveryZip = Input.DeliveryZip;
            }

            if (Input.DeliveryZip != user.DeliveryZip)
            {
                user.DeliveryZip = Input.DeliveryZip;
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
