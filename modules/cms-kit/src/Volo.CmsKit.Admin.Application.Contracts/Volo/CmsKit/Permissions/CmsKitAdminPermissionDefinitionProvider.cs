﻿using Volo.Abp.Authorization.Permissions;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Localization;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Localization;

namespace Volo.CmsKit.Permissions
{
    public class CmsKitAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var cmsGroup = context.GetGroupOrNull(CmsKitAdminPermissions.GroupName) ?? context.AddGroup(CmsKitAdminPermissions.GroupName, L("Permission:CmsKit"));

            cmsGroup
                .AddPermission(CmsKitAdminPermissions.Tags.Default, L("Permission:TagManagement"))
                    .AddChild(CmsKitAdminPermissions.Tags.Create, L("Permission:TagManagement.Create"))
                    .AddChild(CmsKitAdminPermissions.Tags.Update, L("Permission:TagManagement.Update"))
                    .AddChild(CmsKitAdminPermissions.Tags.Delete, L("Permission:TagManagement.Delete"));

            if (GlobalFeatureManager.Instance.IsEnabled<PagesFeature>())
            {
                cmsGroup
                    .AddPermission(CmsKitAdminPermissions.Pages.Default, L("Permission:PageManagement"))
                    .AddChild(CmsKitAdminPermissions.Pages.Create, L("Permission:PageManagement:Create"))
                    .AddChild(CmsKitAdminPermissions.Pages.Update, L("Permission:PageManagement:Update"))
                    .AddChild(CmsKitAdminPermissions.Pages.Delete, L("Permission:PageManagement:Delete"));
            }
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsKitResource>(name);
        }
    }
}
