using Chess.API.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Chess.API.Permissions;

public class APIPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(APIPermissions.GroupName);


        var booksPermission = myGroup.AddPermission(APIPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(APIPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(APIPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(APIPermissions.Books.Delete, L("Permission:Books.Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(APIPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<APIResource>(name);
    }
}
