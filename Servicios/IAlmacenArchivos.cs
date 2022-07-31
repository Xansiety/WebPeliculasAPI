namespace PeliculasAPI.Servicios
{
    public interface IAlmacenArchivos
    {
        Task<string> GuadarArchivo(byte[] contenido, string extension, string contenedor, string contentType);
        Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string contentType, string ruta);
        Task EliminarArchivo(string ruta, string contenedor);
    }
}
