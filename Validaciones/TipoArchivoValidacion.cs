﻿using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Validaciones
{
    public class TipoArchivoValidacion : ValidationAttribute
    {
        private readonly string[] tiposValidos;

        public TipoArchivoValidacion(string[] tiposValidos)
        {
            this.tiposValidos = tiposValidos;
        }

        public TipoArchivoValidacion(GrupoTipoArchivo grupoTipoArchivo)
        {
            if (grupoTipoArchivo == GrupoTipoArchivo.Imagen)
            {
                tiposValidos = new[] { "image/png", "image/jpeg" };
            }
            else if (grupoTipoArchivo == GrupoTipoArchivo.Video)
            {
                tiposValidos = new[] { "video/mp4" };
            }
            else
            {
                tiposValidos = new[] { "image/png", "image/jpeg", "video/mp4" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            IFormFile formFile = value as IFormFile;

            if (formFile == null) return ValidationResult.Success;

            if (!tiposValidos.Contains(formFile.ContentType))
                return new ValidationResult($"El tipo de archivo debe ser uno de los siguientes: {string.Join(", ", tiposValidos)}");

            return ValidationResult.Success;
        }



    }
}
