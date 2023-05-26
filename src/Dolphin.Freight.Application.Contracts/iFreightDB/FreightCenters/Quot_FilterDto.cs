using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.iFreightDB.FreightCenters
{
    public class Quot_FilterDto : PagedAndSortedResultRequestDto
    {
        public string FilterPortLoadingCode { get; set; } // 收穫港/裝貨港(機場)
        public string FilterPortDestinationCode { get; set; } // 卸貨港(機場)
        public string FilterSortingMethod { get; set; } // 排序方式
        public string FilterCarrier { get; set; } // 船公司/航空公司
        public string FilterSVCModeTerm { get; set; } // 貿易條件
        public string[] FilterCurrency { get; set; } // 比較幣別
        public string FilterLoad1 { get; set; } // 1 你猜
        public string FilterLoad2 { get; set; } // 2 你再猜
        public string FilterLoad3 { get; set; } // 3 你試著猜
        public string FilterLoad4 { get; set; } // 4 你就猜看看
        public string FilterLoad5 { get; set; } // 5 你就猜一下阿
        public string FilterLoad6 { get; set; } // 6 你為什麼猜不到
    }
}
