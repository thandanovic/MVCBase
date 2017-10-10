using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBase.Models
{
    public class BaseViewModel
    {
        public string AlertMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}