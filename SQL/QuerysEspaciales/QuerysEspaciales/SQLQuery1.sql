DECLARE @MiUbicacion GEOGRAPHY = 'POINT(-99.5550692 19.2829251)'

  SELECT TOP (1000) [Id]
      ,[Nombre]
      ,[Ubicacion].ToString() as Ubicacion,
	  Ubicacion.STDistance(@MiUbicacion) as DistanciaMts
  FROM [PeliculasAPI].[dbo].[SalasDeCine]
  where Ubicacion.STDistance(@MiUbicacion) <= 3000
  order by Ubicacion.STDistance(@MiUbicacion) asc

  

