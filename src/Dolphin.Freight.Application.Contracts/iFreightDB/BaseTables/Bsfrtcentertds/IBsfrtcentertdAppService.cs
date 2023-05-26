using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertds
{

    // 如果需要更複雜的必要功能，請改為這種寫法
    public interface IBsfrtcentertdAppService : IApplicationService
    {
        Task<Bsfrtcentertd_Dto> GetAsync(Bsfrtcentertd_Keys id);
        Task<PagedResultDto<Bsfrtcentertd_Dto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<Bsfrtcentertd_Dto> CreateAsync(Bsfrtcentertd_CreateUpdateDto input);
        Task UpdateAsync(Bsfrtcentertd_Keys id, Bsfrtcentertd_CreateUpdateDto input);
        Task DeleteAsync(Bsfrtcentertd_Keys id);
    }

    //  public interface IBsfrtcentertdAppService : ICrudAppService< //Defines CRUD methods
    //      Bsfrtcentertd_Dto, //Used to show books
    //      object[], //Primary key of the book entity
    //      PagedAndSortedResultRequestDto, //Used for paging/sorting
    //      Bsfrtcentertd_CreateUpdateDto> //Used to create/update a book
    // { }
}
