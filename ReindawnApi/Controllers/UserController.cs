using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Reindawn.Repository;
using ReindawnApi.App_Start;
using ReindawnApi.Models;
using System.Data.Entity;
using System.Web.Http.Results;
using Reindawn.Domain.Models;


namespace ReindawnApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IdentityConfig.ApplicationSignInManager _signInManager;
        private IdentityConfig.ApplicationUserManager _userManager;
        private IUnitOfWork _unitOfWork = new UnitOfWork();


        //[Route("")]
        //public IEnumerable<Product> GetAllUsers([FromUri]Product product)
        //{
        //    var res = products.Where((p) => p.Name == product.Name);

        //    return res;
        //}

        [Route("login")]
        [HttpPost]
        //[ResponseType(typeof(LoginViewModel))]
        public async Task<IHttpActionResult> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    var userId = new Guid(User.Identity.GetUserId());
                    var user = await UserManager.FindByIdAsync(userId);
                    return Ok(model);
                default:
                    return new ResponseMessageResult(
                        Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            "invalid login"));
            }
        }

        [Route("getUserId")]
        [HttpGet]
        //[ResponseType(typeof(LoginViewModel))]
        public IHttpActionResult GetUserId()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                return Ok(userId);
            }
            return NotFound();
        }

        [Route("register")]
        [HttpPost]
        //[ResponseType(typeof(RegisterViewModel))]
        public async Task<IHttpActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User {UserName = model.Email, Email = model.Email};
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return Ok(model);
                }
                AddErrors(result);
            }

            List<string> errors =
                (from modelState in ModelState.Values from error in modelState.Errors select error.ErrorMessage).ToList();
            return new ResponseMessageResult(
                Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Join(";", errors)));

        }


        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public IdentityConfig.ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<IdentityConfig.ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public IdentityConfig.ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<IdentityConfig.ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

    }
}
