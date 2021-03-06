using CrazyBooks_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBooks.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
    {
      _logger = logger;
      _localizer = localizer;

    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
      var cookie = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
      var name = CookieRequestCultureProvider.DefaultCookieName;

      Response.Cookies.Append(name, cookie, new CookieOptions
      {
        Path = "/",
        Expires = DateTimeOffset.UtcNow.AddYears(1),
      });

      return LocalRedirect(returnUrl);
    }

  }
}
