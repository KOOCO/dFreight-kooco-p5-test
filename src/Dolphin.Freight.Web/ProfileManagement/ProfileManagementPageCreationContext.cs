using System;
using System.Collections.Generic;

namespace Volo.Abp.Account.Web.ProfileManagement;

public class ProfileManagementPageCreationContextCustom
{
    public IServiceProvider ServiceProvider { get; }

    public List<ProfileManagementPageGroupCustom> Groups { get; }

    public ProfileManagementPageCreationContextCustom(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;

        Groups = new List<ProfileManagementPageGroupCustom>();
    }
}
