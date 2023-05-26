using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dolphin.Freight.Common
{
    public class ReferenceItemDto
    {
        public Guid Id { get; set; }
        public string ReferenceNo { get; set; }
        public string MblNo { get; set; }
        public int ReferenceType { get; set; }
        public Guid? Pol { get; set; }
        public string PolName { get; set; }
        public Guid? Pod { get; set; }
        public string PodName { get; set; }
        public string Etd { get; set; }
        public string Eta { get; set; }
        public Guid? CarrierId { get; set; }
        public string CarrierName { get; set; }

    }
}
