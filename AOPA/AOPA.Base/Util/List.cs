using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace Furnas.AOPA.Base.Util
{
    public static class List
    {
        /// <summary>
        /// Altera as propriedades básicos do campo Title sem intervir na plataforma
        /// </summary>
        /// <param name="_Web">Web Current</param>
        /// <param name="listname">Nome da Lista</param>
        /// <param name="fieldnewname">Novo nome para o campo Title</param>
        /// <param name="list">Objeto SPList que será retornado no procedimento</param>
        /// <param name="required">Campo Obrigatório?(Campo Opcional)</param>
        /// <param name="indexed">Campo Indexado?(Campo Opcional)</param>
        public static void ChangeField(SPWeb _Web, string listname, string fieldname, string fieldnewname, out SPList list, bool required = false, bool indexed = false)
        {
            list = _Web.Lists.TryGetList(listname);
            ChangeField(_Web, list, fieldname, fieldnewname, required, indexed);
        }

        /// <summary>
        /// Altera as propriedades básicos do campo Title sem intervir na plataforma
        /// </summary>
        /// <param name="_Web">Web Current</param>
        /// <param name="listname">Nome da Lista</param>
        /// <param name="fieldnewname">Novo nome para o campo Title</param>
        /// <param name="list">Objeto SPList que será retornado no procedimento</param>
        /// <param name="required">Campo Obrigatório?(Campo Opcional)</param>
        /// <param name="indexed">Campo Indexado?(Campo Opcional)</param>
        public static void ChangeField(SPWeb _Web, string listname, Guid fielduid, string fieldnewname, out SPList list, bool required = false, bool indexed = false)
        {
            list = _Web.Lists.TryGetList(listname);
            ChangeField(_Web, list, fielduid, fieldnewname, required, indexed);
        }

        /// <summary>
        /// Altera as propriedades básicos do campo Title sem intervir na plataforma
        /// </summary>
        public static void ChangeField(SPWeb _Web, SPList list, string fieldname, string fieldnewname, bool required = false, bool indexed = false)
        {
            if (list != null)
            {
                SPField field = list.Fields[fieldname];
                ChangeField(field, fieldnewname, required, indexed);
            }
        }



        /// <summary>
        /// Altera as propriedades básicos do campo Title sem intervir na plataforma
        /// </summary>
        public static void ChangeField(SPWeb _Web, SPList list, Guid fieldiud, string fieldnewname, bool required = false, bool indexed = false)
        {
            if (list != null)
            {
                SPField field = list.Fields[fieldiud];
                ChangeField(field, fieldnewname, required, indexed);
            }
        }

        /// <summary>
        /// Altera as propriedades básicos do campo Title sem intervir na plataforma
        /// </summary>
        public static void ChangeField(SPField field, string fieldnewname, bool required = false, bool indexed = false)
        {
            field.Title = fieldnewname;
            field.Indexed = indexed;
            field.Required = required;
            field.Update();
        }

        /// <summary>
        /// Remove a(s) lista(s) passadas por parâmetro.
        /// </summary>
        public static void RemoveList(SPWeb _Web, params string[] listnames)
        {
            bool allowunsafe = _Web.AllowUnsafeUpdates;
            if (!_Web.AllowUnsafeUpdates)
                _Web.AllowUnsafeUpdates = true;
            foreach (string listname in listnames)
            {
                SPList list = _Web.Lists.TryGetList(listname);
                if (list != null)
                {
                    list.Delete();
                }
            }
            _Web.AllowUnsafeUpdates = allowunsafe;
        }

        /// <summary>
        /// Altera as propriedades de Relacionamento entre as listas lookups
        /// </summary>
        public static void ChangeDeleteRestriction(SPWeb _Web, string listname, string fieldname, SPRelationshipDeleteBehavior behavior)
        {
            SPList list = _Web.Lists.TryGetList(listname);
            ChangeDeleteRestriction(_Web, list, fieldname, behavior);
        }

        /// <summary>
        /// Altera as propriedades de Relacionamento entre as listas lookups
        /// </summary>
        public static void ChangeDeleteRestriction(SPWeb _Web, SPList list, string fieldname, SPRelationshipDeleteBehavior behavior)
        {
            if (list != null)
            {
                SPField field = list.Fields[fieldname];
                SPFieldLookup fieldLookup = (SPFieldLookup)field;
                fieldLookup.Indexed = true;
                fieldLookup.RelationshipDeleteBehavior = behavior;
                fieldLookup.Update();
            }
        }
    }
}
