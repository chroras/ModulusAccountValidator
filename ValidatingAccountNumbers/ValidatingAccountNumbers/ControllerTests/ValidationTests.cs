using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidatingAccountNumbers.Controllers;
using ValidatingAccountNumbers.Models;
using ValidatingAccountNumbers.Services;

namespace ValidatingAccountNumbers.ControllerTests
{
    public class ValidationTests
    {
        private static readonly IAlgorithmsInterface algorithmsInterface;

        public static void ValidationTestMethod()
        {
            ValidationController ctrl = new ValidationController(algorithmsInterface);
       

            var account = new AccountModel
            {
                SortCode = "",
                AccountNumber = ""
            };
            var result = ctrl.Index(account);

            var viewresult = result.Result as ViewResult;

            if (viewresult.Equals(false))
            {
                throw new Exception("Test failed");
            }

        }
           
    }
}
