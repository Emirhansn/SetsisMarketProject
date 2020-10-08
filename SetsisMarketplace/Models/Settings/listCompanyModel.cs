using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetsisMarketplace.Models.Settings
{
    public class listCompanyModel
    {
        public IList<SelectListItem> CompanyNames { get; set; }

        public IList<SelectListItem> OfficeCodes { get; set; }

        public IList<SelectListItem> WarehouseCodes { get; set; }

    }
}