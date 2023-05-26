using Dolphin.Freight.ImportExport.Attachments;
using Dolphin.Freight.Settings.SysCodes;
using Dolphin.Freight.TradePartners;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUglify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Dolphin.Freight.Controllers
{
    public class AbpAjaxController : AbpController
    {
        //private IMemoAppService _memoAppService;
        private readonly IWebHostEnvironment _env;
        //public AbpAjaxController(IMemoAppService memoAppService, IWebHostEnvironment env)
        //{
        //    _memoAppService = memoAppService;
        //    _env = env;
        //}
        //public JsonResult GetSysCodeByCodeType(String codeType) 
        //{
        //    var abc = codeType;
        //    List<SysCode> list = new List<SysCode>();
        //    SysCode s = new SysCode();
        //    s.CodeType = "1234";
        //    s.CodeValue = "abcd";
        //    list.Add(s);
        //    return Json(list);
        //}
        //public async Task<JsonResult> GetMemos(Guid Fid, int Ftype) 
        //{
        //    Dictionary<string, object> rs = new Dictionary<string, object>();
        //    var list = await this.GetMemosByQuery(Fid, Ftype);
        //    rs.Add("datas", list);
        //    return Json(rs);
        //}
        //[HttpPost]
        //public async Task<JsonResult> AddOrEditMemo( string Fid, int Ftype, string MemoId, string Subject,string Content)
        //{
        //    Dictionary<string,object> rs = new Dictionary<string , object>();
        //    Guid GFid = new Guid(Fid);
        //    CreateUpdateMemoDto dto = new CreateUpdateMemoDto() { Fid = GFid, Ftype = Ftype,Subject=Subject,Content=Content };
        //    //新增
        //    if (MemoId == null || MemoId.Equals(""))
        //    {
        //        await _memoAppService.CreateAsync(dto);
        //    }
        //    else 
        //    {
        //        Guid GMid = new Guid(MemoId);
        //        await _memoAppService.UpdateAsync(GMid, dto);
        //    }

        //    var list = await this.GetMemosByQuery(GFid, Ftype);
        //    rs.Add("datas", list);
        //    return Json(rs);
        //}
        //private async Task<List<MemoDto>> GetMemosByQuery(Guid Fid, int Ftype) {
        //    QueryMemoDto query = new QueryMemoDto();
        //    query.QueryId = Fid;
        //    query.QueryType = Ftype;
        //    var list = await _memoAppService.QueryListAsync(query);
        //    return list;
        //}
        [HttpPost]
        public IActionResult UploadFile()
        {
            foreach (var formFile in Request.Form.Files)
            {
                var fulPath = Path.Combine(_env.ContentRootPath, "wwwroot\\files", formFile.FileName);
                using (FileStream fs = System.IO.File.Create(fulPath))
                {
                    formFile.CopyTo(fs);
                    fs.Flush();
                }
                return Json("上傳成功");
            }
            return Json("Please Try Again !!");
        }
    }
}
