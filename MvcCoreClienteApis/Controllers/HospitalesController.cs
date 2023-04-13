using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteApis.Models;
using MvcCoreClienteApis.Services;

namespace MvcCoreClienteApis.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceHospital service;

        public HospitalesController(ServiceHospital service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Servidor()
        {
            List<Hospital> hospitales =
                await this.service.GetHospitalsAsync();
            return View(hospitales);
        }

        public async Task<IActionResult> Details(int idHospital)
        {
            Hospital hospital =
                await this.service.FindHospital(idHospital);
            return View(hospital);
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cliente()
        {
            return View();
        }

       
    }
}
