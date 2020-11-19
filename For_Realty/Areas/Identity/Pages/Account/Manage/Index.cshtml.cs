using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using For_Realty.Areas.Identity.Data;
using For_Realty.Data;
using For_Realty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace For_Realty.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AccountUser> _userManager;
        private readonly SignInManager<AccountUser> _signInManager;
        private readonly For_RealtyDbContext _context;

        public IndexModel(
            UserManager<AccountUser> userManager,
            SignInManager<AccountUser> signInManager,
            For_RealtyDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [DataType(DataType.Text)]
            [Display(Name = "Voornaam")]
            public string Givenname { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Achternaam")]
            public string Surname { get; set; }

            [Phone]
            [Display(Name = "Telefoonnr")]
            public string PhoneNumber { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Stad")]
            public string City { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Postcode")]
            public string ZIP { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Straat")]
            public string Street { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Huisnr")]
            public string HouseNr { get; set; }
        }

        private async Task LoadAsync(AccountUser accountUser)
        {
            var userName = await _userManager.GetUserNameAsync(accountUser);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(accountUser);
            Username = userName;

            UserAccount user = await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserID == accountUser.Id);
            accountUser.UserAccount = user;

            Input = new InputModel
            {
                Givenname = accountUser.UserAccount.Givenname,
                Surname = accountUser.UserAccount.Surname,
                PhoneNumber = phoneNumber,
                City = accountUser.UserAccount.City,
                ZIP = accountUser.UserAccount.ZIP,
                Street = accountUser.UserAccount.Street,
                HouseNr = accountUser.UserAccount.HouseNr
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kan de gebruiker met id '{_userManager.GetUserId(User)}' niet vinden.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kan de user met ID '{_userManager.GetUserId(User)}' niet vinden.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            UserAccount userAccount = await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserID == user.Id);
            user.UserAccount = userAccount;

            if (Input.Givenname != user.UserAccount.Givenname)
            {
                user.UserAccount.Givenname = Input.Givenname;
            }

            if (Input.Surname != user.UserAccount.Surname)
            {
                user.UserAccount.Surname = Input.Surname;
            }

            if (Input.City != user.UserAccount.City)
            {
                user.UserAccount.City = Input.City;
            }

            if (Input.ZIP != user.UserAccount.ZIP)
            {
                user.UserAccount.ZIP = Input.ZIP;
            }

            if (Input.Street != user.UserAccount.Street)
            {
                user.UserAccount.Street = Input.Street;
            }

            if (Input.HouseNr != user.UserAccount.HouseNr)
            {
                user.UserAccount.HouseNr = Input.HouseNr;
            }


            var username = await _userManager.GetUserNameAsync(user);
            if (Username != username)
            {
                var setUsernameResult = await _userManager.SetPhoneNumberAsync(user, Username);
                if (!setUsernameResult.Succeeded)
                {
                    StatusMessage = "Onverwachte error bij het ophalen van het mailadres.";
                    return RedirectToPage();
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Onverwachte error bij het ophalen van het telefoonnummer.";
                    return RedirectToPage();
                }
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Uw profiel is geupdate!";
            return RedirectToPage();
        }
    }
}
