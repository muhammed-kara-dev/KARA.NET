using KARA.NET.Blazor;
using KARA.NET.Data;
using KARA.NET.Web;
using KARA.NET.Web.Pages;

AppBlazor.Build(args)
    .LoadAdditionalAssemblies("KARA.NET", "Authorization", "PasswordManager")
    .Use<IUnitOfWork, KARA.NET.Data.EntityFramework.UnitOfWork>()
    .Use<IUnitOfWorkFactory, KARA.NET.Data.EntityFramework.UnitOfWorkFactory>()
    .SetTranslation<Translation>()
    .SetErrorHandlingPath($"/{nameof(Error)}")
    .Run<_App>();