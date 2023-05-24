using EJERCICIO_2.Models.Proveedor;
using EJERCICIO_2.Util;
using System.Data;
using System.Data.SqlClient;

namespace EJERCICIO_2.Services.Proveedor
{
    public class ProveedorService
    {

        ///<summary>
        /// Método el cual consume el procedimiento almacenado que gestiona un proveedor
        ///</summary>
        ///<remarks>
        ///Autor: by rbarrientos 20230523 
        ///</remarks>
        ///<returns>
        /// Retorna una estructura JSON con siguiente estructura:
        /// 
        ///     {
        ///         "typeResult": int,
        ///         "codeResult": int,
        ///         "result": string,
        ///         "message": string
        ///     }
        ///
        /// En la etiqueta typeResult, se retorna el estado de la ejecución del servicio [0: Exitoso | 1: Error Controlado | 2: Error no controlado]
        /// En la etiqueta codeResult, se retorna un detalle del TypeResult
        /// En la etiqueta result, se retorna el código de producto recien creado para la operación crear, etc..
        /// En la etiqueta message, se retorna un mensaje de tipo informativo, error o éxito.
        /// </returns>
        public static CustomJSONResult GestionProveedor(string constring, ProveedorModel modelo, int tipo_operacion)
        {
            string nombreMetodo = "GestionProveedor" + "/ProveedorService";
            CustomJSONResult Rslt = new CustomJSONResult();
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(ReferenciaBD.SP_GESTION_PROVEEDOR, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pnTipoOperacion", SqlDbType.Int).Value = tipo_operacion;
                cmd.Parameters.Add("@pnSupplierID", SqlDbType.Int).Value = modelo.Supplier;
                cmd.Parameters.Add("@pcCompanyName", SqlDbType.NVarChar).Value = modelo.CompanyName;
                cmd.Parameters.Add("@pcContactName", SqlDbType.NVarChar).Value = modelo.ContactName;
                cmd.Parameters.Add("@pcContactTitle", SqlDbType.NVarChar).Value = modelo.ContactTitle;
                cmd.Parameters.Add("@pcCity", SqlDbType.NVarChar).Value = modelo.City;
                cmd.Parameters.Add("@pcRegion", SqlDbType.NVarChar).Value = modelo.Region;
                cmd.Parameters.Add("@pcPostalCode", SqlDbType.NVarChar).Value = modelo.PostalCode;
                cmd.Parameters.Add("@pcCountry", SqlDbType.NVarChar).Value = modelo.Country;
                cmd.Parameters.Add("@pcPhone", SqlDbType.NVarChar).Value = modelo.Phone;
                cmd.Parameters.Add("@pcHomePage", SqlDbType.NVarChar).Value = modelo.HomePage;
                cmd.Parameters.Add("@pcAddress", SqlDbType.VarChar).Value = modelo.Address;
                cmd.Parameters.Add("@pcFax", SqlDbType.VarChar).Value = modelo.Fax;



                SqlParameter pcTypeResultparam = new SqlParameter();
                pcTypeResultparam.ParameterName = "@pnTypeResult";
                pcTypeResultparam.SqlDbType = SqlDbType.Int;
                pcTypeResultparam.Size = int.MaxValue;
                pcTypeResultparam.Direction = ParameterDirection.Output;



                SqlParameter pcCodeResultparam = new SqlParameter();
                pcCodeResultparam.ParameterName = "@pnCodeResult";
                pcCodeResultparam.SqlDbType = SqlDbType.Int;
                pcCodeResultparam.Size = int.MaxValue;
                pcCodeResultparam.Direction = ParameterDirection.Output;

                SqlParameter pcResultparam = new SqlParameter();
                pcResultparam.ParameterName = "@pcResult";
                pcResultparam.SqlDbType = SqlDbType.VarChar;
                pcResultparam.Size = int.MaxValue;
                pcResultparam.Direction = ParameterDirection.Output;

                SqlParameter pcMessageparam = new SqlParameter();
                pcMessageparam.ParameterName = "@pcMessage";
                pcMessageparam.SqlDbType = SqlDbType.VarChar;
                pcMessageparam.Size = int.MaxValue;
                pcMessageparam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(pcTypeResultparam);
                cmd.Parameters.Add(pcCodeResultparam);
                cmd.Parameters.Add(pcResultparam);
                cmd.Parameters.Add(pcMessageparam);



                SqlDataReader reader = cmd.ExecuteReader();

                reader.Close();

                int pnTypeResult = (cmd.Parameters["@pnTypeResult"].Value.ToString() == "null") ? 0 : Convert.ToInt32(cmd.Parameters["@pnTypeResult"].Value);
                int pnCodeResult = (cmd.Parameters["@pnCodeResult"].Value.ToString() == "null") ? 0 : Convert.ToInt32(cmd.Parameters["@pnCodeResult"].Value);
                String pcResult = (cmd.Parameters["@pcResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pcResult"].Value.ToString();
                String pcMessage = (cmd.Parameters["@pcMessage"].Value.ToString() == "null") ? null : cmd.Parameters["@pcMessage"].Value.ToString();

                conn.Close();

                Rslt.TypeResult = pnTypeResult;
                Rslt.CodeResult = pnCodeResult;
                Rslt.Result = pcResult;
                Rslt.Message = pcMessage;

                return Rslt;
            }
            catch (Exception ex)
            {
                Rslt.TypeResult = 2;
                Rslt.CodeResult = 1;
                Rslt.Message = "Ocurrió un error";

                return Rslt;
            }
        }


    }
}
