using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AppDependencyInject_Lab.Controllers
{
  public class LifeTimeController : Controller
  {
    #region Créer une propriété pour chaque service lifeTime ici
   

    #endregion

    #region Modifier le constructor controller ici
    public LifeTimeController()
    {

    }
    #endregion


    public IActionResult Index()
    {
      #region Afficher les ID des trois lifeTime ici
      
      #endregion

      return View();
    }
  }
}
