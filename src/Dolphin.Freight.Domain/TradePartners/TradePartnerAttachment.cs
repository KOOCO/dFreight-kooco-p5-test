using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.TradePartners
{
    /// <summary>
    /// TradePartner Doc
    /// </summary>
    public class TradePartnerAttachment : AuditedAggregateRoot<Guid>, ISoftDelete
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
        public Guid TPId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
