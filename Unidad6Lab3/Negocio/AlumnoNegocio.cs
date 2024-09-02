using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Newtonsoft.Json;

namespace Negocio
{
    public class AlumnoNegocio
    {
        public async static Task<IEnumerable<Alumno>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7011/api/Alumno");
            var data = JsonConvert.DeserializeObject<List<Alumno>>(response);
            return data;
        }
        public async static Task<Boolean> Delete(Alumno alumno)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync("https://localhost:7011/api/Alumno/" + alumno.DNI);
            return response.IsSuccessStatusCode;
        }
        public async static Task<Boolean> Add(Alumno alumno)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync("https://localhost:7011/api/Alumno", alumno);
            return response.IsSuccessStatusCode;
        }
        public async static Task<bool> Update(Alumno alumno)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync("https://localhost:7011/api/Alumno", alumno);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al modificar el alumno.");
            }
            return true;
        }


    }

}
