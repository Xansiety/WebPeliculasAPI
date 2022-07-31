using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace PeliculasAPI.Servicios.AzureStorage
{
    public class AlmacenadorArchivosAzure : IAlmacenArchivos
    {
        private readonly string connectionString;
        public AlmacenadorArchivosAzure(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage");
        }
        
        public async Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string contentType, string ruta)
        {
            await EliminarArchivo(ruta, contenedor);
            return await GuadarArchivo(contenido: contenido, extension: extension, contenedor:  contenedor, contentType: contentType); 
        }

        public async Task EliminarArchivo(string ruta, string contenedor)
        {
            if (string.IsNullOrEmpty(ruta)) return;

            var cliente = new BlobContainerClient(connectionString: connectionString, blobContainerName: contenedor);
            await cliente.CreateIfNotExistsAsync(); //crear el contenedor si no existe
            var archivo = Path.GetFileName(ruta);
            var blob = cliente.GetBlobClient(archivo);
            await blob.DeleteIfExistsAsync();
        }
        
        public async Task<string> GuadarArchivo(byte[] contenido, string extension, string contenedor, string contentType)
        {
            var cliente = new BlobContainerClient(connectionString: connectionString, blobContainerName: contenedor);
            await cliente.CreateIfNotExistsAsync(); //crear el contenedor si no existe
            cliente.SetAccessPolicy(PublicAccessType.Blob); // 

            var archivoNombre = $"{Guid.NewGuid()}{extension}";
            var blob = cliente.GetBlobClient(archivoNombre);

            var blobUploadOptions = new BlobUploadOptions();
            var blobHttpHeader = new BlobHttpHeaders();
            blobHttpHeader.ContentType = contentType;
            blobUploadOptions.HttpHeaders = blobHttpHeader;

            //carga del archivo
            await blob.UploadAsync(new BinaryData(contenido), blobUploadOptions);
            return blob.Uri.ToString();

        }
    }
}
