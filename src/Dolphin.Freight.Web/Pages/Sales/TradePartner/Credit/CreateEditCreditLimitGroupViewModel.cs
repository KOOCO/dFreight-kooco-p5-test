using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Dolphin.Freight.TradePartner;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Dolphin.Freight.Web.Pages.Sales.TradePartner.Credit
{
    public class CreateEditCreditLimitGroupViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [Required]
        public string CreditLimitGroupName { get; set; }
        public CreditTermType CreditTermType { get; set; } = CreditTermType.Days;
        [DisplayName("")]
        public int CreditTermDays { get; set; }
        public PaymentType PaymentType { get; set; } = PaymentType.Cod;
        public int CreditLimit { get; set; }
    }
}
