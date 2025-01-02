using Certificates2024.Data;
using Certificates2024.Data.Services;
using Certificates2024.Data.Static;
using Certificates2024.Data.ViewModels;
using Certificates2024.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Certificates2024.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly ICandidatesService _service;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, ICandidatesService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _service = service;
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.ToListAsync();
            var userWithRolesList = new List<UserWithRoleViewModel>();

            foreach (var user in users)
            {
                // Get the role for the current user (assuming only one role)
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();  // Assuming one role per user

                userWithRolesList.Add(new UserWithRoleViewModel
                {
                    User = user,
                    Role = role
                });
            }
            return View(userWithRolesList);
        }
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home"); //page, controller
                    }
                }
                TempData["Error"] = "Wrong credentials, wrong password. Please, try again!";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong credentials, email not found. Please, try again!";
            return View(loginVM);
        }
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid && registerVM.BirthDate >= new DateTime(1900, 1, 1))
            {
                var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
                if (user != null)
                {
                    TempData["Error"] = "This email address is already in use";
                    return View(registerVM);
                }

                var newUser = new ApplicationUser()
                {
                    FullName = $"{registerVM.FirstName} {registerVM.LastName}",
                    Email = registerVM.EmailAddress,
                    UserName = registerVM.EmailAddress
                };
                // Save the ApplicationUser to the database
                var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
                if (!newUserResponse.Succeeded)
                {
                    foreach (var error in newUserResponse.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(registerVM);
                }
                var newCandidate = new Candidate()
                {
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    BirthDate = registerVM.BirthDate,
                    PhotoIdNumber = registerVM.PhotoIdNumber,
                    Email = registerVM.EmailAddress,
                    ApplicationUserId = newUser.Id
                };
                await _service.AddAsync(newCandidate);

                if (newUserResponse.Succeeded)
                    await _userManager.AddToRoleAsync(newUser, UserRoles.User);

                return View("RegisterCompleted");


            }
            else return View(registerVM);

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); //action, controller
        }
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
        //UPDATE !!! //
        public async Task<IActionResult> UserDetails()  //View!
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login");
            }
            // UPDATE 2/1/25 Show in Details if Booked Exams
            // Retrieve the Candidate associated with the current user
            var candidate = await _context.Candidates
                                          .Include(c => c.CandidateCertificates) // Include the certificates booked by the candidate
                                          .ThenInclude(cc => cc.CertificateTopic) // Optionally include the certificate topic (exam details)
                                          .FirstOrDefaultAsync(c => c.ApplicationUserId == currentUser.Id); // Find the candidate based on the user ID

            // Check if the candidate has any booked exams (CandidateCertificates)
            var bookedExams = candidate?.CandidateCertificates;

            // Pass the current user and booked exams to the view using ViewBag
            ViewBag.CurrentUser = currentUser;
            ViewBag.BookedExams = bookedExams;

            //END UPDATE!
            return View(currentUser);
        }
    }
}