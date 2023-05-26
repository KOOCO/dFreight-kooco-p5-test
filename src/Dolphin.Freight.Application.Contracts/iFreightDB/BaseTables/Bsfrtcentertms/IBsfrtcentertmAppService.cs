using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertms
{

    // 如果需要更複雜的必要功能，請改為這種寫法
    public interface IBsfrtcentertmAppService : IApplicationService
    {
        Task<Bsfrtcentertm_Dto> GetAsync(Bsfrtcentertm_Keys id);
        Task<PagedResultDto<Bsfrtcentertm_Dto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<Bsfrtcentertm_Dto> CreateAsync(Bsfrtcentertm_CreateUpdateDto input);
        Task UpdateAsync(Bsfrtcentertm_Keys id, Bsfrtcentertm_CreateUpdateDto input);
        Task DeleteAsync(Bsfrtcentertm_Keys id);
    }



    //  public interface IBsfrtcentertmAppService : ICrudAppService< //Defines CRUD methods
    //      Bsfrtcentertm_Dto, //Used to show books
    //      object[], //Primary key of the book entity
    //      PagedAndSortedResultRequestDto, //Used for paging/sorting
    //      Bsfrtcentertm_CreateUpdateDto> //Used to create/update a book
    // { }
}
