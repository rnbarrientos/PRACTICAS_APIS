

using EJERCICIO_2.Models.Proveedor;
using EJERCICIO_2.Services.Proveedor;
using EJERCICIO_2.Util;
using Microsoft.AspNetCore.Mvc;

namespace EJERCICIO_2.Controllers.Proveedor
{
    
        public class ProveedorController : Controller

        {
            private readonly IConfiguration _configuration;
            public ProveedorController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

        /// <summary>
        /// Crea un proveedor nuevo.
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// Estructura JSON esperada
        ///
        ///     {
        ///         " tipo_operacion": int,
        ///         " SupplierID ": int,
        ///         "CompanyName": string,
        ///         "ContactName": string,
        ///         "ContactTitle": string
        ///         "City": string,
        ///         "Region": string,
        ///         "PostalCode" :string,
        ///         "Country": string,
        ///         "Phone": string,
        ///         "HomePage": string,
        ///         "Address": string,
        ///         "Fax": string
        ///     }
        ///     
        /// Retorna una estructura JSON con siguiente estructura:
        /// 
        ///     {
        ///         "typeResult": int,
        ///         "codeResult": int,
        ///         "result": string,
        ///         "message": string
        ///     }
        ///
        /// <para>En la etiqueta typeResult, se retorna el estado de la ejecución del servicio [0: Exitoso | 1: Error Controlado | 2: Error no controlado]</para>
        /// <para>En la etiqueta codeResult, se retorna un detalle del TypeResult</para>
        /// <para>En la etiqueta result, se retorna las respuestas esperadas del servicio. Para este servicio se retornará el código de usuario creado.</para>
        /// <para>En la etiqueta message, se retorna un mensaje de tipo informativo, error o éxito.</para>
        ///
        /// </remarks>
        /// <returns>
        /// </returns>
        /// <response code="200">OK. Servicio ejecutado correctamente.</response>
        /// <response code="400">BadRequest. Ocurrió un error en la ejecución del servicio.</response>





        [HttpPost("b/v1/proveedor")]
            public IActionResult CrearProveedor([FromBody] ProveedorModel model)
            {
                string nombreMetodo = "CrearProveedor" + "/ProveedorController";
                string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
                var response = new CustomJSONResult();
                try
                {
                    response = ProveedorService.GestionProveedor(constring, model, 1);
                    return Ok(response);
                }
                catch
                {
                    return BadRequest(response);
                }
            }


        /// <summary>
        /// Actualiza un proveedor.
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// Estructura JSON esperada
        ///
        ///     {
        ///         " tipo_operacion": int,
        ///         " SupplierID ": int,
        ///         "CompanyName": string,
        ///         "ContactName": string,
        ///         "ContactTitle": string
        ///         "City": string,
        ///         "Region": string,
        ///         "PostalCode" :string,
        ///         "Country": string,
        ///         "Phone": string,
        ///         "HomePage": string,
        ///         "Address": string,
        ///         "Fax": string
        ///     }
        ///     
        /// Retorna una estructura JSON con siguiente estructura:
        /// 
        ///     {
        ///         "typeResult": int,
        ///         "codeResult": int,
        ///         "result": string,
        ///         "message": string
        ///     }
        ///
        /// <para>En la etiqueta typeResult, se retorna el estado de la ejecución del servicio [0: Exitoso | 1: Error Controlado | 2: Error no controlado]</para>
        /// <para>En la etiqueta codeResult, se retorna un detalle del TypeResult</para>
        /// <para>En la etiqueta result, se retorna las respuestas esperadas del servicio. Para este servicio se retornará el código de usuario creado.</para>
        /// <para>En la etiqueta message, se retorna un mensaje de tipo informativo, error o éxito.</para>
        ///
        /// </remarks>
        /// <returns>
        /// </returns>
        /// <response code="200">OK. Servicio ejecutado correctamente.</response>
        /// <response code="400">BadRequest. Ocurrió un error en la ejecución del servicio.</response>
        [HttpPut("b/v1/proveedor")]
            public IActionResult ModificarProveedor([FromBody] ProveedorModel model)
            {
                string nombreMetodo = "ModificarProveedor" + "/ProveedorController";
                string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
                var response = new CustomJSONResult();
                try
                {
                    response = ProveedorService.GestionProveedor(constring, model, 2);
                    return Ok(response);
                }
                catch
                {
                    return BadRequest(response);
                }
            }



        /// <summary>
        /// Eliminar un proveedor.
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// Estructura JSON esperada
        ///
        ///     {
        ///         " tipo_operacion": int,
        ///         " SupplierID ": int,
        ///         "CompanyName": string,
        ///         "ContactName": string,
        ///         "ContactTitle": string
        ///         "City": string,
        ///         "Region": string,
        ///         "PostalCode" :string,
        ///         "Country": string,
        ///         "Phone": string,
        ///         "HomePage": string,
        ///         "Address": string,
        ///         "Fax": string
        ///     }
        ///     
        /// Retorna una estructura JSON con siguiente estructura:
        /// 
        ///     {
        ///         "typeResult": int,
        ///         "codeResult": int,
        ///         "result": string,
        ///         "message": string
        ///     }
        ///
        /// <para>En la etiqueta typeResult, se retorna el estado de la ejecución del servicio [0: Exitoso | 1: Error Controlado | 2: Error no controlado]</para>
        /// <para>En la etiqueta codeResult, se retorna un detalle del TypeResult</para>
        /// <para>En la etiqueta result, se retorna las respuestas esperadas del servicio. Para este servicio se retornará el código de usuario creado.</para>
        /// <para>En la etiqueta message, se retorna un mensaje de tipo informativo, error o éxito.</para>
        ///
        /// </remarks>
        /// <returns>
        /// </returns>
        /// <response code="200">OK. Servicio ejecutado correctamente.</response>
        /// <response code="400">BadRequest. Ocurrió un error en la ejecución del servicio.</response>
        [HttpDelete("b/v1/proveedor")]
            public IActionResult EliminarProveedor([FromBody] ProveedorModel model)
            {
                string nombreMetodo = "EliminarProveedor" + "/ProveedorController";
                string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
                var response = new CustomJSONResult();
                try
                {
                    response = ProveedorService.GestionProveedor(constring, model, 3);
                    return Ok(response);
                }
                catch
                {
                    return BadRequest(response);
                }
            }


        }

    
}
