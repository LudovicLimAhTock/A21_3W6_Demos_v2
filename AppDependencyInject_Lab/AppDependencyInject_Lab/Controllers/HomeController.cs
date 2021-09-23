﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppDependencyInject_Lab.Models;
using AppDependencyInject_Lab.Models.ViewModels;
using AppDependencyInject_Lab.Service;
using AppDependencyInject_Lab.Utility.AppSettingsClasses;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace AppDependencyInject_Lab.Controllers
{
  public class HomeController : Controller
  {
    public HomeVM homeVM { get; set; }
    private readonly IZombieForecaster _zombieForecaster;
        private readonly StripeSettings _stripeOptions;
        private readonly TwilioSettings _twilioOptions;
        private readonly WazeForecastSettings _wazeOptions;

        // Ajouter la propriété du ZombieForecaster ici version 1



        // Ajouter les propriétés multi-services (Stripe, twilio et waze) Version séparés ici
        // le type: classes Utility



        public HomeController(IOptions<WazeForecastSettings> wazeOptions,
        IOptions<TwilioSettings> twilioOptions,
        IOptions<StripeSettings> stripeOptions, IZombieForecaster zombieForecaster
)
        {
      homeVM = new HomeVM();
            _zombieForecaster = zombieForecaster;
            _stripeOptions = stripeOptions.Value;
            _twilioOptions = twilioOptions.Value;
            _wazeOptions = wazeOptions.Value;

        }


    public IActionResult Index()
    {
            // Version 1 injection dans le contructeur Action Index, récupérer le résultat
            NbrZombiesResult currentNbrZombie = _zombieForecaster.GetVillagePrediction();
            switch (currentNbrZombie.NbrZombiesCondition)
            {
                case NbrZombiesCondition.EnHausse:
                    homeVM.ZombieForecast = "Cours Forest! Cours!";
                    break;
                case NbrZombiesCondition.EnBaisse:
                    homeVM.ZombieForecast = "Relaxe et respire les fleurs. Namsté.";
                    break;
                case NbrZombiesCondition.Imprevisible:
                    homeVM.ZombieForecast = "En ces temps incertains, prends des forces en mangeant du chocolat.";
                    break;
                default:
                    homeVM.ZombieForecast = "L'abonnement ou la vie!";
                    break;
            }



            return View(homeVM);
    }

        #region Action AllConfigSetting version du constructeur muli-services
        public IActionResult AllConfigSettings()
        {
            List<string> messages = new List<string>();
            messages.Add($"Waze config - Forecast tracker : " + _wazeOptions.WazeTrackerEnabled);
            messages.Add($"Stripe Publishable key : " + _stripeOptions.PublishableKey);
            messages.Add($"Stripe Secret key : " + _stripeOptions.SecretKey);
            messages.Add($"Twilio Phone : " + _twilioOptions.PhoneNumber);
            messages.Add($"Twilio SID : " + _twilioOptions.AccountSid);
            messages.Add($"Twilio Token : " + _twilioOptions.AuthToken);
            return View(messages);
        }


        #endregion

        public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
