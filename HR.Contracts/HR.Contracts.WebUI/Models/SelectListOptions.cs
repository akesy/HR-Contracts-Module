using System;
using System.Collections.Generic;

namespace HR.Contracts.WebUI.Models
{
    public class SelectListOptions
    {
        public SelectListOptions()
        {
            this.EnforceNumericValues = false;
            this.SelectChosenValue = true;
            this.IgnoredValues = new List<Enum>();
        }

        public bool EnforceNumericValues { get; set; }

        public bool SelectChosenValue { get; set; }

        public IEnumerable<Enum> IgnoredValues { get; set; }
    }
}