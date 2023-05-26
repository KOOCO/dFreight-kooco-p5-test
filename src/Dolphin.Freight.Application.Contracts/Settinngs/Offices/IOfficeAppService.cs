using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dolphin.Freight.Settinngs.Offices
{
    public interface IOfficeAppService
    {
        Task<List<OfficeDto>> GetListAsync();
    }
}
