using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.iFreightDB.BaseTables.Stemps
{

    // 如果需要更複雜的必要功能，請改為這種寫法
    public interface IStempAppService : IApplicationService
    {
        Task<Stemp_Dto> GetAsync(Stemp_Keys id);
        Task<PagedResultDto<Stemp_Dto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<Stemp_Dto> CreateAsync(Stemp_CreateUpdateDto input);
        Task UpdateAsync(Stemp_Keys id, Stemp_CreateUpdateDto input);
        Task DeleteAsync(Stemp_Keys id);
    }



    //  public interface IStempAppService : ICrudAppService< //Defines CRUD methods
    //      Stemp_Dto, //Used to show books
    //      Stemp_Keys, //Primary key of the book entity
    //      PagedAndSortedResultRequestDto, //Used for paging/sorting
    //      Stemp_CreateUpdateDto> //Used to create/update a book
    // { }
}
