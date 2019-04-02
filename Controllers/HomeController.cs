using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteEnvioArquivo.Models;

namespace TesteEnvioArquivo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> EnvioArquivo(FileInputModel model)
        {
            if(model.FileToUpLoad != null){
                if(!String.IsNullOrEmpty(model.Name)){
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", model.FileToUpLoad.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.FileToUpLoad.CopyToAsync(stream);
                    }

                    return new JsonResult(new { Sucesso = true, Mensagem = $"Arquivo Enviado + {model.Name}"});
                } else{
                    return new JsonResult(new { Sucesso = true, Mensagem = "Arquivo Enviado"});
                }
                
            } else{
                return new JsonResult(new { Sucesso = false, Mensagem = "Arquivo nao recebido"});
            }
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
