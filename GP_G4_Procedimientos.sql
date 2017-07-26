if exists(select * from sys.objects where name='updateStock') begin 
drop proc updateStock
end
 go
if exists(select * from sys.objects where name='usp_ActualizarProgramacion_i') begin 
drop proc usp_ActualizarProgramacion_i
end
 go
if exists(select * from sys.objects where name='usp_Almacen_gl') begin 
drop proc usp_Almacen_gl
end
 go
if exists(select * from sys.objects where name='usp_AnularProgramacion_i') begin 
drop proc usp_AnularProgramacion_i
end
 go
if exists(select * from sys.objects where name='usp_BuscarCanil_GL') begin 
drop proc usp_BuscarCanil_GL
end
 go
if exists(select * from sys.objects where name='usp_BuscarCanilDetalle_GL') begin 
drop proc usp_BuscarCanilDetalle_GL
end
 go
if exists(select * from sys.objects where name='usp_BuscarSector_GL') begin 
drop proc usp_BuscarSector_GL
end
 go
if exists(select * from sys.objects where name='usp_BuscarSectorDetalle_GL') begin 
drop proc usp_BuscarSectorDetalle_GL
end
 go
if exists(select * from sys.objects where name='usp_EliminarCanilSector_i') begin 
drop proc usp_EliminarCanilSector_i
end
 go
if exists(select * from sys.objects where name='usp_Empleado_gl') begin 
drop proc usp_Empleado_gl
end
 go
if exists(select * from sys.objects where name='usp_EmpleadosRolID_gl') begin 
drop proc usp_EmpleadosRolID_gl
end
 go
if exists(select * from sys.objects where name='usp_EstadoCita_gl') begin 
drop proc usp_EstadoCita_gl
end
 go
if exists(select * from sys.objects where name='usp_EstadosHS_gl') begin 
drop proc usp_EstadosHS_gl
end
 go
if exists(select * from sys.objects where name='usp_GestionHojaServicio_gl') begin 
drop proc usp_GestionHojaServicio_gl
end
 go
if exists(select * from sys.objects where name='usp_GestionHojaServicioDetalle_gl') begin 
drop proc usp_GestionHojaServicioDetalle_gl
end
 go
if exists(select * from sys.objects where name='usp_getCitaDetalle_g') begin 
drop proc usp_getCitaDetalle_g
end
 go
if exists(select * from sys.objects where name='usp_getCitaDetalleCompleto_g') begin 
drop proc usp_getCitaDetalleCompleto_g
end
 go
if exists(select * from sys.objects where name='usp_getCitaDetalleEmpleados_g') begin 
drop proc usp_getCitaDetalleEmpleados_g
end
 go
if exists(select * from sys.objects where name='usp_getMaterial_gl') begin 
drop proc usp_getMaterial_gl
end
 go
if exists(select * from sys.objects where name='usp_getMaterialxAtencion_gl') begin 
drop proc usp_getMaterialxAtencion_gl
end
 go
if exists(select * from sys.objects where name='usp_getMaterialxCod_gl') begin 
drop proc usp_getMaterialxCod_gl
end
 go




if exists(select * from sys.objects where name='usp_GrabarCanil_i') begin 
drop proc usp_GrabarCanil_i
end
 go
if exists(select * from sys.objects where name='usp_GrabarSector_i') begin 
drop proc usp_GrabarSector_i
end
 go
if exists(select * from sys.objects where name='usp_HojaServicio_ComentsGrabar') begin 
drop proc usp_HojaServicio_ComentsGrabar
end
 go
if exists(select * from sys.objects where name='usp_HojaServicio_Grabar') begin 
drop proc dbo.usp_HojaServicio_Grabar
end
 go
if exists(select * from sys.objects where name='usp_KardexActualizar') begin 
drop proc usp_KardexActualizar
end
 go
if exists(select * from sys.objects where name='usp_KardexMovimiento_gl') begin 
drop proc usp_KardexMovimiento_gl
end
 go
if exists(select * from sys.objects where name='usp_ObtenerGrafica1_g') begin 
drop proc usp_ObtenerGrafica1_g
end
 go
if exists(select * from sys.objects where name='usp_ObtenerGrafica2_g') begin 
drop proc usp_ObtenerGrafica2_g
end
 go
if exists(select * from sys.objects where name='usp_ObtenerGrafica3_g') begin 
drop proc usp_ObtenerGrafica3_g
end
 go
if exists(select * from sys.objects where name='usp_ObtenerGrafico4_g') begin 
drop proc usp_ObtenerGrafico4_g
end
 go
if exists(select * from sys.objects where name='usp_ObtenerResumen_g') begin 
drop proc usp_ObtenerResumen_g
end
 go
if exists(select * from sys.objects where name='usp_ParametrosCombo_GL') begin 
drop proc usp_ParametrosCombo_GL
end
 go
if exists(select * from sys.objects where name='usp_ParametrosComboGEN_GL') begin 
drop proc usp_ParametrosComboGEN_GL
end
 go

if exists(select * from sys.objects where name='usp_ProgCitaBusquedaCita_gl') begin 
drop proc usp_ProgCitaBusquedaCita_gl
end
 go
if exists(select * from sys.objects where name='usp_ReqMaterial_gl') begin 
drop proc usp_ReqMaterial_gl
end
 go
if exists(select * from sys.objects where name='usp_ReqMaterialesDisponiblegl') begin 
drop proc usp_ReqMaterialesDisponiblegl
end
 go
if exists(select * from sys.objects where name='usp_RequerimientoActualizar') begin 
drop proc usp_RequerimientoActualizar
end
 go
if exists(select * from sys.objects where name='usp_RequerimientoAtencionActualizada') begin 
drop proc usp_RequerimientoAtencionActualizada
end
 go
if exists(select * from sys.objects where name='usp_RequerimientoTipo') begin 
drop proc usp_RequerimientoTipo
end
 go
if exists(select * from sys.objects where name='usp_Roles_gl') begin 
drop proc usp_Roles_gl
end
 go
if exists(select * from sys.objects where name='usp_Sectores_gl') begin 
drop proc usp_Sectores_gl
end
 go
if exists(select * from sys.objects where name='usp_Servicio_gl') begin 
drop proc usp_Servicio_gl
end
 go
if exists(select * from sys.objects where name='usp_TipoMovimiento_gl') begin 
drop proc usp_TipoMovimiento_gl
end
 go


if exists(select * from sys.objects where name='UTILfn_Split_wWS') begin 
drop function UTILfn_Split_wWS
end
 go

/*
if exists(select * from sys.types where name='dtEmpleados') begin 
drop type dbo.dtEmpleados
end
 go
if exists(select * from sys.types where name='dtMateriales') begin 
drop type dbo.dtMateriales
end
 go
if exists(select * from sys.types where name='DtServicios') begin 
drop type dbo.DtServicios
end
 go
if exists(select * from sys.types where name='listMateriales') begin 
drop type dbo.listMateriales
end
 go

 */

/*
ALTER TYPE [dbo].[dtEmpleados] AS TABLE(
	[idEmpleado] [int] NULL,
	[nombreEmpleado] [varchar](1000) NULL,
	[idServicio] [int] NULL
)
GO


ALTER TYPE [dbo].[dtMateriales] AS TABLE(
	[MaterialID] [int] NULL,
	[Cantidad] [decimal](16, 2) NULL
)
GO

ALTER TYPE [dbo].[DtServicios] AS TABLE(
	[idDetalleCitaServicio] [varchar](1000) NULL,
	[idDetalleCita] [int] NULL,
	[Servicio] [varchar](1000) NULL,
	[idServicio] [int] NULL,
	[HoraInicio] [varchar](5) NULL,
	[HoraFin] [varchar](5) NULL,
	[Empleados] [varchar](1000) NULL,
	[idSector] [int] NULL
)
GO



ALTER TYPE [dbo].[listMateriales] AS TABLE(
	[MaterialID] [int] NULL,
	[Precio] [decimal](16, 2) NULL,
	[Cantidad] [decimal](16, 2) NULL
)
GO
*/




---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

  
  ALTER proc usp_GP_ActualizarStock
  as
  begin
  
  DECLARE @TAB AS TABLE(idMaterial int, material varchar(500), uni varchar(500), smin decimal(16,2), smax decimal(16,2), sactual decimal(16,2), color varchar(300))

insert into @tab
exec usp_KardexMaterialesgl

update GG_Material
set Stock= t.sactual
from @tab t
where t.idMaterial= GG_Material.IdMaterial
  end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        
        
        
ALTER proc usp_GP_ActualizarProgramacion              
@idDetalleCita int,              
@idServicio int,              
@idSector int,              
@idCitas varchar(8000) ,             
@dtEmpleados dbo.dtEmpleados readOnly              
as              
begin              
              
              
  SELECT ID, VALUE            
  into #temp            
  FROM dbo.fnc_GP_UTILSplitwWS(@idCitas,';')            
              
  declare @conta int =1            
  declare @total int             
  select @total= count(*)            
  from #temp            
              
               
  declare @idCita int            
  WHILE(@CONTA <=@TOTAL)            
  BEGIN            
              
  SELECT @idCita=VALUE            
  FROM #temp WHERE id= @CONTA            
              
  SELECT @idDetalleCita = IDDETALLECITA            
  from GC_DetalleCita            
  where idcita=@idCita and idServicio= @idServicio            
              
              
              
              
declare @idDetprogramacion int              
              
declare @dateCIta datetime               
              
select @dateCIta= Fecha from GC_Cita where idcita=@idCita              
              
                
declare @HoraIni varchar(100)              
declare @HoraFin varchar(100)              
              
              
              
if exists(select * from GC_DetalleCita dc inner join GP_DetalleProgramacion c on c.idDetalleCita= dc.idDetalleCita  where dc.idDetalleCita= @idDetalleCita and dc.idServicio=@idServicio )              
begin              
              
select @idDetprogramacion=c.idDetalleProgramacion              
from GC_DetalleCita dc               
inner join GP_DetalleProgramacion c on c.idDetalleCita= dc.idDetalleCita                
where dc.idDetalleCita= @idDetalleCita  and dc.idServicio=@idServicio              
              
update GP_DetalleProgramacion              
set idSectorTrabajo=@idSector , Estado='002'              
where idDetalleProgramacion= @idDetprogramacion              
              
              
              
delete from  GP_EmpleadoDetalleProgramacion where idDetalleProgramacion in ( @idDetprogramacion)              
              
              
insert into GP_EmpleadoDetalleProgramacion               
select idEmpleado , @idDetprogramacion              
from @dtEmpleados              
WHERE idServicio=@idServicio              
              
              
              
              
end              
else              
begin                      
              
insert into GP_DetalleProgramacion values(@idDetalleCita,CAST( @dateCIta + ' ' + @HoraIni as datetime),CAST( @dateCIta + ' ' + @HoraFin as datetime),'002',@idSector )              
set  @idDetprogramacion=@@IDENTITY              
              
              
insert into GP_EmpleadoDetalleProgramacion               
select idEmpleado , @idDetprogramacion              
from @dtEmpleados              
WHERE idServicio=@idServicio              
              
              
end              
            
UPDATE GC_DetalleCita              
SET Estado='002'              
WHERE idDetalleCita=@idDetalleCita              
            
        
  IF NOT EXISTS(SELECT * FROM  dbo.GP_HojaServicio WHERE IDDETALLEPROGRAMACION= @idDetprogramacion)      
  BEGIN      
        
  declare @contaHS int , @idHS int , @fecha datetime      
  select @contaHS =max(cast(REPLACE(NumHojaServicio,'HS','') as int))      
  from GP_HojaServicio      
        
  select @fecha= fechaInicio      
  from GP_DetalleProgramacion      
  where idDetalleProgramacion=@idDetprogramacion      
         
  declare @coo varchar(10)      
  select @coo='HS' + replicate('0',3-len(cast(@contaHS +1 as varchar(5)))) + cast(@contaHS +1 as varchar(5))      
   
 insert into dbo.GP_HojaServicio   values( @coo,ISNULL(@fecha,GETDATE()),'','','001',@idDetprogramacion)      
       
 set @idHS=@@identity      
       
  END      
              
              
              
  SET @conta = @conta+1            
  END            
              
              
end 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER proc usp_GP_ListarAlmacen
as
begin
select idAlmacen, nombreAlmacen descripcion
from dbo.GP_Almacen
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
          
          
            
ALTER proc usp_GP_AnularProgramacion
@idDetalleCita int,            
@idServicio int,             
@idCitas varchar(8000) ,            
@MotivoAnulacion varchar(500)            
as            
begin            
            
            
          
            
  SELECT ID, VALUE          
  into #temp          
  FROM dbo.fnc_GP_UTILSplitwWS(@idCitas,';')          
            
  declare @conta int =1          
  declare @total int           
  select @total= count(*)          
  from #temp          
            
             
  declare @idCita int          
  WHILE(@CONTA <=@TOTAL)          
  BEGIN          
            
  SELECT @idCita=VALUE          
  FROM #temp WHERE id= @CONTA          
            
  SELECT @idDetalleCita = IDDETALLECITA          
  from GC_DetalleCita          
  where idcita=@idCita and idServicio= @idServicio          
            
            
            
  select @idCita = idcita          
  from GC_DetalleCita          
  where idDetalleCita=@idDetalleCita          
            
update GP_DetalleProgramacion            
set Estado ='003'   --,MotivoAnulacion=@MotivoAnulacion          
where idDetalleCita in (@idDetalleCita)            
            
            
update GC_DetalleCita            
set Estado ='004'             
where iddetallecita=@iddetallecita   and idServicio=@idServicio          
            
       IF NOT EXISTS(SELECT * FROM  dbo.GP_HojaServicio WHERE IDDETALLEPROGRAMACION=       
       (SELECT idDetalleProgramacion FROM  GP_DetalleProgramacion where idDetalleCita=@idDetalleCita    ))      
  BEGIN      
        
          
  UPDATE GP_HojaServicio      
  SET ESTADO='004'      
  where idHojaServicio=(SELECT idHojaServicio FROM  dbo.GP_HojaServicio WHERE IDDETALLEPROGRAMACION=       
       (SELECT idDetalleProgramacion FROM  GP_DetalleProgramacion where idDetalleCita=@idDetalleCita    ))      
             
  END      
            
  SET @conta = @conta+1          
  END          
            
end 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER proc usp_GP_BuscarCanil
@tipo VarChar(100) = null,
@fechaIni VarChar(100) = null,
@fechaFin VarChar(100) = null,
@Recurso VarChar(100) = null,
@Estado VarChar(100) = null                
as
begin

select  CodigoCanil codigo, NombreCanil nombre, descripcionTamaño tamanio,
DscParametro estado,DescripcionEspecie especie ,Observacion observaciones ,
cast(case when gc.estado in ('004','001') then 1 else 0 end as bit) Editar,
cast(case when gc.estado='004' then 1 else 0 end as bit) Eliminar , IdCanil idCanil 
from dbo.GP_Canil gc
inner join GCP_Tamaño t on t.idTamaño= gc.IdTamaño
inner join GCP_Especie e on e.CodigoEspecie = gc.CodigoEspecie
inner join dbo.GG_Parametro es on (es.Parametro= gc.Estado and dominio='016')
 where es.Parametro<>'005'
and(ISNULL(nullif(@Estado,'0'),'')='' or es.Parametro= @Estado )
and  (ISNULL(@fechaIni,'')='' or Convert(varchar(8),cast(gc.FechaRegistro as datetime) , 112)>= Convert(varchar(8),CAST(@fechaIni as datetime) , 112))                                                        
AND (ISNULL(@fechaFin,'')='' or Convert(varchar(8), cast(gc.FechaRegistro as datetime) , 112)<= Convert(varchar(8),CAST(@fechaFin as datetime) , 112))                                                  
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER proc usp_GP_BuscarCanilDetalle
@idCanil int
as
begin

select CodigoCanil CodigoCanil , NombreCanil  NombreCanil,
IdTamaño TamanioCanil, CodigoEspecie  EspecieCanil, Estado EstadoCanil, Observacion ObservacionesCanil
from dbo.GP_Canil
where IdCanil = @idCanil
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER proc usp_GP_BuscarSector
@tipo VarChar(100) = null,
@fechaIni VarChar(100) = null,
@fechaFin VarChar(100) = null,
@Recurso VarChar(100) = null,
@Estado VarChar(100) = null                
as
begin

select  CodigoSectorTrabajo codigo,nombreSectorTrabajo nombre,
sr.nombre servicio, es.DscParametro estado, Observacion observaciones,
cast(case when s.estado in ('004','001') then 1 else 0 end as bit) Editar,
cast(case when s.estado='004' then 1 else 0 end as bit) Eliminar,s.idSectorTrabajo idSector
from dbo.GP_SectorTrabajo s
inner join dbo.GP_ServicioSectorTrabajo st on s.idSectorTrabajo= st.idSectorTrabajo
inner join dbo.GG_Servicio sr on st.idServicio= sr.idServicio
inner join dbo.GG_Parametro es on (es.Parametro= s.Estado and dominio='016')
  where  es.Parametro<>'005'
and(ISNULL(nullif(@Estado,'0'),'')='' or es.Parametro= @Estado )
 and   (ISNULL(@fechaIni,'')='' or Convert(varchar(8),cast(s.FechaRegistro as datetime) , 112)>= Convert(varchar(8),CAST(@fechaIni as datetime) , 112))                                                        
AND (ISNULL(@fechaFin,'')='' or Convert(varchar(8), cast(s.FechaRegistro as datetime) , 112)<= Convert(varchar(8),CAST(@fechaFin as datetime) , 112))                                                  


end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER proc usp_GP_BuscarSectorDetalle
@idSector int
as
begin
select s.CodigoSectorTrabajo CodigoSector,nombreSectorTrabajo NombreSector,st. idServicio ServicioSector, s.Estado EstadoSector, 
Observacion ObservacionesSector
from dbo.GP_SectorTrabajo s
inner join dbo.GP_ServicioSectorTrabajo st on s.idSectorTrabajo= st.idSectorTrabajo
inner join dbo.GG_Servicio sr on st.idServicio= sr.idServicio
inner join dbo.GG_Parametro es on (es.Parametro= s.Estado and dominio='016')
where s.idSectorTrabajo= @idSector
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER proc usp_GP_EliminarCanilSector
@id int,
@tipo VarChar(100) = null                
as
begin
if (@tipo='S')
BEGIN

UPDATE dbo.GP_SectorTrabajo
SET Estado ='005'
WHERE idSectorTrabajo=@id
END
ELSE
BEGIN
UPDATE dbo.GP_Canil
SET Estado ='005'
WHERE IDCANIL=@id
END

end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    
 ALTER PROC usp_GP_ListarEmpleado
     
    
 AS    
 BEGIN    
     
 SELECT     
 idEmpleado,    
    ISNULL(apellidoPaterno,'')+' ' +ISNULL(apellidoMaterno,'')+', '+ISNULL(Nombres,'') Nombres    
    FROM     dbo.GG_Empleado
    
 END

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      
ALTER proc [dbo].[usp_GP_ListarEmpleadoRol]       
@rolID int  ,      
@detalleCitaID varchar(8000)      
as        
begin        
      
        
select e.idEmpleado, nombres + ' ' + apellidoPaterno  nombreEmpleado        
from dbo.GG_Empleado e        
inner join dbo.GG_EmpleadoRol er on er.idEmpleado= e.idEmpleado        
where er.idRol= @rolID -- AND E.idEmpleado  IN (SELECT idEmpleado from #EmpNoDispo)      
end 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER  proc usp_GP_ListarEstadoCita
as    
begin     
select Parametro idEstado, DscParametro descripcion    
from dbo.GG_Parametro e     
where e.Dominio='003'       
end 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER proc usp_GP_ListarEstadoHojaServicio
as
begin
select Parametro idEstado, DscParametro descripcion    
from   dbo.GG_Parametro where dominio ='002'

end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 ALTER PROC usp_GP_ListarHojaServicio  
@idDetalleCita int =null,            
@FechaInicial varchar(10) = null,                  
@FechaFinal varchar(10) = null            
 AS            
              
 BEGIN              
declare @day varchar(10)            
            
select  @day= convert(varchar(10),MAX(fechainicio),112)            
from GP_DetalleProgramacion            
               
             
 select hs.idHojaServicio,convert(varchar(5),cast(isnull(dp.fechaInicio,getdate()) as datetime),108)horaCita,            
 convert(varchar(10),cast(isnull(dp.fechaInicio,getdate()) as datetime),103)fechaCita,            
 c.NroCita,cl.nombreCliente + ' '+ cl.apellidoCliente Cliente, m.nombreMascota,            
 e.descripcionEspecie especieMascota,GENERO generoMascota,            
 r.nombreRaza razaMascota, t.descripcionTamaño tamanioMascota,            
  hs.canil canilMascota,            
  ehs.dscParametro EstadoCita,hs.estado ,            
  cast(case when ehs.Parametro='001' then 1 else 0 end as bit) Ejecutar,            
   cast(case when ehs.Parametro='002' then 1 else 0 end as bit)  Finalizar,            
  s.nombre,fechaInicio   ,
  S.NOMBRE servicio         
              
             
 from dbo.GP_DetalleProgramacion dp         
 inner join dbo.GC_DetalleCita dc on dc.iddetallecita= dp.idDetalleCita            
 inner join dbo.GG_Servicio s on s.idServicio= dc.idServicio            
 inner join dbo.GC_Cita c on c.idcita= dc.idcita            
 inner join dbo.GCP_Mascota m on m.idmascota= c.idmascota            
 inner join dbo.GCP_Cliente cl on cl.idCliente= c.idCliente            
 inner join dbo.GCP_Raza r on r.codigoRaza= m.codigoRaza            
 inner join dbo.GCP_Especie e on e.codigoEspecie= r.codigoEspecie            
 inner join dbo.GCP_Tamaño t on t.idTamaño= m.idTamaño               
 inner join GP_HojaServicio hs ON hs.IdDetalleProgramacion= dp.idDetalleProgramacion        
 left join dbo.GG_Parametro ec on ec.Parametro= hs.canil and ec.dominio='005'            
 inner join dbo.GG_Parametro ehs on ehs.Parametro= ISNULL(hs.estado,'001') and ehs.dominio='002'            
 where  (ISNULL(@FechaInicial,'')='' or Convert(varchar(8),cast(dp.fechaInicio as datetime) , 112)>= Convert(varchar(8),CAST(@FechaInicial as datetime) , 112))                                                        
AND (ISNULL(@FechaFinal,'')='' or Convert(varchar(8), cast(dp.fechaInicio as datetime) , 112)<= Convert(varchar(8),CAST(@FechaFinal as datetime) , 112))                                                  
 order by  cast(dp.fechaInicio as datetime) asc            
 END   
  
  go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
             
             
             
             
 ALTER PROC usp_GP_ListarHojaServicioDetalle
@idDetalleCita int =null            
 AS             
 BEGIN              
declare @day varchar(10)            
            
select  @day= convert(varchar(10),MAX(fechainicio),112)            
from GP_DetalleProgramacion            
               
             
 select hs.idHojaServicio,convert(varchar(5),cast(dp.fechaInicio as datetime),108)horaCita,            
 c.NroCita,cl.nombreCliente + ' '+ cl.apellidoCliente Cliente, m.nombreMascota,            
 e.descripcionEspecie especieMascota,GENERO generoMascota,            
 r.nombreRaza razaMascota, t.descripcionTamaño tamanioMascota,            
  m.Foto,            
  isnull(hs.observaciones,'') observaciones,            
  ehs.DscParametro estado,            
  UPPER(s.nombre) Servicio            
             
 from  dbo.GP_DetalleProgramacion dp          
 inner join dbo.GC_DetalleCita dc on dc.iddetallecita= dp.idDetalleCita            
 inner join dbo.GG_Servicio s on s.idServicio= dc.idServicio            
 inner join dbo.GC_Cita c on c.idcita= dc.idcita            
 inner join dbo.GCP_Mascota m on m.idmascota= c.idmascota            
 inner join dbo.GCP_Cliente cl on cl.idCliente= c.idCliente            
 inner join dbo.GCP_Raza r on r.codigoRaza= m.codigoRaza            
 inner join dbo.GCP_Especie e on e.codigoEspecie= r.codigoEspecie            
 inner join dbo.GCP_Tamaño t on t.idTamaño= m.idTamaño      
 inner join GP_HojaServicio hs ON HS.idDetalleProgramacion= dp.idDetalleProgramacion           
 left join dbo.GG_Parametro ec on ec.Parametro= hs.canil and ec.dominio='005'            
 inner join dbo.GG_Parametro ehs on ehs.Parametro= hs.estado and ehs.dominio='002'            
 where (ISNULL(@idDetalleCita,0)=0 or hs.idHojaServicio=@idDetalleCita )            
 order by  CAST(dp.fechaInicio as datetime)            
             
 select m.descripcion material,cast(isnull(mu.Cantidad,0) as int) Cantidad , m.IdMaterial  ,case when m.flagNoMuevekardex='S' then 1 else 0 end idUnidadMedida,      
 cast(case when m.flagNoMuevekardex='S' then 1 else 0 end  as bit)HasBit    ,      
 cast(case when m.flagNoMuevekardex='S' then 0 else 1 end  as bit)HasNumber ,      
 cast(isnull(mu.Cantidad,0)  as bit)CantidadBit      
 from GC_DetalleCita dc            
 inner join GP_CatalogoMaterialServicio cm on cm.idServicio= dc.idServicio            
 inner join GG_Material m on m.IdMaterial= cm.IdMaterial            
 inner join dbo.GP_DetalleProgramacion dp on dc.iddetallecita= dp.idDetalleCita            
 inner join GP_HojaServicio dhs ON dhs.idDetalleProgramacion= dp.idDetalleProgramacion            
 left join dbo.GP_HojaServicioMaterialUsado mu on (mu.idHojaServicio=dhs.idHojaServicio and mu.idMaterial=m.IdMaterial)            
 where ( dhs.idHojaServicio=@idDetalleCita )            
             
 select convert(varchar(10),mu.Fecha,103) + ' ' +convert(varchar(105),mu.Fecha,108) UserComent , isnull(mu.comentario,'') Coment             
 from GC_DetalleCita dc            
 inner join dbo.GP_DetalleProgramacion dp on dc.iddetallecita= dp.idDetalleCita            
 inner join GP_HojaServicio dhs ON (dhs.idDetalleProgramacion= dp.idDetalleProgramacion )            
 inner join  dbo.GP_HojaServicioComentario mu on mu.idHojaServicio=dhs.idHojaServicio            
 where ( dhs.idHojaServicio=@idDetalleCita)            
 order by mu.Fecha desc            
             
             
 select convert(varchar(10),mu.Fecha,103) + ' ' +convert(varchar(105),mu.Fecha,108) Fecha ,             
 isnull(ehs.DscParametro,'') Estado             
 from dbo.GP_DetalleProgramacion dp             
 inner join dbo.GC_DetalleCita dc on dc.iddetallecita= dp.idDetalleCita                  
 inner join GP_HojaServicio dhs ON dhs.idDetalleProgramacion= dp.idDetalleProgramacion            
 inner join GP_HojaServicioTracking mu on mu.idHojaServicio=dhs.idHojaServicio            
 inner join dbo.GG_Parametro ehs on ehs.Parametro= mu.estado and ehs.dominio='002'            
 where ( dhs.idHojaServicio=@idDetalleCita)            
 order by  CAST(mu.Fecha as datetime) desc            
             
 END 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
ALTER  proc usp_GP_ObtenerCitaDetalle  
@idCita int              
as              
begin              
              
  select *            
 ,    
cast(CASE WHEN EstadopG='004' THEN 0 ELSE        
case when Estadop ='003'  or EstadopG='003'          
THEN 0             
else            
case when Empleados =''            
THEN 0             
else            
1            
end end end as bit)Modificar,    
cast(CASE WHEN EstadopG='004' THEN 0 ELSE    case when Estadop ='003'   or EstadopG='003'         
THEN 0             
else            
case when Empleados <>''            
THEN 0            
else            
1            
end end END as bit)Programar    ,    
  
cast(CASE WHEN EstadopG='004' THEN 0 ELSE  
case when Estadop ='003' or EstadopG='003' then 1 else 0 end END  as bit) Anulado         
from (            
SELECT cast(dc.idDetalleCita as varchar(10)) + '|' + cast(s.idServicio as varchar(10)) + '|' + cast(dc.idCita as varchar(10))+ '|' + s.nombre idDetalleCitaServicio, dc.idDetalleCita ,s.nombre Servicio,  s.idServicio,              
isnull(STUFF(( SELECT '/' + isnull(nombres,'') + ' ' + isnull(apellidoPaterno,'')+ ' ' + isnull(apellidoMaterno,'')              
              
    from dbo.GP_EmpleadoDetalleProgramacion edp              
inner join dbo.GG_Empleado e1 on e1.idEmpleado= edp.idEmpleado              
where edp.idDetalleProgramacion=dp.idDetalleProgramacion              
    FOR XML PATH('')              
    ), 1, 1, ''),'') Empleados,              
DP.idSectorTrabajo idSector   ,            
dp.Estado Estadop    ,  
      
  CASE WHEN c.estado='004' then '004' ELSE
CASE  WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA ) then '001'        
ELSE   
CASE  WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA and  ISNULL(DP.Estado,'001') <>'003' ) then '003'        
ELSE        
CASE WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA and ISNULL(DP.Estado,'001') <>'001' ) then '001'         
ELSE        
CASE WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA and ISNULL(DP.Estado,'001') <>'004' ) then '002'         
ELSE        
'001'        
END END END     END   END 
EstadopG            
                  
from dbo.GC_DetalleCita dc               
inner join dbo.GC_Cita c on c.idcita= dc.idcita              
inner join dbo.GG_Servicio s on s.idServicio= dc.idServicio              
left join dbo.GP_DetalleProgramacion dp on dp.idDetalleCita = dc.idDetalleCita              
where dc.idcita=@idCita              
  )t            
              
              
end   
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
          
ALTER proc usp_GP_ObtenerCitaDetalleCompleto         
@idCita int              
as            
begin            
select *,            
e2.DscParametro Estado            
from (            
select c.idcita,NroCita,                     
 cl.CodigoCliente CodCliente, cl.nombreCliente + ' ' + cl.apellidoCliente  Cliente,            
m.nombreMascota,            
me.descripcionEspecie,            
r.nombreRaza,            
descripcionTamaño Tamanio,            
s.DscParametro Sexo ,            
cast(DATEDIFF(YY,m.fechaNacimiento,GETDATE()) as varchar(10))   +             
case when DATEDIFF(YY,m.fechaNacimiento,GETDATE())  =1 then ' año' else ' años' end Edad,            

CASE  WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA ) then '001'      
ELSE 
CASE  WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA  and  ISNULL(DP.Estado,'001') <>'003' ) then '005'          
ELSE     
CASE WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA and ISNULL(DP.Estado,'001') <>'004' ) then '004'       
ELSE      
'001'      
END END    END     EstadoP       ,      
c.Observaciones     
from dbo.GC_Cita c            
inner join dbo.GCP_Mascota m on c.idMascota= m.idMascota            
inner join dbo.GCP_Cliente cl on cl.idCliente= m.idCliente            
inner join dbo.GG_Parametro e on e.Parametro= c.Estado and e.Dominio='003'          
left join dbo.GCP_Raza r on r.codigoRaza= m.codigoRaza                  
left join dbo.GCP_Especie me on r.CodigoEspecie= me.CodigoEspecie          
left join dbo.GCP_Tamaño mr on m.idTamaño= mr.idTamaño            
left join dbo.GG_Parametro s on s.Parametro= m.genero and s.Dominio='004'              
where c.idcita=@idCita  )t            
            
INNER JOIN  dbo.GG_Parametro e2 ON (e2.Parametro=  t.EstadoP AND e2.Dominio='003'  )            
            
SELECT cast(dc.idDetalleCita as varchar(10)) + '|' + cast(s.idServicio as varchar(10)) + '|' + cast(dc.idcita as varchar(10)) +'|' + s.nombre idDetalleCitaServicio, dc.idDetalleCita ,s.descripcion Servicio,  s.idServicio,            
(convert(varchar(5),dateadd(hh,ROW_NUMBER() OVER(ORDER BY dc.idDetalleCita ASC)-1,cast(convert(varchar(10),cast(c.fecha as datetime) ,112) + ' ' + c.Hora  as datetime)),108)) HoraInicio,             
 (convert(varchar(5),dateadd(hh,ROW_NUMBER() OVER(ORDER BY dc.idDetalleCita ASC),cast(convert(varchar(10),cast(c.fecha as datetime) ,112) + ' ' + c.Hora  as datetime)),108)) HoraFin,             
isnull(STUFF(( SELECT '/' + isnull(nombres,'') + ' ' + isnull(apellidoPaterno,'')+ ' ' + isnull(apellidoMaterno,'')            
            
    from dbo.GP_EmpleadoDetalleProgramacion edp            
inner join dbo.GG_Empleado e1 on e1.idEmpleado= edp.idEmpleado            
where edp.idDetalleProgramacion=dp.idDetalleProgramacion            
    FOR XML PATH('')            
    ), 1, 1, ''),'') Empleados,            
DP.idSectorTrabajo idSector  ,            
'' MotivoAnulacion,            
e.DscParametro Estado            
                
from dbo.GC_DetalleCita dc             
inner join dbo.GC_Cita c on c.idcita= dc.idcita            
inner join dbo.GG_Servicio s on s.idServicio= dc.idServicio            
left join dbo.GP_DetalleProgramacion dp on dp.idDetalleCita = dc.idDetalleCita            
INNER JOIN  dbo.GG_Parametro e ON (E.Parametro=  DP.Estado AND e.Dominio='009'  )            
where dc.idcita=@idCita          
            
            
select e1.idEmpleado, nombres + ' ' + apellidoPaterno  nombreEmpleado, idServicio            
from dbo.GP_EmpleadoDetalleProgramacion edp            
inner join dbo.GG_Empleado e1 on e1.idEmpleado= edp.idEmpleado    
inner join dbo.GP_DetalleProgramacion dp on dp.idDetalleProgramacion= edp.idDetalleProgramacion            
inner join dbo.GC_DetalleCita ddc on ddc.idDetalleCita= dp.idDetalleCita            
where ddc.idcita=@idCita            
end 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      
ALTER  proc usp_GP_ObtenerCitaDetalleEmpleado
@idDetalleCita int,        
@idServicio int        
as        
begin        
        
        
SELECT dc.idServicio,dc.idDetalleCita,        
isnull(convert(varchar(5),GETDATE(),108) ,(convert(varchar(5),dateadd(hh,ROW_NUMBER() OVER(ORDER BY dc.idDetalleCita ASC)-1,cast(convert(varchar(10),c.fecha ,103) + ' ' + c.Hora  as datetime)),108))) HoraInicio,        
isnull(dp.idSectorTrabajo,0) idSector         
into #temp        
from dbo.GC_DetalleCita dc         
inner join dbo.GC_Cita c on c.idcita= dc.idcita        
inner join dbo.GG_Servicio s on s.idServicio= dc.idServicio        
left join dbo.GP_DetalleProgramacion dp on dp.idDetalleCita = dc.idDetalleCita        
where dc.idDetalleCita=@idDetalleCita  and dc.idServicio= @idServicio      
        
        
        
select HoraInicio HoraDetalle,  idSector          
from #temp        
where idDetalleCita=@idDetalleCita  and idServicio=@idServicio        
        
        
select e1.idEmpleado, nombres + ' ' + apellidoPaterno  nombreEmpleado, idServicio        
from dbo.GP_EmpleadoDetalleProgramacion edp        
inner join dbo.GG_Empleado e1 on e1.idEmpleado= edp.idEmpleado        
inner join dbo.GP_DetalleProgramacion dp on dp.idDetalleProgramacion= edp.idDetalleProgramacion        
inner join dbo.GC_DetalleCita ddc on ddc.idDetalleCita= dp.idDetalleCita        
where dp.idDetalleCita=@idDetalleCita        
end 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
  ALTER proc usp_GP_ObtenerMaterial
  @codigo varchar(100)
  as
  begin
  
  select  Descripcion, IdMaterial
  from GG_Material
  where tipoMaterial = @codigo
  
  end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
  ALTER proc usp_GP_ObtenerMaterialxAtencion
  @movimientoID int = null
  as
  begin
  
  
select  dm.IdDetReqMaterial idMovimiento, 
NROReqMaterial  NUMREQ,
m.Descripcion  MATERIAL,
dm.CantSolicitada SOL,
isnull(nullif(dm.CantAtendida,0),dm.CantSolicitada) Cantidad

from dbo.[GP_ReqMaterial] k 
inner join dbo.GG_Parametro e on isnull(k.EstadoReq,'001')= e.parametro and e.dominio='011'  
inner join GP_DetReqMaterial dm on  k.idReqMaterial= dm.idReqMaterial
inner join  dbo.GG_Material m on dm.idMaterial= m.idMaterial
where k.idReqMaterial=@movimientoID   
and e.parametro='005'

  end
  

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
    ALTER proc usp_GP_ObtenerMaterialxCodigo
    @id int,
    @almacenID int
  as
  begin
  
  select  m.idMaterial IdMaterial, m.Descripcion material, 
  NombreMarca descripcion,um.NombreUnidadMedida umedida, 0 Cantidad , 
  isnull(pm.precio,0) Precio

  from dbo.GG_Material m 
inner join  dbo.GG_Marca mm on mm.idMarca= m.idMarca
inner join  dbo.GG_UnidadMedida um on um.IdUnidadMedida= m.IdUnidadMedida
left join  dbo.GP_PrecioMaterial pm on (pm.IdMaterial= m.IdMaterial and pm.idsede=@almacenID)

  where m.idMaterial=@id
  
  end
  

go

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER proc usp_GP_InsertarCanil
@idCanil Int,
@tamanio VarChar(10),
@especie VarChar(10),
@estado VarChar(10),
@observaciones VarChar(8000)
as
begin
	if (@idCanil=0)
	begin
		declare @codigo varchar(100)
		declare @nombre varchar(100)
		
		declare @id int
		declare @id2 int
		
		select @id= max(idCanil)
		from GP_Canil
		where substring(CodigoCanil,2,4)= year(getdate())
		
		select @id2= max(idCanil)
		from GP_Canil

		if @id is null
		set @codigo= 'C' + cast(year(getdate()) as varchar(4))+'001'
		else
		select @codigo= 'C' + cast(year(getdate()) as varchar(4))+ replicate('0',4- len( (cast(substring(CodigoCanil,6,4) as int)  + 1))) +  cast((cast(substring(CodigoCanil,6,4) as int)  + 1) as varchar(4))
		from  GP_Canil
		where IdCanil =@id


		if @id2 is null
		set @nombre= 'CANIL 1'
		else
		select @nombre= 'CANIL ' +CAST( (CAST( REPLACE(nombreCanil,'CANIL ','') AS INT)+1) AS VARCHAR(10))
		from  GP_Canil
		where IdCanil =@id2
		
		insert into GP_Canil (codigoCanil, nombreCanil, estado, observacion, idtamaño,codigoEspecie,FechaRegistro)
		values(@codigo,@nombre,@estado,@observaciones,@tamanio,@especie,getdate())
	end
	else
	begin
		update GP_Canil
		set  estado=@estado, observacion=@observaciones, idtamaño=@tamanio,codigoEspecie=@especie
		where idCanil = @idCanil
	end
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER proc usp_GP_InsertarSector
@idSector Int,
@servicio VarChar(10),
@estado VarChar(10),
@observaciones VarChar(8000)
as
begin
if (@idSector=0)
	begin
	
		declare @codigo varchar(100)
		declare @nombre varchar(100)
		
		declare @id int
		declare @id2 int
		
		select @id= max(idSectorTrabajo)
		from GP_SectorTrabajo
		where substring(CodigoSectorTrabajo,2,4)= year(getdate())
		
		select @id2= max(idSectorTrabajo)
		from GP_SectorTrabajo

		if @id is null
		set @codigo= 'S' + cast(year(getdate()) as varchar(4))+'001'
		else
		select @codigo= 'S' + cast(year(getdate()) as varchar(4))+ replicate('0',4- len( (cast(substring(CodigoSectorTrabajo,6,4) as int)  + 1))) +  cast((cast(substring(CodigoSectorTrabajo,6,4) as int)  + 1) as varchar(4))
		from  GP_SectorTrabajo
		where idSectorTrabajo =@id


		if @id2 is null
		set @nombre= 'Sector 1'
		else
		select @nombre= 'Sector ' +CAST( (CAST( REPLACE(nombreSectorTrabajo,'Sector ','') AS INT)+1) AS VARCHAR(10))
		from  GP_SectorTrabajo
		where idSectorTrabajo =@id2
		
		
		

		insert into GP_SectorTrabajo (CodigoSectorTrabajo, NombreSectorTrabajo, estado, observacion, FechaRegistro)
		values(@codigo,@nombre,@estado,@observaciones,getdate())
		set @idSector=@@identity
		
		insert into dbo.GP_ServicioSectorTrabajo values(@servicio,@idSector)
		
	end
	else
	begin
		update GP_SectorTrabajo
		set  estado=@estado, observacion=@observaciones
		where idSectorTrabajo = @idSector
		
		delete from GP_ServicioSectorTrabajo where idSectorTrabajo=@idSector
		insert into dbo.GP_ServicioSectorTrabajo values(@servicio,@idSector)
	end
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER proc usp_GP_InsertarHojaServicio      
@idDetalleCita int,                  
@dtMaterial dbo.dtMateriales readOnly,                  
@Comentarios varchar(100)                  
as                  
begin                  
                  
declare @estado varchar(100)                  
                  
if exists(select * from GP_HojaServicio where Estado='001' and idHojaServicio=@idDetalleCita)                  
begin                  
set @estado='002'                  
end                  
else                  
begin                  
set @estado='003'                  
end                  
 
  IF(ISNULL(@Comentarios,'')!='')                
  BEGIN                
  insert into GP_HojaServicioComentario values(@idDetalleCita,1,getdate(),@Comentarios)                  
  END                
                  
UPDATE GP_HojaServicio SET Estado=@estado                  
WHERE idHojaServicio=@idDetalleCita                  
                  
delete from GP_HojaServicioMaterialUsado where idHojaServicio= @idDetalleCita                  
                  
insert into GP_HojaServicioMaterialUsado                  
select @idDetalleCita, MaterialID, Cantidad                  
from @dtMaterial               
              
declare @Material as dbo.listMateriales            
insert into   @material              
select MaterialID,0, Cantidad                
from @dtMaterial              
              
DECLARE @DATE VARCHAR(10)                     
              
declare @idsede int     
declare @idCITA int      
declare @id int   
declare @idSectorTrabajo int     

select @idsede = idSede ,@idCITA= C.idcita, @idSectorTrabajo=idSectorTrabajo
from  dbo.GC_Cita c          
inner join dbo.GC_DetalleCita dc on c.idcita= dc.idcita          
inner join dbo.GP_DetalleProgramacion p on p.idDetalleCita= dc.idDetalleCita             
inner join  GP_HojaServicio hs on hs.IdDetalleProgramacion= p.IdDetalleProgramacion          
where idHojaServicio= @idDetalleCita               
set @idsede= isnull(@idsede,1    )    

if @estado='003' 
begin
update dbo.GP_SectorTrabajo
set estado='001'
where idSectorTrabajo=@idSectorTrabajo
end      
 
   
         
SELECT @DATE=CONVERT(VARCHAR(10),GETDATE(),103)       
    
exec usp_GP_ActualizarKardex 0 , @DATE ,'','002',@Material,@idsede          
                  
exec usp_GP_ActualizarStock        
                  
insert into GP_HojaServicioTracking values(@idDetalleCita,null,getdate(), @estado)        
       
	IF NOT EXISTS(SELECT * FROM  dbo.GC_Cita c          
	inner join dbo.GC_DetalleCita dc on c.idcita= dc.idcita          
	inner join dbo.GP_DetalleProgramacion p on p.idDetalleCita= dc.idDetalleCita             
	inner join  GP_HojaServicio hs on hs.IdDetalleProgramacion= p.IdDetalleProgramacion   
	WHERE c.IDCITA=@idCITA AND HS.ESTADO<>'003')   
	begin
		UPDATE GC_Cita
		SET Estado = '004'
		WHERE IDCITA=@idCITA
	end
       
                  
end      

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


ALTER proc usp_GP_ActualizarKardex
@idMovimiento Int = null,
@fechaMov VarChar(10) = null,
@guia VarChar(10) = null,
@tipoMov VarChar(10) = null,
@dtMateriales dbo.listMateriales readOnly,
@idAlmacen Int= null
as
begin

if isnull(@idMovimiento ,0)=0
begin
insert into GP_Kardex values(cast(substring(@fechaMov,7,4) + substring(@fechaMov,4,2)+ substring(@fechaMov,1,2) as datetime), @guia, '',@idAlmacen,@tipoMov)
set @idMovimiento=@@identity
end
else
begin
update GP_Kardex set FechaMovimiento=cast(substring(@fechaMov,7,4) + substring(@fechaMov,4,2)+ substring(@fechaMov,1,2) as datetime),
 NroGuiaRemision=@guia
where idkardex= @idMovimiento
end

delete from GP_DetalleKardex where IdKardex=@idMovimiento

insert into GP_DetalleKardex
select @idMovimiento, MaterialID, Cantidad, PRecio
from @dtMateriales
end


go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                 
ALTER proc usp_GP_InsertarHojaServicio    
@idDetalleCita int,                
@dtMaterial dbo.dtMateriales readOnly,                
@Comentarios varchar(100)                
as                
begin                
                
declare @estado varchar(100)                
                
if exists(select * from GP_HojaServicio where Estado='001' and idHojaServicio=@idDetalleCita)                
begin                
set @estado='002'                
end                
else                
begin                
set @estado='003'                
end                
  IF(ISNULL(@Comentarios,'')!='')              
  BEGIN              
  insert into GP_HojaServicioComentario values(@idDetalleCita,1,getdate(),@Comentarios)                
  END              
                
UPDATE GP_HojaServicio SET Estado=@estado                
WHERE idHojaServicio=@idDetalleCita                
                
delete from GP_HojaServicioMaterialUsado where idHojaServicio= @idDetalleCita                
                
insert into GP_HojaServicioMaterialUsado                
select @idDetalleCita, MaterialID, Cantidad                
from @dtMaterial             
            
declare @Material as dbo.listMateriales          
insert into   @material            
select MaterialID,0, Cantidad              
from @dtMaterial            
            
DECLARE @DATE VARCHAR(10)                   
            
    declare @idsede int        
            
    select @idsede = idSede        
    from  dbo.GC_Cita c        
    inner join dbo.GC_DetalleCita dc on c.idcita= dc.idcita        
    inner join dbo.GP_DetalleProgramacion p on p.idDetalleCita= dc.idDetalleCita           
    inner join  GP_HojaServicio hs on hs.IdDetalleProgramacion= p.IdDetalleProgramacion        
     where idHojaServicio= @idDetalleCita             
     set @idsede= isnull(@idsede,1    )        
       
SELECT @DATE=CONVERT(VARCHAR(10),GETDATE(),103)     
  
exec usp_GP_ActualizarKardex 0 , @DATE ,'','002',@Material,@idsede        
                
exec usp_GP_ActualizarStock      
                
insert into GP_HojaServicioTracking values(@idDetalleCita,null,getdate(), @estado)                
                
end    
go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER PROC usp_GP_ListarKardexMovimiento
@almacenID INT = null,
@fechaIni VARCHAR(10) = null,
@fechaFin VARCHAR(10) = null
as
begin

select  k.IDKARDEX idMovimiento,
 dscParametro TIPOMOVIMIENTO,
convert(varchar(10),FechaMovimiento,103)FECHAMOV,
NroGuiaRemision NROGUIA,
sum(Cantidad) CANTTOTAL,
nombreAlmacen ALMACEN,
cast(1 as bit) Modificar,
cast(1 as bit) Anular
from dbo.GP_Kardex k
inner join dbo.GP_DetalleKardex kd on k.idkardex= kd.idkardex
inner join dbo.GP_Almacen a on a.idalmacen= k.idalmacen
inner join dbo.GG_Parametro m on isnull(k.tipoMovimiento,'001')= m.parametro and m.dominio='010'
where (isnull(@almacenID,0)=0 or a.idAlmacen=@almacenID)
AND (ISNULL(@fechaIni,'')='' or Convert(varchar(8),FechaMovimiento , 112)>= Convert(varchar(8),CAST(@fechaIni as datetime) , 112))    
AND (ISNULL(@fechaFin,'')='' or Convert(varchar(8),FechaMovimiento , 112)<= Convert(varchar(8),CAST(@fechaFin as datetime) , 112))                                                  
group by k.IDKARDEX ,
 dscParametro ,
convert(varchar(10),FechaMovimiento,103),
NroGuiaRemision ,
nombreAlmacen 

end


go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  

 ALTER PROCEDURE usp_GP_ObtenerGrafica1
 (  
 @id    VARCHAR(20)  = null
 )  
 AS  
 BEGIN  
  
  declare @dias as table(id int, descripcion varchar(100))
  insert into @dias values(1,'Lunes')
  insert into @dias values(2,'Martes')
  insert into @dias values(3,'Miércoles')
  insert into @dias values(4,'Jueves')
  insert into @dias values(5,'Viernes')
  insert into @dias values(6,'Sábado')
  insert into @dias values(7,'Domingo')
  
 SELECT Dia, [1] , [2] , [3] , [4]  
 FROM   
 (  
 SELECT   
id,
d.descripcion AS Dia,  
 s.nombre AS Servicio,  
 dc.idServicio  
 FROM @dias d
left join dbo.GP_DetalleProgramacion dp  on datepart(dw,cast(dp.fechaInicio as datetime))-1= d.id
left join GC_DetalleCita dc on dp.idDetalleCita= dc.idDetalleCita  
 left JOIN GG_Servicio s ON (dc.idServicio=s.idServicio and (isnull(@id,0)=0 or dc.idservicio=@id) )   

 
 ) p  
 PIVOT 
 (  
 COUNT (Servicio)  
 FOR idServicio IN  
 ( [1], [2], [3], [4])   
 ) AS pvtW order by id;  
  
  
 SELECT DISTINCT  
 s.nombre AS Servicio,  
 dc.idServicio  
 FROM GC_DetalleCita dc INNER JOIN GG_Servicio s ON(dc.idServicio=s.idServicio)  
 where (isnull(@id,0)=0 or dc.idservicio=@id)
  
  
 END 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER proc usp_GP_ListarParametroCombo
@codigo varchar(10)
as  
begin  
select Parametro ID, DscParametro DESCR  
from dbo.GG_Parametro  
where dominio=@codigo 
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER proc usp_GP_ListarParametroComboGEN
@tipo varchar(100)
as
begin

if @tipo='Recurso'
begin
select 1 ID, 'Canil' DESCR
UNION ALL

select 2 ID, 'Sector' DESCR
end

if @tipo='Estado'
begin
select PARAMETRO ID, DSCpARAMETRO DESCR
from dbo.GG_PARAMETRO
WHERE Dominio='016' and parametro<>'005'
end

if @tipo='TamanioCanil'
begin
select idTamaño ID, descripcionTamaño DESCR
from dbo.GCP_Tamaño
end

if @tipo='EspecieCanil'
begin
select CodigoEspecie ID, DescripcionEspecie DESCR
from dbo.GCP_Especie
end
if @tipo='ServicioSector'
begin

select idServicio ID, nombre DESCR
from dbo.GG_Servicio
where idarea=1
end
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
ALTER proc usp_GP_BuscarProgramacionCita          
@FechaInicial varchar(10) = null,          
@FechaFinal varchar(10) = null,          
@CodigoCita varchar(100) = null,          
@CodigoCliente varchar(100) = null,          
@Cliente varchar(200) = null,          
@CodigoMascota varchar(100) = null,          
@Mascota varchar(200) = null,          
@codigoEstado varchar(200) = null,          
@tipo int = null          
as          
begin          
          
        
          
select *          
from (          
select * ,        
E.DscParametro EstadoCita        
from (          
select c.idcita,NroCita,           
isnull(STUFF(( SELECT '/' + isnull(descripcion,'')          
    from dbo.GC_DetalleCita dc           
inner join dbo.GG_Servicio s on s.idServicio= dc.idServicio          
where idcita=c.idcita          
    FOR XML PATH('')          
    ), 1, 1, ''),'') DescripcionCita,          
  CASE WHEN c.estado='004' then '004' ELSE
CASE  WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA ) then '001'        
ELSE       
CASE WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA and ISNULL(DP.Estado,'001') <>'003' ) then '005'         
ELSE   
CASE  WHEN NOT EXISTS(SELECT * FROM GC_DetalleCita DC LEFT JOIN dbo.GP_DetalleProgramacion  DP ON DC.idDetalleCita = DP.idDetalleCita WHERE idcita=c.IDCITA  and  (ISNULL(DP.Estado,'001') <>'003' and ISNULL(DP.Estado,'001') <>'002') ) then '002'            
ELSE        
'001'        
END END    END END       
Estadop,         
c.Observaciones ObservacionCliente, m.CodigoMascota, m.nombreMascota, cl.nombreCliente + ' ' + cl.apellidoCliente  Cliente,          
          
convert(varchar(10),cast(c.Fecha as datetime),103) fechaCita,          
c.HORA horaCita,  
e.descripcionEspecie AS especieMascota,  
GENERO AS generoMascota,  
r.nombreRaza AS razaMascota,  
t.descripcionTamaño AS tamanioMascota     
from dbo.GC_Cita c          
inner join dbo.GC_DetalleCita dc on dc.idcita= c.idcita         
inner join dbo.GCP_Mascota m on c.idMascota= m.idMascota    
inner join dbo.GCP_Raza r on r.codigoRaza= m.codigoRaza  
inner join dbo.GCP_Especie e on e.codigoEspecie= r.codigoEspecie  
inner join dbo.GCP_Tamaño t on t.idTamaño= m.idTamaño        
inner join dbo.GCP_Cliente cl on cl.idCliente= m.idCliente                 
inner join dbo.GG_Servicio s on s.idServicio= dc.idServicio            
left join dbo.GP_DetalleProgramacion dp on dp.idDetalleCita= dc.idDetalleCita            
        
where  s.idArea=1        
AND (ISNULL(@FechaInicial,'')='' or Convert(varchar(8),c.Fecha , 112)>= Convert(varchar(8),CAST(@FechaInicial as datetime) , 112))                                                
AND (ISNULL(@FechaFinal,'')='' or Convert(varchar(8), c.Fecha , 112)<= Convert(varchar(8),CAST(@FechaFinal as datetime) , 112))                                          
AND (ISNULL(@CodigoCita,'')='' or c.NroCita = @CodigoCita)                                                
AND (ISNULL(@CodigoCliente,'')='' or cl.CodigoCliente  like '%' + @CodigoCliente +'%')                                                
AND (ISNULL(@Cliente,'')=''or cl.nombreCliente + ' ' + cl.apellidoCliente like '%' + @CodigoCliente +'%')                                                  
AND (ISNULL(@CodigoMascota,'')='' or m.CodigoMascota  like '%' + @CodigoCliente +'%')                                               
AND (ISNULL(@Mascota,'')=''or m.nombreMascota  like '%' + @CodigoCliente +'%')           
GROUP BY c.idcita,NroCita,   c.Observaciones , m.CodigoMascota, m.nombreMascota, cl.nombreCliente + ' ' + cl.apellidoCliente  ,C.FECHA   ,c.HORA  ,e.descripcionEspecie,  
GENERO,  
r.nombreRaza,  
t.descripcionTamaño ,c.estado                         
)t        
INNER JOIN  dbo.GG_Parametro e ON (E.Parametro=  Estadop AND e.Dominio='003'  )        
WHERE        
                                                
 (ISNULL(nullif(@codigoEstado,'0'),'')=''or ISNULL(Estadop,'001')  =  @codigoEstado )            
) t         
where DescripcionCita <>''          
          
          
end   
  
  GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
ALTER PROC usp_GP_ListarReqMaterial
@almacenID INT = null,  
@fechaIni VARCHAR(10) = null,  
@fechaFin VARCHAR(10) = null  ,
@motivoID VARCHAR(10) = null,  
@tipoID VARCHAR(10) = null,  
@estadoID VARCHAR(10) = null,  
@NumReq VARCHAR(100) = null  
as  
begin  
  
select  idReqMaterial idMovimiento, 
NROReqMaterial  NUMREQ,
t.dscParametro TIPO,  
e.dscParametro ESTADO,  
S.nombreSede SEDE,
cast(case when k.EstadoReq ='001' THEN 1 ELSE 0 END as bit) Modificar,  
cast(case when k.EstadoReq ='001' THEN 1 ELSE 0 END as bit) Anular  ,  
cast(case when k.EstadoReq ='001' THEN 1 ELSE 0 END as bit) Cerrar   ,  
cast(case when k.EstadoReq ='002' THEN 1 ELSE 0 END as bit) Modificar2,  
cast(case when k.EstadoReq ='002' THEN 1 ELSE 0 END as bit) Aprobar  ,  
cast(case when k.EstadoReq ='002' THEN 1 ELSE 0 END as bit) Rechazar ,  
cast(case when k.EstadoReq ='005' THEN 1 ELSE 0 END as bit) Recepcionar 

from dbo.[GP_ReqMaterial] k 
inner join dbo.GG_Parametro t on isnull(k.TipoReq,'001')= t.parametro and t.dominio='013'  
inner join dbo.GG_Parametro e on isnull(k.EstadoReq,'001')= e.parametro and e.dominio='011'  
inner join dbo.GG_Sede S on S.IDSEDE= k.idsede
where (isnull(@almacenID,0)=0 or k.idSede=@almacenID)  
AND (ISNULL(@fechaIni,'')='' or Convert(varchar(8),FechaReq , 112)>= Convert(varchar(8),cast(substring(@fechaIni,7,4) + substring(@fechaIni,4,2)+ substring(@fechaIni,1,2) as datetime) , 112))      
AND (ISNULL(@fechaFin,'')='' or Convert(varchar(8),FechaReq , 112)<= Convert(varchar(8),cast(substring(@fechaFin,7,4) + substring(@fechaFin,4,2)+ substring(@fechaFin,1,2) as datetime), 112))                                                    
AND (isnull(@tipoID,0)=0 or t.parametro=@tipoID)  
AND (isnull(@estadoID,0)=0 or e.parametro=@estadoID) AND (isnull(@NumReq,'')='' or NROReqMaterial LIKE '%' +@NumReq + '%')  

  
end  
  
  

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
    
ALTER proc usp_GP_ListarReqMaterialDisponible
@idMovimiento int  ,  
@almacenID int = null  
as    
begin    
 if (isnull(@idMovimiento,0)=0)  
 begin  
   
     DECLARE @TAB AS TABLE(idMaterial int, material varchar(500), uni varchar(500), smin decimal(16,2), smax decimal(16,2), sactual decimal(16,2), color varchar(300))  
  
insert into @tab  
exec usp_KardexMaterialesgl   @almacenID = @almacenID

   
   
select m.idMaterial IdMaterial, m.Descripcion material,   
isnull(NombreMarca,'') descripcion,  
isnull(um.NombreUnidadMedida,'') umedida,   
isnull(((m.stockMinimo *120/100) -t.sactual),0)  Cantidad,  
isnull(Precio,0)Precio  
from  dbo.GG_Material m  
inner join  dbo.GG_Marca mm on mm.idMarca= m.idMarca  
LEFT JOIN @TAB t ON T.IDmATERIAL= M.IDmATERIAL
left join  dbo.GG_UnidadMedida um on um.IdUnidadMedida= m.IdUnidadMedida  
left join  dbo.GP_PrecioMaterial gp on (gp.idMaterial= m.idMaterial and gp.idSede= @almacenID)  
where t.sactual<= m.StockMinimo  
order by 2    
  
 end  
 else  
 begin  
select m.idMaterial IdMaterial, m.Descripcion material,   
isnull(NombreMarca,'') descripcion,  
isnull(um.NombreUnidadMedida,'') umedida, CantSolicitada Cantidad,  
isnull(Precio,0)Precio  
from [GP_ReqMaterial] rm  
inner join GP_DetReqMaterial dm   on rm.idReqMaterial= dm.idReqMaterial  
inner join  dbo.GG_Material m on dm.idMaterial= m.idMaterial  
left join  dbo.GG_Marca mm on mm.idMarca= m.idMarca  
left join  dbo.GG_UnidadMedida um on um.IdUnidadMedida= m.IdUnidadMedida  
left join  dbo.GP_PrecioMaterial gp on (gp.idMaterial= m.idMaterial and gp.idSede= rm.idSede)  
where rm.idReqMaterial=@idMovimiento     
order by 2    
end  
    
    
    
select   NROReqMaterial NroReq,  
convert(varchar(10),FechaReq,103)FECHAMOV,    
 isnull(TipoReq,'001')  TipoMovimiento ,  
s.nombreSede Sede,  
m.idSede IdAlmacen    
from [GP_ReqMaterial]   m  
left join dbo.GG_Sede s on m.idSede= s.idSede  
where idReqMaterial=@idMovimiento    
    
    
    
end    


go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
  
  
ALTER proc usp_GP_ActualizarRequerimiento
@idMovimiento Int = null,  
@fechaMov VarChar(10) = null,  
@tipoMov VarChar(10) = null, 
@MotivoMov VarChar(10) = null, 
@dtMateriales dbo.listMateriales readOnly,  
@idAlmacen Int= null  
as  
begin  
if isnull(@idMovimiento ,0)=0  
begin  
declare @numReq varchar(10)
declare @numReqi int 
select  @numReqi= count(*)
from [GP_ReqMaterial]
set @numReqi = isnull(@numReqi,0)+1

set @numReq=replicate('0',5-len(@numReqi)) + cast(@numReqi as varchar(10))

insert into [GP_ReqMaterial] 
(NROReqMaterial ,idSede,FechaReq,FechaAcepta,FechaAproba,TipoReq,OrigenReq,EstadoReq,idUsuarioIng,FechaIng)
values(@numReq , @idAlmacen,cast(substring(@fechaMov,7,4) + substring(@fechaMov,4,2)+ substring(@fechaMov,1,2) as datetime),

null,null, @tipoMov,null,'001',1,getdate())  
set @idMovimiento=@@identity  
end  
else  
begin  
update [GP_ReqMaterial] 
set FechaReq=cast(substring(@fechaMov,7,4) + substring(@fechaMov,4,2)+ substring(@fechaMov,1,2) as datetime),  
 TipoReq=@tipoMov  
where idReqMaterial= @idMovimiento  
end  
  
delete from GP_DetReqMaterial where idReqMaterial=@idMovimiento  
  
insert into GP_DetReqMaterial  
select @idMovimiento, MaterialID, Cantidad, isnull(m.Precio ,0) ,'001',null,null,null
from @dtMateriales  dm
left join dbo.GP_PrecioMaterial m on (dm.MaterialID= m.idMaterial and idsede=@idAlmacen)
where nullif(dm.cantidad,0) is not null
end  
  
  

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

  ALTER proc usp_GP_ActualizarRequerimientoAtencion
@dtDetalle dbo.listMateriales readOnly
as
begin

update GP_DetReqMaterial
set CantAtendida = d.Cantidad, EstadoDetReq='005'
from @dtDetalle d
where d.materialID= GP_DetReqMaterial.IdDetReqMaterial

declare @id int

select @id = idreqmaterial from GP_DetReqMaterial where IdDetReqMaterial in (
select materialid from @dtDetalle)

update [GP_ReqMaterial]
set EstadoReq='006'
where idReqMaterial in (@id)

DECLARE @IDK INT
insert into dbo.GP_Kardex (FechaMovimiento,NroGuiaRemision,Observacion,IdAlmacen,TipoMovimiento)
select getdate(),'','',idsede,'001'
FROM [GP_ReqMaterial]
where idReqMaterial in (@id)

SET @IDK= @@IDENTITY

insert into  dbo.GP_DetalleKardex(IdKardex,IdMaterial,Cantidad,Precio)
SELECT @IDK,idMaterial,CantAtendida,PrecioMat
FROM GP_DetReqMaterial
where idReqMaterial in (@id)

exec usp_GP_ActualizarStock

end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
  
  ALTER proc usp_GP_ActualizarRequerimientoTipo  
@idMovimiento int  ,
@tipo varchar(3)
as  
begin  
if(@tipo='A')
begin
	delete GP_DetReqMaterial 

	where idReqMaterial=@idMovimiento  
	update [GP_ReqMaterial] 
	set EstadoReq='008'
	where idReqMaterial=@idMovimiento  
 end

if(@tipo='C')
begin
	update [GP_ReqMaterial] 
	set EstadoReq='002' , fechaAcepta= getdate()
	where idReqMaterial=@idMovimiento 
	
	update GP_DetReqMaterial 
	set EstadoDetReq='002'
	where idReqMaterial=@idMovimiento   
 
 end
 
 
if(@tipo='P')
begin
	update [GP_ReqMaterial] 
	set EstadoReq='003', fechaAproba= getdate()
	where idReqMaterial=@idMovimiento 
	
	update GP_DetReqMaterial 
	set EstadoDetReq='002'
	where idReqMaterial=@idMovimiento   
 
 end
 
 
if(@tipo='R')
begin
	update [GP_ReqMaterial] 
	set EstadoReq='007'
	where idReqMaterial=@idMovimiento 
	
	update GP_DetReqMaterial 
	set EstadoDetReq='006'
	where idReqMaterial=@idMovimiento   
 
 end
end  
  

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER  proc usp_GP_ListarRol
@idServicio int      
as      
begin      
select e.idRol idRol, nombreRol descripcion      
from dbo.GG_Rol e       
inner join dbo.GG_RolServicio rs on rs.idRol= e.idRol    
inner join dbo.GG_Servicio s on (rs.idServicio= s.idServicio and idarea=1)     
where (isnull(@idServicio,0)=0 or rs.idServicio=@idServicio    )  
end 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER  proc usp_GP_ListarSector
@idServicio int  
as  
begin  
select g.idSectorTrabajo idSector, nombreSectorTrabajo descripcion  
from dbo.GP_SectorTrabajo g  
inner join dbo.GP_ServicioSectorTrabajo gsp on gsp.idSectorTrabajo= g.idSectorTrabajo  
where gsp.idServicio=@idServicio  
end 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

  
 ALTER PROC usp_GP_ListarServicio
       
      
 AS      
 BEGIN      
       
 SELECT       
    idServicio,      
 descripcion      
    FROM dbo.GG_Servicio      
      where idarea=1
 END 

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER proc usp_GP_ListarTipoMovimiento
as
begin
select Parametro idcboTipoMov, DscParametro descripcion
from dbo.GG_Parametro
where dominio='010'
end

go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
          
             
ALTER FUNCTION fnc_GP_UTILSplitwWS(                  
 @String nvarchar (MAX),                  
 @Delimiter nvarchar (10)                  
 )                  
returns @ValueTable table ([ID] int identity(1,1),[Value] nvarchar(MAX))                  
begin                  
 declare @NextString nvarchar(MAX)                  
 declare @Pos int                  
 declare @NextPos int                  
 declare @CommaCheck nvarchar(1)                  
                   
 --Initialize                  
 set @NextString = ''                  
 set @CommaCheck = right(@String,1)                   
                   
 --Check for trailing Comma, if not exists, INSERT                  
 --if (@CommaCheck <> @Delimiter )                  
 set @String = @String + @Delimiter                  
                   
 --Get position of first Comma                  
 set @Pos = charindex(@Delimiter,@String)                  
 set @NextPos = 1                  
                   
 --Loop while there is still a comma in the String of levels                  
 while (@pos <>  0)                    
 begin                  
  set @NextString = substring(@String,1,@Pos - 1)                  
      IF(@NextString <> '' )        
    begin                 
  insert into @ValueTable ( [Value]) Values (@NextString)                  
     END            
  set @String = substring(@String,@pos +1,len(@String))                  
                    
  set @NextPos = @Pos                  
  set @pos  = charindex(@Delimiter,@String)                  
 end                  
                   
 return                  
end 

GO

-- usp_GP_ObtenerGrafico4 1

 ALTER PROCEDURE usp_GP_ObtenerGrafico4
 (      
 @id    int =null    
 )      
 AS      
 BEGIN      
      
 SELECT DISTINCT      
 e.nombres + ' ' + e.apellidoPaterno + ' ' +   e.apellidoMaterno EmpleadoNombre, count(edp.idEmpleado)*CT.ValorCargaEmpleado  data  ,  
 'Blue' Color  
 INTO #TMP 
 FROM GP_DetalleProgramacion dp     
 INNER JOIN GP_EmpleadoDetalleProgramacion edp ON(dp.idDetalleProgramacion=edp.idDetalleProgramacion)      
 INNER JOIN GG_Empleado e ON(e.idEmpleado=edp.idEmpleado)     
 INNER JOIN  dbo.GC_DetalleCita C ON C.idDetalleCita= DP.idDetalleCita
 inner join dbo.GG_EmpleadoRol er on er.idempleado=e.idempleado 
 INNER JOIN dbo.GG_RolServicio S ON (S.idRol= ER.idRol AND S.IDSERVICIO=C.IDSERVICIO)   
 INNER JOIN GP_ServicioCargaTrabajo CT ON CT.idServicio= S.IDSERVICIO
 where (isnull(@id,0)=0 or  er.idrol=@id)    
 GROUP BY  e.nombres + ' ' + e.apellidoPaterno + ' ' +   e.apellidoMaterno ,CT.ValorCargaEmpleado     
   
    DECLARE @DATA  DECIMAL(16,2)  
   
  SELECT @DATA= SUM(data) FROM #TMP  
   
  SELECT EmpleadoNombre, CAST((data * 100.0 / @DATA) AS DECIMAL(16,2))Avance  ,case when (data * 100.0 / @DATA)<25 then 'Red' else
   case when  (data * 100.0 / @DATA)<60 then 'gold' else 'green' end   end Color
  FROM #TMP  
    
  DROP TABLE #TMP  
     
end


go

-- usp_GP_ObtenerGrafica2 1

 ALTER PROCEDURE usp_GP_ObtenerGrafica2
 (  
 @id    VARCHAR(20)  =NULL
 )  
 AS  
 BEGIN  
  
 SELECT DISTINCT  
 ISNULL(e.apellidoPaterno,'')+' '+ISNULL(e.apellidoMaterno,'')+', '+ISNULL(e.nombres,'') AS label,  
 COUNT(edp.idEmpleado) *CT.ValorCargaServicio   AS data 
 INTO #TMP 
 FROM GP_DetalleProgramacion dp 
 INNER JOIN GP_EmpleadoDetalleProgramacion edp ON(dp.idDetalleProgramacion=edp.idDetalleProgramacion)  
 INNER JOIN  dbo.GC_DetalleCita C ON C.idDetalleCita= DP.idDetalleCita
 INNER JOIN GG_Empleado e ON(e.idEmpleado=edp.idEmpleado)  
 INNER JOIN dbo.GG_EmpleadoRol eR ON(e.idEmpleado=eR.idEmpleado)  
 INNER JOIN dbo.GG_RolServicio S ON (S.idRol= ER.idRol AND S.IDSERVICIO=C.IDSERVICIO)
 INNER JOIN GP_ServicioCargaTrabajo CT ON CT.idServicio= S.IDSERVICIO
 WHERE (ISNULL(@id,0)=0 OR S.idServicio=@id )
 GROUP BY edp.idEmpleado,e.apellidoPaterno,e.apellidoMaterno,e.nombres ,CT.ValorCargaServicio  
 
 DECLARE @DATA  DECIMAL(16,2)
 
  SELECT @DATA= SUM(data) FROM #TMP
 
  SELECT label, CAST((data * 100.0 / @DATA) AS DECIMAL(16,2))data
  FROM #TMP
  
  DROP TABLE #TMP
 END 

go



  
 ALTER PROCEDURE usp_GP_ObtenerGrafica3
 (  
 @id    VARCHAR(20)  =null
 )  
 AS  
 BEGIN  
  
 IF @id =0  
  SET @id=NULL  
  
  select case when value<=2 then '#F0203D' else case when value<=6 then '#E9982F' else '#50AA0A' end  end As color,* 
  
  from (
 SELECT DISTINCT    
 s.NombreSede+'   Cant:'+CONVERT(VARCHAR,COUNT(dc.idDetalleCita))+'   Puntaje' AS label,  
 case when cast(COUNT(dc.idDetalleCita)/5  as int)>10 then 10 else cast(COUNT(dc.idDetalleCita)/5  as int) end AS value  
 FROM   
 GG_Sede s   
 INNER  JOIN GC_Cita c ON(C.idSede=s.idSede)  
 INNER  JOIN GC_DetalleCita DC ON(c.idCita=dc.idCita)  
   
 WHERE dc.idServicio=ISNULL(@id,dc.idServicio)  
 GROUP BY s.NombreSede,Color  )t
  
 END  

go
          
ALTER proc usp_GP_ObtenerResumen
as          
begin          
          
        
 select   
 count(DC.idServicio) ServicioHoy,  
 sum(case when dp.estado IN ( '004','001') THEN 1 ELSE 0 END) ServicioPendientes,  
 CAST( CAST((sum(case when dp.estado IN ( '004','001') THEN 0 ELSE 1 END) * 100.0 / count(DC.idServicio))AS DECIMAL(16,2)) AS VARCHAR(10)) +'%'  ServicioFinalizados,  
 (Select count(*) from dbo.GG_Empleado)TotalEmpleados  
   
            
from dbo.GC_Cita c          
inner join dbo.GC_DetalleCita dc on dc.idcita= c.idcita         
inner join dbo.GCP_Mascota m on c.idMascota= m.idMascota    
inner join dbo.GCP_Raza r on r.codigoRaza= m.codigoRaza  
inner join dbo.GCP_Especie e on e.codigoEspecie= r.codigoEspecie  
inner join dbo.GCP_Tamaño t on t.idTamaño= m.idTamaño        
inner join dbo.GCP_Cliente cl on cl.idCliente= m.idCliente                 
inner join dbo.GG_Servicio s on s.idServicio= dc.idServicio            
left join dbo.GP_DetalleProgramacion dp on dp.idDetalleCita= dc.idDetalleCita            
        
where  s.idArea=1        
                              
  
          
end 

go