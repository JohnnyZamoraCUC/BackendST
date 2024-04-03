using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using ClasesData;
using Controllers.Models;
using Google.Authenticator;
using Aeronaves = Controllers.Models.Aeronaves;
using Vuelos = Controllers.Models.Vuelos;

namespace Controllers.Controllers
{
    public class RadarController : ApiController
    {
        private readonly tiusr26pl_ProyectoSitiosEntities RadarEntidad = new tiusr26pl_ProyectoSitiosEntities();

        public RadarController()
        {
            RadarEntidad.Configuration.LazyLoadingEnabled = false;
            RadarEntidad.Configuration.ProxyCreationEnabled = false;
        }
        [HttpGet]
        [Route("api/Radar/Obtener")]
        public IHttpActionResult ObtenerTodos()
        {
            try
            {
                // Realizar el join entre Vuelos y Aeronaves utilizando LINQ
                var vuelosConAeronaves = (from vuelo in RadarEntidad.Vuelos
                                          join aeronave in RadarEntidad.Aeronaves
                                          on vuelo.IdAeronave equals aeronave.IdAeronave
                                          select new
                                          {
                                              Vuelo = vuelo,
                                              Aeronave = aeronave
                                          }).ToList();

                // Convertir a modelos Vuelos y Aeronaves
                List<Vuelos> vuelos = new List<Vuelos>();
                List<Aeronaves> aeronaves = new List<Aeronaves>();

                foreach (var item in vuelosConAeronaves)
                {
                    vuelos.Add(new Vuelos
                    {
                        IdVuelo = item.Vuelo.IdVuelo,
                        NumeroVuelo = item.Vuelo.NumeroVuelo,
                        
                        // Agregar los demás campos según corresponda
                    });

                    aeronaves.Add(new Aeronaves
                    {
                        IdAeronave = item.Aeronave.IdAeronave,
                        Modelo = item.Aeronave.Modelo,
                        Fabricante = item.Aeronave.Fabricante,
                        // Agregar los demás campos según corresponda
                    });
                }

                return Ok(new { Vuelos = vuelos, Aeronaves = aeronaves });
            }
            catch (Exception ex)
            {
                // Registrar el error o notificar de alguna manera
                Console.WriteLine($"Error al obtener todos los vuelos: {ex.Message}");
                return InternalServerError();
            }
        } 

    }
}
