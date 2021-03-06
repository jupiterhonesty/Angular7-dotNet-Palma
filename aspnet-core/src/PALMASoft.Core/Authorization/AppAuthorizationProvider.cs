using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;

namespace PALMASoft.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public AppAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public AppAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var aSuelos = pages.CreateChildPermission(AppPermissions.Pages_ASuelos, L("ASuelos"));
            aSuelos.CreateChildPermission(AppPermissions.Pages_ASuelos_Create, L("CreateNewASuelo"));
            aSuelos.CreateChildPermission(AppPermissions.Pages_ASuelos_Edit, L("EditASuelo"));
            aSuelos.CreateChildPermission(AppPermissions.Pages_ASuelos_Delete, L("DeleteASuelo"));



            var aFoliares = pages.CreateChildPermission(AppPermissions.Pages_AFoliares, L("AFoliares"));
            aFoliares.CreateChildPermission(AppPermissions.Pages_AFoliares_Create, L("CreateNewAFoliar"));
            aFoliares.CreateChildPermission(AppPermissions.Pages_AFoliares_Edit, L("EditAFoliar"));
            aFoliares.CreateChildPermission(AppPermissions.Pages_AFoliares_Delete, L("DeleteAFoliar"));



            var analises = pages.CreateChildPermission(AppPermissions.Pages_Analises, L("Analises"));
            analises.CreateChildPermission(AppPermissions.Pages_Analises_Create, L("CreateNewAnalisis"));
            analises.CreateChildPermission(AppPermissions.Pages_Analises_Edit, L("EditAnalisis"));
            analises.CreateChildPermission(AppPermissions.Pages_Analises_Delete, L("DeleteAnalisis"));



            var fincas = pages.CreateChildPermission(AppPermissions.Pages_Fincas, L("Fincas"));
            fincas.CreateChildPermission(AppPermissions.Pages_Fincas_Create, L("CreateNewFinca"));
            fincas.CreateChildPermission(AppPermissions.Pages_Fincas_Edit, L("EditFinca"));
            fincas.CreateChildPermission(AppPermissions.Pages_Fincas_Delete, L("DeleteFinca"));



            var clientes = pages.CreateChildPermission(AppPermissions.Pages_Clientes, L("Clientes"));
            clientes.CreateChildPermission(AppPermissions.Pages_Clientes_Create, L("CreateNewCliente"));
            clientes.CreateChildPermission(AppPermissions.Pages_Clientes_Edit, L("EditCliente"));
            clientes.CreateChildPermission(AppPermissions.Pages_Clientes_Delete, L("DeleteCliente"));



            var municipios = pages.CreateChildPermission(AppPermissions.Pages_Municipios, L("Municipios"));
            municipios.CreateChildPermission(AppPermissions.Pages_Municipios_Create, L("CreateNewMunicipio"));
            municipios.CreateChildPermission(AppPermissions.Pages_Municipios_Edit, L("EditMunicipio"));
            municipios.CreateChildPermission(AppPermissions.Pages_Municipios_Delete, L("DeleteMunicipio"));



            var departamentos = pages.CreateChildPermission(AppPermissions.Pages_Departamentos, L("Departamentos"));
            departamentos.CreateChildPermission(AppPermissions.Pages_Departamentos_Create, L("CreateNewDepartamento"));
            departamentos.CreateChildPermission(AppPermissions.Pages_Departamentos_Edit, L("EditDepartamento"));
            departamentos.CreateChildPermission(AppPermissions.Pages_Departamentos_Delete, L("DeleteDepartamento"));



            var paises = pages.CreateChildPermission(AppPermissions.Pages_Paises, L("Paises"));
            paises.CreateChildPermission(AppPermissions.Pages_Paises_Create, L("CreateNewPais"));
            paises.CreateChildPermission(AppPermissions.Pages_Paises_Edit, L("EditPais"));
            paises.CreateChildPermission(AppPermissions.Pages_Paises_Delete, L("DeletePais"));


            pages.CreateChildPermission(AppPermissions.Pages_DemoUiComponents, L("DemoUiComponents"));

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var roles = administration.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));

            var users = administration.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Impersonation, L("LoginForUsers"));

            var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            var organizationUnits = administration.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits, L("OrganizationUnits"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree, L("ManagingOrganizationTree"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers, L("ManagingMembers"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_UiCustomization, L("VisualSettings"));

            //TENANT-SPECIFIC PERMISSIONS

            pages.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_SubscriptionManagement, L("Subscription"), multiTenancySides: MultiTenancySides.Tenant);

            //HOST-SPECIFIC PERMISSIONS

            var editions = pages.CreateChildPermission(AppPermissions.Pages_Editions, L("Editions"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Create, L("CreatingNewEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Edit, L("EditingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Delete, L("DeletingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_MoveTenantsToAnotherEdition, L("MoveTenantsToAnotherEdition"), multiTenancySides: MultiTenancySides.Host); 

            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Create, L("CreatingNewTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Edit, L("EditingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_ChangeFeatures, L("ChangingFeatures"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Delete, L("DeletingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Impersonation, L("LoginForTenants"), multiTenancySides: MultiTenancySides.Host);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Host);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Maintenance, L("Maintenance"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_HangfireDashboard, L("HangfireDashboard"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PALMASoftConsts.LocalizationSourceName);
        }
    }
}
