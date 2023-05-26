using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace Dolphin.Freight.EntityFrameworkCore;

[ConnectionStringName("iFreightDB")]
public class IfreightDbContext : AbpDbContext<IfreightDbContext>
{
    public IfreightDbContext(DbContextOptions<IfreightDbContext> options) : base(options) { }

    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region 自己加的實體模型

    public virtual DbSet<iFreightDB.BaseTables.Stemps.Stemp> Stemps { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Bsfrtcentertms.Bsfrtcentertm> Bsfrtcentertms { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Bsfrtcentertds.Bsfrtcentertd> Bsfrtcentertds { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp> BsfrtcentertExcelTemps { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.BsfrtcentertPortMappings.BsfrtcentertPortMapping> BsfrtcentertPortMappings { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Bscodes.Bscode> Bscodes { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Bscss.Bscs> Bscss { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Bschgcds.Bschgcd> Bschgcds { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Bscitys.Bscity> Bscities { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Bscurs.Bscur> Bscurs { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Gfgroups.Gfgroup> Gfgroups { get; set; }
    public virtual DbSet<iFreightDB.BaseTables.Gfcompanys.Gfcompany> Gfcompanies { get; set; }

    #endregion

    #region 自己加的方法

    /// <summary>
    /// 接收 SQL 語句並回傳 DataTable
    /// </summary>
    /// <param name="sqlQuery">查詢語句</param>
    /// <returns></returns>
    public DataTable ExecuteSqlQueryToDataTable(string sqlQuery)
    {
        // 由於 SqlDataAdapter 在填充時會自動連接與關閉連線，若未來可能查詢多個SQL時手動開啟連線會是更好的選擇

        var connection = new SqlConnection(Database.GetConnectionString());

        try
        {
            using var command = connection.CreateCommand();
            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;

            using var adapter = new SqlDataAdapter((SqlCommand)command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 舊資料庫應該是用這個編碼
        modelBuilder.UseCollation("Chinese_PRC_CI_AS");

        #region 自己加的實體映射

        modelBuilder.Entity<iFreightDB.BaseTables.Stemps.Stemp>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.EmpId });

            entity.ToTable("STEMP");

            entity.HasIndex(e => e.EmpId, "<STEMP_INDEX01,>");

            entity.HasIndex(e => new { e.GroupId, e.EmpId, e.Stn, e.SalesFlag, e.FStatus, e.EmpMail }, "IX_BI");

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID");

            entity.Property(e => e.EmpId)
                .HasMaxLength(20)
                .HasColumnName("EMP_ID");

            entity.Property(e => e.ApproveAgntType)
                .HasMaxLength(10)
                .HasColumnName("APPROVE_AGNT_TYPE")
                .HasComment("審核帳單類型");

            entity.Property(e => e.ApproveCustType)
                .HasMaxLength(10)
                .HasColumnName("APPROVE_CUST_TYPE")
                .HasComment("審核客戶類型");

            entity.Property(e => e.Cmp)
                .HasMaxLength(2)
                .HasColumnName("CMP");

            entity.Property(e => e.CmpChoice)
                .HasMaxLength(500)
                .HasColumnName("CMP_CHOICE");

            entity.Property(e => e.CmpCust)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("CMP_CUST");

            entity.Property(e => e.CmpLogin)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("CMP_LOGIN");

            entity.Property(e => e.CmpRole)
                .HasMaxLength(600)
                .HasColumnName("CMP_ROLE")
                .HasComment("公司角色");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .HasColumnName("CREATE_BY");

            entity.Property(e => e.CreateDate)
                .HasPrecision(0)
                .HasColumnName("CREATE_DATE");

            entity.Property(e => e.CustType)
                .HasMaxLength(100)
                .HasColumnName("CUST_TYPE")
                .HasDefaultValueSql("('*')");

            entity.Property(e => e.Dep)
                .HasMaxLength(2)
                .HasColumnName("DEP");

            entity.Property(e => e.DepChoice)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("DEP_CHOICE");

            entity.Property(e => e.EmpCell)
                .HasMaxLength(50)
                .HasColumnName("EMP_CELL");

            entity.Property(e => e.EmpCnm)
                .HasMaxLength(40)
                .HasColumnName("EMP_CNM");

            entity.Property(e => e.EmpEnm)
                .HasMaxLength(40)
                .HasColumnName("EMP_ENM");

            entity.Property(e => e.EmpFax)
                .HasMaxLength(35)
                .HasColumnName("EMP_FAX");

            entity.Property(e => e.EmpIsshare)
                .HasMaxLength(1)
                .HasColumnName("EMP_ISSHARE");

            entity.Property(e => e.EmpMail)
                .HasMaxLength(200)
                .HasColumnName("EMP_MAIL");

            entity.Property(e => e.EmpMsn)
                .HasMaxLength(50)
                .HasColumnName("EMP_MSN");

            entity.Property(e => e.EmpPass)
                .HasMaxLength(40)
                .HasColumnName("EMP_PASS");

            entity.Property(e => e.EmpPassSha512)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("EMP_PASS_SHA512")
                .HasComment("以SHA512加密的密碼");

            entity.Property(e => e.EmpQq)
                .HasMaxLength(20)
                .HasColumnName("EMP_QQ");

            entity.Property(e => e.EmpSkype)
                .HasMaxLength(20)
                .HasColumnName("EMP_SKYPE");

            entity.Property(e => e.EmpTel)
                .HasMaxLength(35)
                .HasColumnName("EMP_TEL");

            entity.Property(e => e.EmpTitle)
                .HasMaxLength(50)
                .HasColumnName("EMP_TITLE");

            entity.Property(e => e.EntryDate)
                .HasPrecision(0)
                .HasColumnName("ENTRY_DATE");

            entity.Property(e => e.EvidentPass)
                .HasMaxLength(40)
                .HasColumnName("EVIDENT_PASS");

            entity.Property(e => e.FStatus)
                .HasMaxLength(1)
                .HasColumnName("F_STATUS");

            entity.Property(e => e.Favorites)
                .HasMaxLength(1)
                .HasColumnName("FAVORITES");

            entity.Property(e => e.GuiDep)
                .HasMaxLength(2)
                .HasColumnName("GUI_DEP");

            entity.Property(e => e.HomeRole)
                .HasMaxLength(600)
                .HasColumnName("HOME_ROLE")
                .HasComment("居家角色");

            entity.Property(e => e.IesId)
                .HasMaxLength(20)
                .HasColumnName("IES_ID");

            entity.Property(e => e.IfVersion)
                .HasMaxLength(15)
                .HasColumnName("IF_VERSION")
                .HasComment("iFreight版本");

            entity.Property(e => e.InternalFlag)
                .HasMaxLength(1)
                .HasColumnName("INTERNAL_FLAG");

            entity.Property(e => e.IsOnline)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("IS_ONLINE");

            entity.Property(e => e.LastAccessIp)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LAST_ACCESS_IP");

            entity.Property(e => e.LastAccessTime)
                .HasPrecision(0)
                .HasColumnName("LAST_ACCESS_TIME");

            entity.Property(e => e.LastmodifyPsw)
                .HasColumnType("datetime")
                .HasColumnName("LASTMODIFY_PSW");

            entity.Property(e => e.LeaveDate)
                .HasPrecision(0)
                .HasColumnName("LEAVE_DATE");

            entity.Property(e => e.MailPsw)
                .HasMaxLength(40)
                .HasColumnName("MAIL_PSW");

            entity.Property(e => e.MailUser)
                .HasMaxLength(70)
                .HasColumnName("MAIL_USER");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(20)
                .HasColumnName("MODIFY_BY");

            entity.Property(e => e.ModifyDate)
                .HasPrecision(0)
                .HasColumnName("MODIFY_DATE");

            entity.Property(e => e.OceanLine)
                .HasMaxLength(10)
                .HasColumnName("OCEAN_LINE");

            entity.Property(e => e.OceanLineNm)
                .HasMaxLength(200)
                .HasColumnName("OCEAN_LINE_NM");

            entity.Property(e => e.OwnLeader)
                .HasMaxLength(20)
                .HasColumnName("OWN_LEADER");

            entity.Property(e => e.SalesCs)
                .HasColumnName("SALES_CS")
                .HasComment("業務的CS");

            entity.Property(e => e.SalesDepId)
                .HasMaxLength(20)
                .HasColumnName("SALES_DEP_ID");

            entity.Property(e => e.SalesFlag)
                .HasMaxLength(1)
                .HasColumnName("SALES_FLAG");

            entity.Property(e => e.SalesdepChoice)
                .HasMaxLength(1000)
                .HasColumnName("SALESDEP_CHOICE");

            entity.Property(e => e.SelfFlag)
                .HasMaxLength(1)
                .HasColumnName("SELF_FLAG");

            entity.Property(e => e.Stn)
                .HasMaxLength(3)
                .HasColumnName("STN");

            entity.Property(e => e.StnChoice)
                .HasMaxLength(120)
                .HasColumnName("STN_CHOICE");

            entity.Property(e => e.StnCust)
                .HasMaxLength(120)
                .HasColumnName("STN_CUST");

            entity.Property(e => e.StnLogin)
                .HasMaxLength(120)
                .HasColumnName("STN_LOGIN");

            entity.Property(e => e.VpnFromDate)
                .HasPrecision(0)
                .HasColumnName("VPN_FROM_DATE")
                .HasComment("VPN開始時間");

            entity.Property(e => e.VpnToDate)
                .HasPrecision(0)
                .HasColumnName("VPN_TO_DATE")
                .HasComment("VPN結束時間");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Bsfrtcentertms.Bsfrtcentertm>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.Cmp, e.Stn, e.JobNo })
                .HasName("PK__BSFRTCEN__53299E3AA70FCD67");

            entity.ToTable("BSFRTCENTERTM");

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID")
                .HasComment("集團");

            entity.Property(e => e.Cmp)
                .HasMaxLength(3)
                .HasColumnName("CMP")
                .HasComment("公司");

            entity.Property(e => e.Stn)
                .HasMaxLength(3)
                .HasColumnName("STN")
                .HasComment("站別");

            entity.Property(e => e.JobNo)
                .HasMaxLength(36)
                .HasColumnName("JOB_NO")
                .HasComment("工作編號");

            entity.Property(e => e.ConfirmBy)
                .HasMaxLength(20)
                .HasColumnName("CONFIRM_BY")
                .HasComment("審核人");

            entity.Property(e => e.ConfirmDate)
                .HasPrecision(0)
                .HasColumnName("CONFIRM_DATE")
                .HasComment("審核日期");

            entity.Property(e => e.ConfirmFlag)
                .HasMaxLength(2)
                .HasColumnName("CONFIRM_FLAG")
                .HasComment("10運價中心主管未審核/ 15運價成本已作廢[無法到其他狀態]/ 20運價中心主管已審核(老闆須審核未審核) / 30運價中心主管已審核(老闆無須審核)[已啟用此運價成本] / 40運價中心主管已審核(老闆已審核)[已啟用此運價成本] / 50此運價成本已有報價單引用");

            entity.Property(e => e.ContractNo)
                .HasMaxLength(50)
                .HasColumnName("CONTRACT_NO")
                .HasComment("合約號碼");

            entity.Property(e => e.ContractNoHistory)
                .HasMaxLength(50)
                .HasColumnName("CONTRACT_NO_HISTORY")
                .HasComment("舊合約號碼(作廢用)");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .HasColumnName("CREATE_BY")
                .HasComment("創建人");

            entity.Property(e => e.CreateDate)
                .HasPrecision(0)
                .HasColumnName("CREATE_DATE")
                .HasComment("創建日期");

            entity.Property(e => e.EffectiveDate)
                .HasPrecision(0)
                .HasColumnName("EFFECTIVE_DATE")
                .HasComment("生效日期");

            entity.Property(e => e.ExpirationDate)
                .HasPrecision(0)
                .HasColumnName("EXPIRATION_DATE")
                .HasComment("到期日期");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(20)
                .HasColumnName("MODIFY_BY")
                .HasComment("修改人");

            entity.Property(e => e.ModifyDate)
                .HasPrecision(0)
                .HasColumnName("MODIFY_DATE")
                .HasComment("修改日期");

            entity.Property(e => e.OceanLine)
                .HasMaxLength(10)
                .HasColumnName("OCEAN_LINE")
                .HasComment("航線");

            entity.Property(e => e.OrdCd)
                .HasMaxLength(10)
                .HasColumnName("ORD_CD")
                .HasComment("客戶名稱");

            entity.Property(e => e.Rec)
                .HasMaxLength(1)
                .HasColumnName("REC")
                .HasComment("是否推動 Y:是 N:否");

            entity.Property(e => e.VoidBy)
                .HasMaxLength(20)
                .HasColumnName("VOID_BY")
                .HasComment("作廢人");

            entity.Property(e => e.VoidDate)
                .HasPrecision(0)
                .HasColumnName("VOID_DATE")
                .HasComment("作廢時間");

            entity.Property(e => e.VoidReason)
                .HasMaxLength(500)
                .HasColumnName("VOID_REASON")
                .HasComment("作廢原因");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Bsfrtcentertds.Bsfrtcentertd>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.Cmp, e.Stn, e.JobNo })
                .HasName("PK__BSFRTCEN__53299E3AD84BC702");

            entity.ToTable("BSFRTCENTERTD");

            entity.HasIndex(e => new { e.GroupId, e.Cmp, e.Stn, e.FJobNo }, "IX_F_JOB_NO");

            entity.HasIndex(e => e.JobNo, "IX_JOB_NO")
                .IsUnique();

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID")
                .HasComment("集團");

            entity.Property(e => e.Cmp)
                .HasMaxLength(3)
                .HasColumnName("CMP")
                .HasComment("公司");

            entity.Property(e => e.Stn)
                .HasMaxLength(3)
                .HasColumnName("STN")
                .HasComment("站別");

            entity.Property(e => e.JobNo)
                .HasMaxLength(36)
                .HasColumnName("JOB_NO")
                .HasComment("工作編號");

            entity.Property(e => e.AccFlag)
                .HasMaxLength(1)
                .HasColumnName("ACC_FLAG")
                .HasComment("累計加總 Y:是,N:否");

            entity.Property(e => e.AgentCd)
                .HasMaxLength(20)
                .HasColumnName("AGENT_CD")
                .HasComment("代理代碼");

            entity.Property(e => e.BasicPrice)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("BASIC_PRICE")
                .HasComment("基本價格");

            entity.Property(e => e.ChgFlag1)
                .HasMaxLength(1)
                .HasColumnName("CHG_FLAG1")
                .HasComment("計費單位型態1");

            entity.Property(e => e.ChgFlag2)
                .HasMaxLength(1)
                .HasColumnName("CHG_FLAG2")
                .HasComment("計費單位型態2");

            entity.Property(e => e.ChgFlag3)
                .HasMaxLength(1)
                .HasColumnName("CHG_FLAG3")
                .HasComment("計費單位型態3");

            entity.Property(e => e.ChgFlag4)
                .HasMaxLength(1)
                .HasColumnName("CHG_FLAG4")
                .HasComment("計費單位型態4");

            entity.Property(e => e.ChgFlag5)
                .HasMaxLength(1)
                .HasColumnName("CHG_FLAG5")
                .HasComment("計費單位型態5");

            entity.Property(e => e.ChgFlag6)
                .HasMaxLength(1)
                .HasColumnName("CHG_FLAG6")
                .HasComment("計費單位型態6");

            entity.Property(e => e.ChgUnit)
                .HasMaxLength(10)
                .HasColumnName("CHG_UNIT")
                .HasComment("計費單位");

            entity.Property(e => e.ChgUnit1)
                .HasMaxLength(10)
                .HasColumnName("CHG_UNIT1")
                .HasComment("計費單位1");

            entity.Property(e => e.ChgUnit2)
                .HasMaxLength(10)
                .HasColumnName("CHG_UNIT2")
                .HasComment("計費單位2");

            entity.Property(e => e.ChgUnit3)
                .HasMaxLength(10)
                .HasColumnName("CHG_UNIT3")
                .HasComment("計費單位3");

            entity.Property(e => e.ChgUnit4)
                .HasMaxLength(10)
                .HasColumnName("CHG_UNIT4")
                .HasComment("計費單位4");

            entity.Property(e => e.ChgUnit5)
                .HasMaxLength(10)
                .HasColumnName("CHG_UNIT5")
                .HasComment("計費單位5");

            entity.Property(e => e.ChgUnit6)
                .HasMaxLength(10)
                .HasColumnName("CHG_UNIT6")
                .HasComment("計費單位6");

            entity.Property(e => e.Closing)
                .HasMaxLength(50)
                .HasColumnName("CLOSING")
                .HasComment("結關日");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .HasColumnName("CREATE_BY")
                .HasComment("創建人");

            entity.Property(e => e.CreateDate)
                .HasPrecision(0)
                .HasColumnName("CREATE_DATE")
                .HasComment("創建日期");

            entity.Property(e => e.Dep)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("DEP")
                .HasComment("部門");

            entity.Property(e => e.Dest2Cd)
                .HasMaxLength(3)
                .HasColumnName("DEST2_CD")
                .HasComment("第二城市代碼");

            entity.Property(e => e.Dest2Cnty)
                .HasMaxLength(3)
                .HasColumnName("DEST2_CNTY")
                .HasComment("第二城市國家代碼");

            entity.Property(e => e.Dest2Nm)
                .HasMaxLength(100)
                .HasColumnName("DEST2_NM")
                .HasComment("第二城市名稱");

            entity.Property(e => e.Dest3Cd)
                .HasMaxLength(3)
                .HasColumnName("DEST3_CD")
                .HasComment("第三城市代碼");

            entity.Property(e => e.Dest3Cnty)
                .HasMaxLength(3)
                .HasColumnName("DEST3_CNTY")
                .HasComment("第三城市國家代碼");

            entity.Property(e => e.Dest3Nm)
                .HasMaxLength(100)
                .HasColumnName("DEST3_NM")
                .HasComment("第三城市名稱");

            entity.Property(e => e.Dest4Cd)
                .HasMaxLength(3)
                .HasColumnName("DEST4_CD")
                .HasComment("第四城市代碼");

            entity.Property(e => e.Dest4Cnty)
                .HasMaxLength(3)
                .HasColumnName("DEST4_CNTY")
                .HasComment("第四城市國家代碼");

            entity.Property(e => e.Dest4Nm)
                .HasMaxLength(100)
                .HasColumnName("DEST4_NM")
                .HasComment("第四城市名稱");

            entity.Property(e => e.DestCd)
                .HasMaxLength(3)
                .HasColumnName("DEST_CD")
                .HasComment("最終目的代碼");

            entity.Property(e => e.DestCnty)
                .HasMaxLength(3)
                .HasColumnName("DEST_CNTY")
                .HasComment("最終目的國家");

            entity.Property(e => e.DestNm)
                .HasMaxLength(100)
                .HasColumnName("DEST_NM")
                .HasComment("最終目的名稱");

            entity.Property(e => e.Eta)
                .HasMaxLength(50)
                .HasColumnName("ETA")
                .HasComment("預計到達時間");

            entity.Property(e => e.Etd)
                .HasMaxLength(50)
                .HasColumnName("ETD")
                .HasComment("開航/起飛日");

            entity.Property(e => e.FCarrier)
                .HasMaxLength(10)
                .HasColumnName("F_CARRIER")
                .HasComment("船公司/航空公司");

            entity.Property(e => e.FChargeCd)
                .HasMaxLength(50)
                .HasColumnName("F_CHARGE_CD")
                .HasComment("費用代碼");

            entity.Property(e => e.FCmdt)
                .HasMaxLength(50)
                .HasColumnName("F_CMDT")
                .HasComment("品名");

            entity.Property(e => e.FCurrency)
                .HasMaxLength(3)
                .HasColumnName("F_CURRENCY")
                .HasComment("幣別");

            entity.Property(e => e.FJobNo)
                .IsRequired()
                .HasMaxLength(36)
                .HasColumnName("F_JOB_NO")
                .HasComment("來源主單的工作編號");

            entity.Property(e => e.FRlsNo)
                .HasMaxLength(50)
                .HasColumnName("F_RLS_NO")
                .HasComment("合約子號");

            entity.Property(e => e.FRmk)
                .HasColumnName("F_RMK")
                .HasComment("備註");

            entity.Property(e => e.FTransit)
                .HasMaxLength(100)
                .HasColumnName("F_TRANSIT")
                .HasComment("航程天數");

            entity.Property(e => e.FType)
                .HasMaxLength(3)
                .HasColumnName("F_TYPE")
                .HasComment("計費方式");

            entity.Property(e => e.FreeTime)
                .HasMaxLength(50)
                .HasColumnName("FREE_TIME")
                .HasComment("免費倉儲時間");

            entity.Property(e => e.GuiFlg)
                .HasMaxLength(1)
                .HasColumnName("GUI_FLG")
                .HasComment("是否開發票");

            entity.Property(e => e.H)
                .HasColumnType("numeric(8, 4)")
                .HasComment("高");

            entity.Property(e => e.L)
                .HasColumnType("numeric(8, 4)")
                .HasComment("長");

            entity.Property(e => e.MinChg)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("MIN_CHG")
                .HasComment("計費單價");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(20)
                .HasColumnName("MODIFY_BY")
                .HasComment("修改人");

            entity.Property(e => e.ModifyDate)
                .HasPrecision(0)
                .HasColumnName("MODIFY_DATE")
                .HasComment("修改日期");

            entity.Property(e => e.Pc)
                .HasMaxLength(2)
                .HasColumnName("PC")
                .HasComment("L.國內/F.國外");

            entity.Property(e => e.Pkg)
                .HasColumnType("numeric(38, 0)")
                .HasColumnName("PKG")
                .HasComment("件數");

            entity.Property(e => e.PkgUnit)
                .HasMaxLength(20)
                .HasColumnName("PKG_UNIT")
                .HasComment("件數單位");

            entity.Property(e => e.PodCd)
                .HasMaxLength(3)
                .HasColumnName("POD_CD")
                .HasComment("卸貨港代碼");

            entity.Property(e => e.PodCnty)
                .HasMaxLength(3)
                .HasColumnName("POD_CNTY")
                .HasComment("卸貨港國家代碼");

            entity.Property(e => e.PodNm)
                .HasMaxLength(100)
                .HasColumnName("POD_NM")
                .HasComment("卸貨港名稱");

            entity.Property(e => e.PolCd)
                .HasMaxLength(3)
                .HasColumnName("POL_CD")
                .HasComment("起運地/裝貨港代碼");

            entity.Property(e => e.PolCnty)
                .HasMaxLength(3)
                .HasColumnName("POL_CNTY")
                .HasComment("裝貨港國家代碼");

            entity.Property(e => e.PolNm)
                .HasMaxLength(100)
                .HasColumnName("POL_NM")
                .HasComment("裝貨港名稱");

            entity.Property(e => e.PorCd)
                .HasMaxLength(3)
                .HasColumnName("POR_CD")
                .HasComment("收貨港代碼");

            entity.Property(e => e.PorCnty)
                .HasMaxLength(3)
                .HasColumnName("POR_CNTY")
                .HasComment("收貨港國家代碼");

            entity.Property(e => e.PorNm)
                .HasMaxLength(100)
                .HasColumnName("POR_NM")
                .HasComment("收貨港名稱");

            entity.Property(e => e.PriceSt)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("PRICE_ST")
                .HasComment("定價策略");

            entity.Property(e => e.PriceSt2)
                .HasColumnType("numeric(16, 4)")
                .HasColumnName("PRICE_ST2")
                .HasComment("定價策略2");

            entity.Property(e => e.PriceSt3)
                .HasColumnType("numeric(16, 4)")
                .HasColumnName("PRICE_ST3")
                .HasComment("定價策略3");

            entity.Property(e => e.PriceSt4)
                .HasColumnType("numeric(16, 4)")
                .HasColumnName("PRICE_ST4")
                .HasComment("定價策略4");

            entity.Property(e => e.PriceSt5)
                .HasColumnType("numeric(16, 4)")
                .HasColumnName("PRICE_ST5")
                .HasComment("定價策略5");

            entity.Property(e => e.PriceSt6)
                .HasColumnType("numeric(16, 4)")
                .HasColumnName("PRICE_ST6")
                .HasComment("定價策略6");

            entity.Property(e => e.Rate1)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("RATE1")
                .HasComment("計費單價1");

            entity.Property(e => e.Rate2)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("RATE2")
                .HasComment("計費單價2");

            entity.Property(e => e.Rate3)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("RATE3")
                .HasComment("計費單價3");

            entity.Property(e => e.Rate4)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("RATE4")
                .HasComment("計費單價4");

            entity.Property(e => e.Rate5)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("RATE5")
                .HasComment("計費單價5");

            entity.Property(e => e.Rate6)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("RATE6")
                .HasComment("計費單價6");

            entity.Property(e => e.SalesDepId)
                .HasColumnName("SALES_DEP_ID")
                .HasComment("業務所屬部門");

            entity.Property(e => e.Seq)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("SEQ")
                .HasComment("第幾筆明細");

            entity.Property(e => e.SvcModeTerm)
                .HasMaxLength(10)
                .HasColumnName("SVC_MODE_TERM")
                .HasComment("貿易條款");

            entity.Property(e => e.TaxRate)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("TAX_RATE")
                .HasComment("稅率");

            entity.Property(e => e.TransitType)
                .HasMaxLength(50)
                .HasColumnName("TRANSIT_TYPE")
                .HasComment("轉運類型");

            entity.Property(e => e.TruckDest)
                .HasMaxLength(50)
                .HasColumnName("TRUCK_DEST")
                .HasComment("車隊目的地");

            entity.Property(e => e.TruckOrgn)
                .HasMaxLength(50)
                .HasColumnName("TRUCK_ORGN")
                .HasComment("車隊起運地");

            entity.Property(e => e.VatFlag)
                .HasMaxLength(1)
                .HasColumnName("VAT_FLAG")
                .HasComment("計稅類型");

            entity.Property(e => e.Via)
                .HasMaxLength(1)
                .HasColumnName("VIA")
                .HasComment("轉運的方式");

            entity.Property(e => e.Vsl)
                .HasMaxLength(100)
                .HasColumnName("VSL")
                .HasComment("船名/航班號");

            entity.Property(e => e.Vw)
                .HasColumnType("numeric(16, 4)")
                .HasColumnName("VW")
                .HasComment("體積重");

            entity.Property(e => e.VwUnit)
                .HasMaxLength(3)
                .HasColumnName("VW_UNIT")
                .HasComment("體積重單位");

            entity.Property(e => e.W)
                .HasColumnType("numeric(8, 4)")
                .HasComment("寬");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.BsfrtcentertExcelTemps.BsfrtcentertExcelTemp>(entity =>
        {
            entity.HasKey(e => e.ExcelTempId);

            entity.ToTable("BSFRTCENTERT_EXCEL_TEMP");

            entity.HasIndex(e => e.UploaderId, "IX_BSFRTCENTERT_EXCEL_TEMP_UPLOADER_ID");

            entity.Property(e => e.ExcelTempId)
                .HasColumnName("EXCEL_TEMP_ID")
                .HasComment("流水號");

            entity.Property(e => e.Agent)
                .HasMaxLength(200)
                .HasColumnName("AGENT")
                .HasComment("資料來源/運價取得/代理人");

            entity.Property(e => e.Carrier)
                .HasMaxLength(50)
                .HasColumnName("CARRIER")
                .HasComment("船/航空公司代碼");

            entity.Property(e => e.Cmp)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("CMP")
                .HasComment("公司");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .HasColumnName("CURRENCY")
                .HasComment("幣別");

            entity.Property(e => e.Destination)
                .HasMaxLength(200)
                .HasColumnName("DESTINATION")
                .HasComment("最終交貨地");

            entity.Property(e => e.EffectiveDate)
                .HasPrecision(0)
                .HasColumnName("EFFECTIVE_DATE")
                .HasComment("合約生效日期");

            entity.Property(e => e.Eta)
                .HasMaxLength(50)
                .HasColumnName("ETA")
                .HasComment("預計到達時間");

            entity.Property(e => e.Etc)
                .HasMaxLength(50)
                .HasColumnName("ETC")
                .HasComment("截關日");

            entity.Property(e => e.Etd)
                .HasMaxLength(50)
                .HasColumnName("ETD")
                .HasComment("預計開航時間");

            entity.Property(e => e.FreeTime)
                .HasMaxLength(50)
                .HasColumnName("FREE_TIME")
                .HasComment("免費倉儲時間");

            entity.Property(e => e.GroupId)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID")
                .HasComment("集團");

            entity.Property(e => e.Ic20gp)
                .HasMaxLength(10)
                .HasColumnName("IC_20GP")
                .HasComment("20'GP的價錢");

            entity.Property(e => e.Ic40gp)
                .HasMaxLength(10)
                .HasColumnName("IC_40GP")
                .HasComment("40'GP的價錢");

            entity.Property(e => e.Ic40hq)
                .HasMaxLength(10)
                .HasColumnName("IC_40HQ")
                .HasComment("40'HQ的價錢");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasComment("是否刪除");

            entity.Property(e => e.Model)
                .HasMaxLength(200)
                .HasColumnName("MODEL")
                .HasComment("模式");

            entity.Property(e => e.Origin)
                .HasMaxLength(200)
                .HasColumnName("ORIGIN")
                .HasComment("起運地");

            entity.Property(e => e.Pod)
                .HasMaxLength(200)
                .HasColumnName("POD")
                .HasComment("目的港");

            entity.Property(e => e.Remark)
                .HasColumnName("REMARK")
                .HasComment("備註");

            entity.Property(e => e.Stn)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("STN")
                .HasComment("站別");

            entity.Property(e => e.TrasitTime)
                .HasMaxLength(100)
                .HasColumnName("TRASIT_TIME")
                .HasComment("航程天數");

            entity.Property(e => e.UploaderId)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("UPLOADER_ID")
                .HasComment("上傳人");

            entity.Property(e => e.UploaderTime)
                .HasPrecision(0)
                .HasColumnName("UPLOADER_TIME")
                .HasComment("上傳時間");

            entity.Property(e => e.ValidTill)
                .HasPrecision(0)
                .HasColumnName("VALID_TILL")
                .HasComment("合約到期日期");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.BsfrtcentertPortMappings.BsfrtcentertPortMapping>(entity =>
        {
            entity.HasKey(e => e.PortName);

            entity.ToTable("BSFRTCENTERT_PORT_MAPPING");

            entity.Property(e => e.PortName)
                .HasMaxLength(200)
                .HasColumnName("PORT_NAME");

            entity.Property(e => e.CityCd)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("CITY_CD");

            entity.Property(e => e.CntyCd)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("CNTY_CD");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Bscodes.Bscode>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("BSCODE");

            entity.HasIndex(e => new { e.CdType, e.Cd }, "IX_BI");

            entity.HasIndex(e => new { e.Cd, e.CdType, e.GroupId, e.Cmp, e.Stn }, "IX_BSCODE_PROFIT_CLOSING_REPORT");

            entity.HasIndex(e => new { e.GroupId, e.CdType, e.Cd, e.Cmp, e.Stn, e.Dep }, "UQ_BSCODE")
                .IsUnique();

            entity.Property(e => e.AmsCode)
                .HasMaxLength(10)
                .HasColumnName("AMS_CODE");

            entity.Property(e => e.ApCd)
                .HasMaxLength(24)
                .HasColumnName("AP_CD");

            entity.Property(e => e.Apply)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("APPLY")
                .HasDefaultValueSql("('Y')");

            entity.Property(e => e.ArCd)
                .HasMaxLength(24)
                .HasColumnName("AR_CD");

            entity.Property(e => e.Cd)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("CD");

            entity.Property(e => e.CdDescp)
                .HasMaxLength(300)
                .HasColumnName("CD_DESCP");

            entity.Property(e => e.CdType)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnName("CD_TYPE");

            entity.Property(e => e.Cmp)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("CMP");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .HasColumnName("CREATE_BY");

            entity.Property(e => e.CreateDate)
                .HasPrecision(0)
                .HasColumnName("CREATE_DATE");

            entity.Property(e => e.Dep)
                .HasMaxLength(2)
                .HasColumnName("DEP")
                .HasDefaultValueSql("('AC')");

            entity.Property(e => e.GroupId)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID");

            entity.Property(e => e.Inttra)
                .HasMaxLength(3)
                .HasColumnName("INTTRA");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(20)
                .HasColumnName("MODIFY_BY");

            entity.Property(e => e.Stn)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("STN");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Bscss.Bscs>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.CustCd, e.Cmp, e.Stn });

            entity.ToTable("BSCS");

            entity.HasIndex(e => e.VoidBy, "<Name of Missing Index, sysname,>");

            entity.HasIndex(e => new { e.GroupId, e.VoidBy, e.Cmp, e.Stn }, "<Name of Missing Index, sysname2>");

            entity.HasIndex(e => new { e.GroupId, e.Updatecredit }, "IDX_BSCS_UPDATECREDIT");

            entity.HasIndex(e => new { e.GroupId, e.Stn, e.Cmp, e.CustCd, e.CreateDate, e.MAddr, e.Verticals }, "IX_BI");

            entity.HasIndex(e => new { e.GroupId, e.AbrNm, e.Cmp, e.Stn }, "IX_BSCS_01");

            entity.HasIndex(e => new { e.GroupId, e.EngNm, e.Cmp, e.Stn }, "IX_BSCS_02");

            entity.HasIndex(e => new { e.GroupId, e.LocalNm, e.Cmp, e.Stn }, "IX_BSCS_03");

            entity.HasIndex(e => new { e.GroupId, e.Cmp, e.Stn }, "IX_BSCS_GROUPID_CMP_STN");

            entity.HasIndex(e => new { e.GroupId, e.CustCd, e.Cmp, e.Stn }, "IX_BSCS_GROUPID_CMP_STN_CUSTCD");

            entity.HasIndex(e => new { e.GroupId, e.EngNm, e.LocalNm, e.AbrNm, e.Cmp, e.Stn }, "IX_BSCS_GROUPID_CMP_STN_ENGNM_LOCALNM_ABRNM");

            entity.HasIndex(e => new { e.GroupId, e.Cmp, e.Stn, e.CustCd, e.VoidBy }, "IX_NEWCUSTOMERS");

            entity.HasIndex(e => e.Rowid, "ROWID$INDEX")
                .IsUnique();

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID");

            entity.Property(e => e.CustCd)
                .HasMaxLength(10)
                .HasColumnName("CUST_CD");

            entity.Property(e => e.Cmp)
                .HasMaxLength(4)
                .HasColumnName("CMP");

            entity.Property(e => e.Stn)
                .HasMaxLength(3)
                .HasColumnName("STN");

            entity.Property(e => e.AbrNm)
                .HasMaxLength(20)
                .HasColumnName("ABR_NM");

            entity.Property(e => e.AccountNo)
                .HasMaxLength(40)
                .HasColumnName("ACCOUNT_NO");

            entity.Property(e => e.AciCode)
                .HasMaxLength(4)
                .HasColumnName("ACI_CODE");

            entity.Property(e => e.ActionId).HasColumnName("ACTION_ID");

            entity.Property(e => e.Aeo)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("AEO");

            entity.Property(e => e.AgntType)
                .HasMaxLength(1)
                .HasColumnName("AGNT_TYPE");

            entity.Property(e => e.Area)
                .HasMaxLength(1)
                .HasColumnName("AREA");

            entity.Property(e => e.Capital)
                .HasColumnType("decimal(19, 2)")
                .HasColumnName("CAPITAL");

            entity.Property(e => e.CityCd)
                .HasMaxLength(3)
                .HasColumnName("CITY_CD");

            entity.Property(e => e.CntyCd)
                .HasMaxLength(2)
                .HasColumnName("CNTY_CD");

            entity.Property(e => e.ContractCur)
                .HasMaxLength(2)
                .HasColumnName("CONTRACT_CUR");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .HasColumnName("CREATE_BY");

            entity.Property(e => e.CreateDate)
                .HasPrecision(0)
                .HasColumnName("CREATE_DATE");

            entity.Property(e => e.CreateStn)
                .HasMaxLength(3)
                .HasColumnName("CREATE_STN");

            entity.Property(e => e.CustAttn)
                .HasMaxLength(100)
                .HasColumnName("CUST_ATTN");

            entity.Property(e => e.CustFax)
                .HasMaxLength(200)
                .HasColumnName("CUST_FAX");

            entity.Property(e => e.CustLev)
                .HasMaxLength(10)
                .HasColumnName("CUST_LEV");

            entity.Property(e => e.CustMail)
                .HasMaxLength(200)
                .HasColumnName("CUST_MAIL");

            entity.Property(e => e.CustTel)
                .HasMaxLength(200)
                .HasColumnName("CUST_TEL");

            entity.Property(e => e.CustType)
                .HasMaxLength(100)
                .HasColumnName("CUST_TYPE");

            entity.Property(e => e.CustTypeEx)
                .HasMaxLength(100)
                .HasColumnName("CUST_TYPE_EX");

            entity.Property(e => e.EdiCode)
                .HasMaxLength(35)
                .HasColumnName("EDI_CODE");

            entity.Property(e => e.EffectiveDate)
                .HasPrecision(0)
                .HasColumnName("EFFECTIVE_DATE");

            entity.Property(e => e.EngAddr)
                .HasMaxLength(300)
                .HasColumnName("ENG_ADDR");

            entity.Property(e => e.EngAddrA)
                .HasMaxLength(300)
                .HasColumnName("ENG_ADDR_A");

            entity.Property(e => e.EngAddrO)
                .HasMaxLength(300)
                .HasColumnName("ENG_ADDR_O");

            entity.Property(e => e.EngNm)
                .HasMaxLength(200)
                .HasColumnName("ENG_NM");

            entity.Property(e => e.Exchrt)
                .HasMaxLength(1)
                .HasColumnName("EXCHRT");

            entity.Property(e => e.ExpirationDate)
                .HasPrecision(0)
                .HasColumnName("EXPIRATION_DATE");

            entity.Property(e => e.FaxUser)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FAX_USER");

            entity.Property(e => e.FollowupBy)
                .HasMaxLength(20)
                .HasColumnName("FOLLOWUP_BY");

            entity.Property(e => e.GlobalCd)
                .HasMaxLength(20)
                .HasColumnName("GLOBAL_CD");

            entity.Property(e => e.HaveHardcopy)
                .HasMaxLength(1)
                .HasColumnName("HAVE_HARDCOPY")
                .HasComment("有無紙本資料，Y=有");

            entity.Property(e => e.HeaderCd)
                .HasMaxLength(10)
                .HasColumnName("HEADER_CD");

            entity.Property(e => e.IataCd)
                .HasMaxLength(40)
                .HasColumnName("IATA_CD");

            entity.Property(e => e.IsQualified)
                .HasMaxLength(1)
                .HasColumnName("IS_QUALIFIED")
                .HasComment("是否合格，Y=是");

            entity.Property(e => e.Itrace)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ITRACE");

            entity.Property(e => e.KcDate)
                .HasPrecision(0)
                .HasColumnName("KC_DATE");

            entity.Property(e => e.KcNo)
                .HasMaxLength(30)
                .HasColumnName("KC_NO");

            entity.Property(e => e.LocalAddr)
                .HasMaxLength(300)
                .HasColumnName("LOCAL_ADDR");

            entity.Property(e => e.LocalAddrA)
                .HasMaxLength(300)
                .HasColumnName("LOCAL_ADDR_A");

            entity.Property(e => e.LocalAddrO)
                .HasMaxLength(300)
                .HasColumnName("LOCAL_ADDR_O");

            entity.Property(e => e.LocalNm)
                .HasMaxLength(200)
                .HasColumnName("LOCAL_NM");

            entity.Property(e => e.LockUser)
                .HasMaxLength(20)
                .HasColumnName("LOCK_USER");

            entity.Property(e => e.MAddr)
                .HasMaxLength(300)
                .HasColumnName("M_ADDR");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(20)
                .HasColumnName("MODIFY_BY");

            entity.Property(e => e.ModifyDate)
                .HasPrecision(0)
                .HasColumnName("MODIFY_DATE");

            entity.Property(e => e.OpenDate)
                .HasPrecision(0)
                .HasColumnName("OPEN_DATE");

            entity.Property(e => e.Opener)
                .HasMaxLength(20)
                .HasColumnName("OPENER");

            entity.Property(e => e.Organ)
                .HasMaxLength(200)
                .HasColumnName("ORGAN");

            entity.Property(e => e.PsCenter)
                .HasMaxLength(10)
                .HasColumnName("PS_CENTER");

            entity.Property(e => e.QualifiedDate)
                .HasPrecision(0)
                .HasColumnName("QUALIFIED_DATE")
                .HasComment("評鑑日期");

            entity.Property(e => e.QualifiedExpdate)
                .HasPrecision(0)
                .HasColumnName("QUALIFIED_EXPDATE")
                .HasComment("評鑑有效日期");

            entity.Property(e => e.QualifiedLev)
                .HasMaxLength(10)
                .HasColumnName("QUALIFIED_LEV")
                .HasComment("客戶評鑑級別");

            entity.Property(e => e.RarNo)
                .HasMaxLength(30)
                .HasColumnName("RAR_NO");

            entity.Property(e => e.Rmk)
                .IsUnicode(false)
                .HasColumnName("RMK");

            entity.Property(e => e.Rowid)
                .HasColumnName("ROWID")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.ScacCode)
                .HasMaxLength(4)
                .HasColumnName("SCAC_CODE");

            entity.Property(e => e.State)
                .HasMaxLength(10)
                .HasColumnName("STATE");

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("STATUS");

            entity.Property(e => e.StockCode)
                .HasMaxLength(10)
                .HasColumnName("STOCK_CODE");

            entity.Property(e => e.TaxNo)
                .HasMaxLength(20)
                .HasColumnName("TAX_NO");

            entity.Property(e => e.Towf)
                .HasMaxLength(1)
                .HasColumnName("TOWF")
                .HasComment("鼎新WorkFlow");

            entity.Property(e => e.Updatecredit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("UPDATECREDIT")
                .IsFixedLength();

            entity.Property(e => e.Verticals)
                .HasMaxLength(100)
                .HasColumnName("VERTICALS");

            entity.Property(e => e.VoidBy)
                .HasMaxLength(20)
                .HasColumnName("VOID_BY");

            entity.Property(e => e.VoidDate)
                .HasPrecision(0)
                .HasColumnName("VOID_DATE");

            entity.Property(e => e.VoidFlag)
                .HasMaxLength(1)
                .HasColumnName("VOID_FLAG");

            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .HasColumnName("WEBSITE");

            entity.Property(e => e.ZipCd)
                .HasMaxLength(10)
                .HasColumnName("ZIP_CD");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Bschgcds.Bschgcd>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.Dep, e.ChgCd, e.Cmp, e.Stn });

            entity.ToTable("BSCHGCD");

            entity.HasIndex(e => e.Rowid, "ROWID$INDEX")
                .IsUnique();

            entity.HasIndex(e => e.UId, "UNQ_BSCHGCD")
                .IsUnique();

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID");

            entity.Property(e => e.Dep)
                .HasMaxLength(2)
                .HasColumnName("DEP");

            entity.Property(e => e.ChgCd)
                .HasMaxLength(10)
                .HasColumnName("CHG_CD");

            entity.Property(e => e.Cmp)
                .HasMaxLength(3)
                .HasColumnName("CMP");

            entity.Property(e => e.Stn)
                .HasMaxLength(3)
                .HasColumnName("STN");

            entity.Property(e => e.AccountCost)
                .HasMaxLength(30)
                .HasColumnName("ACCOUNT_COST");

            entity.Property(e => e.AccountTitle)
                .HasMaxLength(30)
                .HasColumnName("ACCOUNT_TITLE");

            entity.Property(e => e.CfAccid)
                .HasMaxLength(30)
                .HasColumnName("CF_ACCID");

            entity.Property(e => e.ChgCnm)
                .HasMaxLength(60)
                .HasColumnName("CHG_CNM");

            entity.Property(e => e.ChgEnm)
                .HasMaxLength(60)
                .HasColumnName("CHG_ENM");

            entity.Property(e => e.ChgType)
                .HasMaxLength(1)
                .HasColumnName("CHG_TYPE");

            entity.Property(e => e.ChgUnit)
                .HasMaxLength(10)
                .HasColumnName("CHG_UNIT");

            entity.Property(e => e.ClAccid)
                .HasMaxLength(30)
                .HasColumnName("CL_ACCID");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .HasColumnName("CREATE_BY");

            entity.Property(e => e.CreateDate)
                .HasPrecision(0)
                .HasColumnName("CREATE_DATE");

            entity.Property(e => e.DfAccid)
                .HasMaxLength(30)
                .HasColumnName("DF_ACCID");

            entity.Property(e => e.DlAccid)
                .HasMaxLength(30)
                .HasColumnName("DL_ACCID");

            entity.Property(e => e.Gui)
                .HasMaxLength(1)
                .HasColumnName("GUI");

            entity.Property(e => e.GuiRmk)
                .IsUnicode(false)
                .HasColumnName("GUI_RMK");

            entity.Property(e => e.InAccountCost)
                .HasMaxLength(30)
                .HasColumnName("IN_ACCOUNT_COST");

            entity.Property(e => e.InAccountTitle)
                .HasMaxLength(30)
                .HasColumnName("IN_ACCOUNT_TITLE");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(20)
                .HasColumnName("MODIFY_BY");

            entity.Property(e => e.ModifyDate)
                .HasPrecision(0)
                .HasColumnName("MODIFY_DATE");

            entity.Property(e => e.Rmk)
                .HasMaxLength(100)
                .HasColumnName("RMK");

            entity.Property(e => e.Rowid)
                .HasColumnName("ROWID")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.ShareBy)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SHARE_BY");

            entity.Property(e => e.TaxRate)
                .HasColumnType("numeric(8, 4)")
                .HasColumnName("TAX_RATE");

            entity.Property(e => e.Traxon)
                .HasMaxLength(3)
                .HasColumnName("TRAXON");

            entity.Property(e => e.UId)
                .HasColumnName("U_ID")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.VatFlag)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("VAT_FLAG")
                .HasDefaultValueSql("('N')");

            entity.Property(e => e.WfcfAccid)
                .HasMaxLength(30)
                .HasColumnName("WFCF_ACCID")
                .HasComment("鼎新WorkFlow國外支出科目");

            entity.Property(e => e.WfclAccid)
                .HasMaxLength(30)
                .HasColumnName("WFCL_ACCID")
                .HasComment("鼎新WorkFlow國內支出科目");

            entity.Property(e => e.WfdfAccid)
                .HasMaxLength(30)
                .HasColumnName("WFDF_ACCID")
                .HasComment("鼎新WorkFlow國外收入科目");

            entity.Property(e => e.WfdlAccid)
                .HasMaxLength(30)
                .HasColumnName("WFDL_ACCID")
                .HasComment("鼎新WorkFlow國內收入科目");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Bscitys.Bscity>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.CityCd, e.CntyCd, e.Cmp, e.Stn, e.DepType });

            entity.ToTable("BSCITY");

            entity.HasIndex(e => e.CityCd, "BSCITY_INDEX01");

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID");

            entity.Property(e => e.CityCd)
                .HasMaxLength(3)
                .HasColumnName("CITY_CD");

            entity.Property(e => e.CntyCd)
                .HasMaxLength(2)
                .HasColumnName("CNTY_CD");

            entity.Property(e => e.Cmp)
                .HasMaxLength(2)
                .HasColumnName("CMP");

            entity.Property(e => e.Stn)
                .HasMaxLength(3)
                .HasColumnName("STN");

            entity.Property(e => e.DepType)
                .HasMaxLength(1)
                .HasColumnName("DEP_TYPE");

            entity.Property(e => e.AmsCode)
                .HasMaxLength(10)
                .HasColumnName("AMS_CODE");

            entity.Property(e => e.Area)
                .HasMaxLength(1)
                .HasColumnName("AREA");

            entity.Property(e => e.CityCnm)
                .HasMaxLength(20)
                .HasColumnName("CITY_CNM")
                .HasComment("城市中文名稱");

            entity.Property(e => e.CityNm)
                .HasMaxLength(100)
                .HasColumnName("CITY_NM");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .HasColumnName("CREATE_BY");

            entity.Property(e => e.CreateDate)
                .HasPrecision(0)
                .HasColumnName("CREATE_DATE");

            entity.Property(e => e.Dep)
                .HasMaxLength(3)
                .HasColumnName("DEP");

            entity.Property(e => e.Inttra)
                .HasMaxLength(5)
                .HasColumnName("INTTRA");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(20)
                .HasColumnName("MODIFY_BY");

            entity.Property(e => e.ModifyDate)
                .HasPrecision(0)
                .HasColumnName("MODIFY_DATE");

            entity.Property(e => e.Route)
                .HasMaxLength(10)
                .HasColumnName("ROUTE");

            entity.Property(e => e.SpecArea)
                .HasMaxLength(1)
                .HasColumnName("SPEC_AREA");

            entity.Property(e => e.State)
                .HasMaxLength(2)
                .HasColumnName("STATE");

            entity.Property(e => e.StateCd)
                .HasMaxLength(10)
                .HasColumnName("STATE_CD");

            entity.Property(e => e.Timezone)
                .HasMaxLength(10)
                .HasColumnName("TIMEZONE");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Bscurs.Bscur>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.Cur, e.Cmp, e.Stn });

            entity.ToTable("BSCUR");

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID");

            entity.Property(e => e.Cur)
                .HasMaxLength(3)
                .HasColumnName("CUR");

            entity.Property(e => e.Cmp)
                .HasMaxLength(2)
                .HasColumnName("CMP");

            entity.Property(e => e.Stn)
                .HasMaxLength(3)
                .HasColumnName("STN");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .HasColumnName("CREATE_BY");

            entity.Property(e => e.CreateDate)
                .HasPrecision(0)
                .HasColumnName("CREATE_DATE");

            entity.Property(e => e.CurDescp)
                .HasMaxLength(40)
                .HasColumnName("CUR_DESCP");

            entity.Property(e => e.DecimalPoint)
                .HasColumnType("numeric(38, 0)")
                .HasColumnName("DECIMAL_POINT");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(20)
                .HasColumnName("MODIFY_BY");

            entity.Property(e => e.ModifyDate)
                .HasPrecision(0)
                .HasColumnName("MODIFY_DATE");

            entity.Property(e => e.RoundType)
                .HasColumnType("numeric(38, 0)")
                .HasColumnName("ROUND_TYPE");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Gfgroups.Gfgroup>(entity =>
        {
            entity.HasKey(e => e.GroupId);

            entity.ToTable("GFGROUP");

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID");

            entity.Property(e => e.GroupAddr)
                .HasMaxLength(200)
                .HasColumnName("GROUP_ADDR");

            entity.Property(e => e.GroupCaddr)
                .HasMaxLength(200)
                .HasColumnName("GROUP_CADDR");

            entity.Property(e => e.GroupCnm)
                .HasMaxLength(200)
                .HasColumnName("GROUP_CNM");

            entity.Property(e => e.GroupNm)
                .HasMaxLength(200)
                .HasColumnName("GROUP_NM");

            entity.Property(e => e.GroupRmk)
                .IsUnicode(false)
                .HasColumnName("GROUP_RMK");

            entity.Property(e => e.GroupUseglobal)
                .HasMaxLength(1)
                .HasColumnName("GROUP_USEGLOBAL")
                .HasDefaultValueSql("('N')");

            entity.Property(e => e.LimitType)
                .HasMaxLength(100)
                .HasColumnName("LIMIT_TYPE");
        });

        modelBuilder.Entity<iFreightDB.BaseTables.Gfcompanys.Gfcompany>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.Cmp, e.Stn });

            entity.ToTable("GFCOMPANY");

            entity.HasIndex(e => new { e.GroupId, e.Cmp, e.Stn }, "GFCOMPANY_INDEX");

            entity.HasIndex(e => e.GroupId, "IX_BI");

            entity.HasIndex(e => new { e.GroupId, e.BaseCmp, e.BaseStn }, "IX_GFCOMPANY_01");

            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .HasColumnName("GROUP_ID");

            entity.Property(e => e.Cmp)
                .HasMaxLength(2)
                .HasColumnName("CMP");

            entity.Property(e => e.Stn)
                .HasMaxLength(3)
                .HasColumnName("STN");

            entity.Property(e => e.Accountid1)
                .HasMaxLength(20)
                .HasColumnName("ACCOUNTID1");

            entity.Property(e => e.AirContractStn)
                .HasMaxLength(150)
                .HasColumnName("AIR_CONTRACT_STN");

            entity.Property(e => e.AirMcontractStn)
                .HasMaxLength(150)
                .HasColumnName("AIR_MCONTRACT_STN");

            entity.Property(e => e.AutochangeInvdate)
                .HasMaxLength(1)
                .HasColumnName("AUTOCHANGE_INVDATE")
                .HasDefaultValueSql("('N')");

            entity.Property(e => e.BaseCmp)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("BASE_CMP");

            entity.Property(e => e.BaseStn)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("BASE_STN");

            entity.Property(e => e.ChgCdCmp)
                .HasMaxLength(3)
                .HasColumnName("CHG_CD_CMP");

            entity.Property(e => e.ChgCdStn)
                .HasMaxLength(3)
                .HasColumnName("CHG_CD_STN");

            entity.Property(e => e.CmpAttn)
                .HasMaxLength(20)
                .HasColumnName("CMP_ATTN");

            entity.Property(e => e.CmpAttnCell)
                .HasMaxLength(35)
                .HasColumnName("CMP_ATTN_CELL");

            entity.Property(e => e.CmpAttnMail)
                .HasMaxLength(200)
                .HasColumnName("CMP_ATTN_MAIL");

            entity.Property(e => e.CmpAttnTel)
                .HasMaxLength(35)
                .HasColumnName("CMP_ATTN_TEL");

            entity.Property(e => e.CmpBsEntity)
                .HasMaxLength(20)
                .HasColumnName("CMP_BS_ENTITY");

            entity.Property(e => e.CmpBsLic)
                .HasMaxLength(50)
                .HasColumnName("CMP_BS_LIC");

            entity.Property(e => e.CmpCd)
                .HasMaxLength(10)
                .HasColumnName("CMP_CD");

            entity.Property(e => e.CmpCloseFlag)
                .HasMaxLength(1)
                .HasColumnName("CMP_CLOSE_FLAG");

            entity.Property(e => e.CmpEfficDateFrom)
                .HasPrecision(0)
                .HasColumnName("CMP_EFFIC_DATE_FROM");

            entity.Property(e => e.CmpEfficDateTo)
                .HasPrecision(0)
                .HasColumnName("CMP_EFFIC_DATE_TO");

            entity.Property(e => e.CmpRegAddr)
                .HasMaxLength(200)
                .HasColumnName("CMP_REG_ADDR");

            entity.Property(e => e.CmpRegCap)
                .HasColumnType("numeric(20, 5)")
                .HasColumnName("CMP_REG_CAP");

            entity.Property(e => e.CmpRmk)
                .IsUnicode(false)
                .HasColumnName("CMP_RMK");

            entity.Property(e => e.CmpTtlCap)
                .HasColumnType("numeric(20, 5)")
                .HasColumnName("CMP_TTL_CAP");

            entity.Property(e => e.CmpUsebk)
                .HasMaxLength(1)
                .HasColumnName("CMP_USEBK");

            entity.Property(e => e.ContractStn)
                .HasMaxLength(50)
                .HasColumnName("CONTRACT_STN");

            entity.Property(e => e.CreditCmpstn)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CREDIT_CMPSTN");

            entity.Property(e => e.Cur)
                .HasMaxLength(3)
                .HasColumnName("CUR");

            entity.Property(e => e.CustAcdate)
                .HasMaxLength(20)
                .HasColumnName("CUST_ACDATE");

            entity.Property(e => e.CustAddSharecmp)
                .HasMaxLength(2)
                .HasColumnName("CUST_ADD_SHARECMP");

            entity.Property(e => e.CustAddSharestn)
                .HasMaxLength(3)
                .HasColumnName("CUST_ADD_SHARESTN");

            entity.Property(e => e.CustAedate)
                .HasMaxLength(20)
                .HasColumnName("CUST_AEDATE");

            entity.Property(e => e.CustAidate)
                .HasMaxLength(20)
                .HasColumnName("CUST_AIDATE");

            entity.Property(e => e.CustAutonoCmpstn)
                .HasMaxLength(5)
                .HasColumnName("CUST_AUTONO_CMPSTN");

            entity.Property(e => e.CustOedate)
                .HasMaxLength(20)
                .HasColumnName("CUST_OEDATE");

            entity.Property(e => e.CustOidate)
                .HasMaxLength(20)
                .HasColumnName("CUST_OIDATE");

            entity.Property(e => e.CustSharecmp)
                .HasMaxLength(2)
                .HasColumnName("CUST_SHARECMP");

            entity.Property(e => e.CustSharestn)
                .HasMaxLength(3)
                .HasColumnName("CUST_SHARESTN");

            entity.Property(e => e.DiffTime)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("DIFF_TIME");

            entity.Property(e => e.Fcur)
                .HasMaxLength(6)
                .HasColumnName("FCUR");

            entity.Property(e => e.IsCmpAlone)
                .HasMaxLength(1)
                .HasColumnName("IS_CMP_ALONE");

            entity.Property(e => e.LockExchrt)
                .HasMaxLength(1)
                .HasColumnName("LOCK_EXCHRT");

            entity.Property(e => e.MakeSalesChg)
                .HasMaxLength(1)
                .HasColumnName("MAKE_SALES_CHG")
                .HasComment("業務賣價製作");

            entity.Property(e => e.McontractStn)
                .HasMaxLength(50)
                .HasColumnName("MCONTRACT_STN");

            entity.Property(e => e.OpenInvPostAc)
                .HasMaxLength(1)
                .HasColumnName("OPEN_INV_POST_AC")
                .HasDefaultValueSql("('N')");

            entity.Property(e => e.Pc)
                .HasMaxLength(2)
                .HasColumnName("PC")
                .HasDefaultValueSql("('PP')");

            entity.Property(e => e.PostGl)
                .HasMaxLength(1)
                .HasColumnName("POST_GL")
                .HasDefaultValueSql("('N')");

            entity.Property(e => e.RateMonthOne)
                .HasMaxLength(1)
                .HasColumnName("RATE_MONTH_ONE")
                .HasDefaultValueSql("('Y')");

            entity.Property(e => e.TruckCd)
                .HasMaxLength(10)
                .HasColumnName("TRUCK_CD");

            entity.Property(e => e.UseAebldate)
                .HasMaxLength(20)
                .HasColumnName("USE_AEBLDATE");

            entity.Property(e => e.UseAedate)
                .HasMaxLength(20)
                .HasColumnName("USE_AEDATE");

            entity.Property(e => e.UseAibldate)
                .HasMaxLength(20)
                .HasColumnName("USE_AIBLDATE");

            entity.Property(e => e.UseAidate)
                .HasMaxLength(20)
                .HasColumnName("USE_AIDATE");

            entity.Property(e => e.UseDnbyitem)
                .HasMaxLength(1)
                .HasColumnName("USE_DNBYITEM")
                .HasDefaultValueSql("('N')");

            entity.Property(e => e.UseIsoffset)
                .HasMaxLength(1)
                .HasColumnName("USE_ISOFFSET");

            entity.Property(e => e.UseMessage)
                .HasMaxLength(1)
                .HasColumnName("USE_MESSAGE");

            entity.Property(e => e.UseOebldate)
                .HasMaxLength(20)
                .HasColumnName("USE_OEBLDATE");

            entity.Property(e => e.UseOedate)
                .HasMaxLength(20)
                .HasColumnName("USE_OEDATE");

            entity.Property(e => e.UseOibldate)
                .HasMaxLength(20)
                .HasColumnName("USE_OIBLDATE");

            entity.Property(e => e.UseOidate)
                .HasMaxLength(20)
                .HasColumnName("USE_OIDATE");

            entity.Property(e => e.UseSharesales)
                .HasMaxLength(1)
                .HasColumnName("USE_SHARESALES");

            entity.Property(e => e.UseTracking)
                .HasMaxLength(1)
                .HasColumnName("USE_TRACKING");
        });

        #endregion

    }
}
