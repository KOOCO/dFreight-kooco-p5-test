﻿using System.Threading.Tasks;

namespace Volo.Abp.Account.Web.ProfileManagement;

public interface IProfileManagementPageContributorCustom
{
    Task ConfigureAsync(ProfileManagementPageCreationContextCustom context);
}
