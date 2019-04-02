using System;
using Microsoft.AspNetCore.Http;

namespace TesteEnvioArquivo.Models
{
    public class FileInputModel
    {
        public string Name { get; set; }
        public IFormFile FileToUpLoad { get; set; }
    }
}