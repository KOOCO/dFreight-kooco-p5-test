﻿using System.Collections.Generic;

namespace Volo.Abp.Account.Web.ProfileManagement;

public class ProfileManagementPageOptionsCustom
{
    public List<IProfileManagementPageContributorCustom> Contributors { get; }

    public ProfileManagementPageOptionsCustom()
    {
        Contributors = new List<IProfileManagementPageContributorCustom>();
    }
}
