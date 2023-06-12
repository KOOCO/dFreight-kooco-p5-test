<<<<<<< HEAD

using Dolphin.Freight.ImportExport.AirImports;
=======
﻿using Dolphin.Freight.ImportExport.AirImports;
>>>>>>> DFreight-130
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
<<<<<<< HEAD
using Dolphin.Freight.ImportExport.AirExports;
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.ImportExport.OceanImports;
using Dolphin.Freight.ImportExport.Attachments;
using Dolphin.Freight.Accounting.Invoices;
=======
using Dolphin.Freight.Accounting.Invoices;
using Dolphin.Freight.Web.Pages.AirImports;
using Dolphin.Freight.ImportExport.Attachments;
using Microsoft.AspNetCore.Hosting;
>>>>>>> DFreight-130
using System.IO;

namespace Dolphin.Freight.Web.ViewModels.ImportExport
{
    public class HawbHblViewModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ShowMsg { get; set; }
<<<<<<< HEAD
        [BindProperty]
        public AirImportHawbDto HawbModel { get; set; }
        public OceanExportHblDto OceanExportHbl { get; set; }
        public OceanImportHblDto OceanImportHbl { get; set; }
        public AirExportHawbDto AirExportHawbDto { get; set; }
        public Guid Hid { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<AttachmentDto> FileList { get; set; }

        public OceanExportHblDto OceanExportHblDto { get; set; }
=======
        public List<AttachmentDto> FileList { get; set; }

        [BindProperty]
        public List<AirImportHawbDto> HawbModel { get; set; }

        public AirImportHawbDto AirImportHawbDto { get; set; }

>>>>>>> DFreight-130
        [BindProperty(SupportsGet = true)]
        public IList<InvoiceDto> m0invoiceDtos { get; set; }

        [BindProperty(SupportsGet = true)]
        public IList<InvoiceDto> m1invoiceDtos { get; set; }

        [BindProperty(SupportsGet = true)]
        public IList<InvoiceDto> m2invoiceDtos { get; set; }
        public List<SelectListItem> TradePartnerLookupList { get; set; }
        public List<SelectListItem> SubstationLookupList { get; set; }
        public List<SelectListItem> AirportLookupList { get; set; }
        public List<SelectListItem> PackageUnitLookupList { get; set; }
<<<<<<< HEAD
        public List<SelectListItem> WtValOtherList { get; set; }
=======
>>>>>>> DFreight-130
        public virtual string GetFileSize(string filename)
        {
            string uploadsFolder = Path.Combine("mediaUpload", "AirImports", "DocCenter", Id.ToString());

            try
            {
                long bytes = new FileInfo(Path.Combine(uploadsFolder, filename)).Length;

                return string.Format("{0,2} MB", (bytes / 1024f) / 1024f);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
