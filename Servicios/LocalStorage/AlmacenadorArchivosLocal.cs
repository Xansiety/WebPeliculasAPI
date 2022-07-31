namespace PeliculasAPI.Servicios.LocalStorage
{
    public class AlmacenadorArchivosLocal : IAlmacenArchivos
    {
        private readonly IWebHostEnvironment env; //obtener la ruta de nuestro wwwroot
        private readonly IHttpContextAccessor contextAccessor; // determinamos el dominio en donde esta nuestra app

        public AlmacenadorArchivosLocal(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            this.env = env;
            this.contextAccessor = contextAccessor;
        }
        
        public  async Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string contentType, string ruta)
        {
            await EliminarArchivo(ruta, contenedor);
            return await GuadarArchivo(contenido: contenido, extension: extension, contenedor: contenedor, contentType: contentType);
        }

        public Task EliminarArchivo(string ruta, string contenedor)
        {
            if (ruta != null)
            {
                var nombreArchivo = Path.GetFileName(ruta);
                string directorio = Path.Combine(env.WebRootPath, contenedor, nombreArchivo);
                if (File.Exists(directorio))
                {
                    File.Delete(directorio);
                }
            }
            return Task.FromResult(0);
        }

        public async Task<string> GuadarArchivo(byte[] contenido, string extension, string contenedor, string contentType)
        {
            var archivoNombre = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(env.WebRootPath, contenedor);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string ruta = Path.Combine(folder, archivoNombre);
            await File.WriteAllBytesAsync(ruta, contenido);

            var UrlActual = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}";
            var urlParaDB = Path.Combine(UrlActual, contenedor, archivoNombre).Replace("\\", "/");
            return urlParaDB;
        }
    }
}
