using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Utilitario.Comun
{
   public class Utilidades
    {

        public static void CargaCombo(ref DropDownList objCombo, DataTable lista, string valueField, string textField, bool insertSeleccione = true)
        {
            if (lista == null)
            {
                objCombo.DataSource = null;
                if (objCombo.Items.Count > 0)
                {
                    for (int i = 0; i <= objCombo.Items.Count - 1; i++)
                    {
                        objCombo.Items.Remove(objCombo.Items[ 0]);
                    }
                }
            }
            else
            {
                objCombo.DataValueField = valueField;
                objCombo.DataTextField = textField;
                objCombo.DataSource = lista;
                objCombo.DataBind();
            }

            if (insertSeleccione)
            {
                objCombo.Items.Insert(0, new ListItem("SELECCIONE", "0"));
            }
        }


        public static int ToInt(string value)
        {
            if (object.ReferenceEquals(value, DBNull.Value))
            {
                return 0;
            }

            int _Res = 0;
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else if (int.TryParse(value,out _Res))
            {
                return _Res;
            }
            else
            {
                return 0;
            }
        }

        public static decimal ToDecimal(string value)
        {
            if (object.ReferenceEquals(value, DBNull.Value))
            {
                return 0;
            }

            decimal _Res = 0;
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else if (decimal.TryParse(value, out _Res))
            {
                return _Res;
            }
            else
            {
                return 0;
            }
        }

    }
}
