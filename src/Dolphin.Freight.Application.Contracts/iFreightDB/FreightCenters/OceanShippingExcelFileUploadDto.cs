using System.ComponentModel.DataAnnotations;

namespace Dolphin.Freight.iFreightDB.FreightCenters
{
    public class OceanShippingExcelFileUploadDto
    {
        [Required]
        public string userId { get; set; }
        public byte[] fileContent { get; set; }
    }
}
