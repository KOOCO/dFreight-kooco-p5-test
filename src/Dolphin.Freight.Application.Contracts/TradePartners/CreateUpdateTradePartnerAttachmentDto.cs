using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dolphin.Freight.TradePartners
{
    public class CreateUpdateTradePartnerAttachmentDto
    {
        /// <summary>
        /// 附件名稱 
        /// </summary>
        public string AttachmentName { get; set; }
        /// <summary>
        /// 附件上傳的時間
        /// </summary>
        public DateTime AttachmentUploadTime { get; set; }
        /// <summary>
        /// 附件檔案的大小
        /// </summary>
        public double AttachmentSize { get; set; }
        /// <summary>
        /// 建立者Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Trade Partner Id
        /// </summary>
        [Required]
        public Guid TPId { get; set; }
    }
}
