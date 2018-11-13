using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidatingAccountNumbers.Models
{
    public class AccountModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d{6}$")]
        public string SortCode { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d{6}$")]
        public string AccountNumber { get; set; }

    }
}
