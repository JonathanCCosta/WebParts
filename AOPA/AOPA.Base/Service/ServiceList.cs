using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.AOPA.Base.Service
{
    public static class ServiceList
    {
        public static void CreateDiretoriaOrgaoField(SPWeb _Web, SPList _ListRepresentantes)
        {
                SPBusinessDataField lookupField = _ListRepresentantes.Fields.CreateNewField("BusinessData", "Entity") as SPBusinessDataField;
                lookupField.Group = "AOPA - Colunas";
                lookupField.Title = "Diretoria";
                lookupField.StaticName = "diretoria";
                lookupField.SystemInstanceName = "gerpes";
                lookupField.EntityNamespace = "http://shpt15";
                //lookupField.EntityNamespace = "http://da-furnasnetd/sites/aopa";
                lookupField.EntityName = "Novo tipo de conteúdo externo (4)";
                //lookupField.EntityName = "Novo tipo de conteúdo externo";
                lookupField.HasActions = false;
                lookupField.BdcFieldName = "Diretoria";
                lookupField.Required = true;
                _ListRepresentantes.Fields.Add(lookupField);
                _ListRepresentantes.Update();
        }

        public static void CreateNomeOrgaoField(SPWeb _Web, SPList _ListRepresentantes)
        {
            SPBusinessDataField lookupField = _ListRepresentantes.Fields.CreateNewField("BusinessData", "Entity") as SPBusinessDataField;
            lookupField.Group = "AOPA - Colunas";
            lookupField.Title = "Nome Órgao";
            lookupField.StaticName = "Orgao_Nome_Orgao";
            lookupField.SystemInstanceName = "gerpes";
            lookupField.EntityNamespace = "http://shpt15";
            //lookupField.EntityNamespace = "http://da-furnasnetd/sites/aopa";
            lookupField.EntityName = "Novo tipo de conteúdo externo (4)";
            //lookupField.EntityName = "Novo tipo de conteúdo externo";
            lookupField.HasActions = false;
            lookupField.BdcFieldName = "Orgao_Nome_Orgao";
            lookupField.Required = true;
            _ListRepresentantes.Fields.Add(lookupField);
            _ListRepresentantes.Update();
        }

        public static void SetRepresentantesNormativosListSettings(SPWeb _Web, out SPList listRepresentantesNormativos)
        {

            listRepresentantesNormativos = _Web.Lists.TryGetList(Resource.Constants.Lists.RepresentanteNormativo);
            if (listRepresentantesNormativos != null)
            {
                ServiceList.CreateDiretoriaOrgaoField(_Web, listRepresentantesNormativos);
                SPField fieldTitle = listRepresentantesNormativos.Fields[SPBuiltInFieldId.Title];
                fieldTitle.Hidden = true;
                fieldTitle.Update();
                
                SPField fieldRepresentantes = listRepresentantesNormativos.Fields[Resource.Constants.Fields.Representantes];
                fieldRepresentantes.LinkToItem = true;
                fieldRepresentantes.ListItemMenu = true;
                fieldRepresentantes.Update();

                SPView view = listRepresentantesNormativos.DefaultView;
                view.ViewFields.Add("Diretoria");
                //view.ViewFields.Delete(fieldTitle);
                view.Update();
                listRepresentantesNormativos.Update();

            }
        }

        public static void SetAtosNormativosListSettings(SPWeb _Web, out SPList list)
        {

            list = _Web.Lists.TryGetList(Resource.Constants.Lists.Ato);
            if (list != null)
            {
                //ServiceList.CreateDiretoriaOrgaoField(_Web, list);
                ServiceList.CreateNomeOrgaoField(_Web, list);
                //SPField fieldTitle = list.Fields[SPBuiltInFieldId.Title];
                //fieldTitle.Hidden = true;
                //fieldTitle.Update();

                //SPField fieldRepresentantes = list.Fields[Resource.Constants.Fields.AtoNormativo];
                //fieldRepresentantes.LinkToItem = true;
                //fieldRepresentantes.ListItemMenu = true;
                //fieldRepresentantes.Update();

                SPView view = list.DefaultView;
                view.ViewFields.Add("Nome Órgao");
                //view.ViewFields.Add("Diretoria");
                view.Update();
                list.Update();

            }
        }

        public static void SetAndamentoFaseListSettings(SPWeb _Web, out SPList listAndamentoFase)
        {

            listAndamentoFase = _Web.Lists.TryGetList(Resource.Constants.Lists.AndamentoFase);
            if (listAndamentoFase != null)
            {
                SPField fieldTitle = listAndamentoFase.Fields[SPBuiltInFieldId.Title];
                fieldTitle.Hidden = true;
                fieldTitle.ShowInViewForms = false;
                fieldTitle.Update();

                SPField fieldFase = listAndamentoFase.Fields[Resource.Constants.Fields.FaseRevisaoElaboracao];
                fieldFase.LinkToItem = true;
                fieldFase.ListItemMenu = true;
                fieldFase.Update();
                listAndamentoFase.Update();

            }
        }

        public static void CreateGroup(SPWeb webcurrent, string groupname, string description, SPRoleType sPRoleType, params SPUser[] predefinedusers)
        {
            SPGroup group = null;

            try
            {
                group = webcurrent.SiteGroups[groupname];
            }
            catch { }

            if (group == null)
            {
                webcurrent.SiteGroups.Add(groupname, webcurrent.Site.Owner as SPMember, webcurrent.Site.Owner, description);
                group = webcurrent.SiteGroups[groupname];

                SPRoleDefinition roleDefinition = webcurrent.RoleDefinitions.GetByType(sPRoleType);
                SPRoleAssignment roleAssignment = new SPRoleAssignment(group);
                roleAssignment.RoleDefinitionBindings.Add(roleDefinition);
                webcurrent.RoleAssignments.Add(roleAssignment);
                webcurrent.Update();

                //foreach (SPUser user in predefinedusers)
                //    group.AddUser(user);

                GruposDiretorias(groupname, group, webcurrent);
                group.Update();
            }
        }

        public static void GruposDiretorias(string diretoria, SPGroup grupo, SPWeb web)
        {
            switch(diretoria){
                case "Representantes AD":
                    grupo.AddUser(web.EnsureUser("FR21282"));
                    break;
                case "Representantes DA":
                    grupo.AddUser(web.EnsureUser("FR21358"));
                    grupo.AddUser(web.EnsureUser("FR21635"));
                break;
                case "Representantes DE":
                    grupo.AddUser(web.EnsureUser("FR19579"));
                    grupo.AddUser(web.EnsureUser("FR22588"));
                break;
                case "Representantes DF":
                    grupo.AddUser(web.EnsureUser("FR15568"));
                    grupo.AddUser(web.EnsureUser("FR19824"));
                break;
                case "Representantes DN":
                    grupo.AddUser(web.EnsureUser("FR19979"));
                    grupo.AddUser(web.EnsureUser("FR22134"));
                break;
                case "Representantes DP":
                    grupo.AddUser(web.EnsureUser("FR16917"));
                    grupo.AddUser(web.EnsureUser("FR21297"));
                break;
                default:
                // Representantes DO
                    grupo.AddUser(web.EnsureUser("FR22108"));
                    //grupo.AddUser(web.EnsureUser(""));
                break;
            }          
        }

    }
}