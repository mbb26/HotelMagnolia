using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.DB.MandiolaDb;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;
using Ulacit.Mandiola.DB.Util;
using System.Data.SqlClient;

namespace Ulacit.Mandiola.DB.Concrete
{
    /// <summary>A consecutive context.</summary>
    [Dependency(DependencyScope.Transient)]
    public class ReservationContext : IReservationContext
    {
        /// <summary>Context for the mandiola database.</summary>
        private readonly MandiolaDbContext _mandiolaDbContext;

        /// <summary>The mapper.</summary>
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.DB.Concrete.ConsecutiveContext class.</summary>
        /// <param name="mapper">The mapper.</param>
        public ReservationContext(IMapper mapper)
        {
            _mapper = mapper;
            _mandiolaDbContext = new MandiolaDbContext();
        }

        /// <summary>Creates a new T.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Create<T>(T entity)
        {
            //NEED HOW TO GET USER
            var aux = _mapper.Map<RESERVACION>(entity);
            //_mandiolaDbContext.RESERVACIONs.Add(aux);
            //_mandiolaDbContext.SaveChanges();
            //return _mapper.Map<T>(aux);

            aux = Cypher.EncryptObject(aux) as RESERVACION;



            var pIDCliente = new SqlParameter
            {
                ParameterName = "ID_Cliente",
                Value = aux.ID_CLIENTE
            };

            var pFechaEntrada = new SqlParameter
            {
                ParameterName = "Fecha_Entrada",
                Value = aux.FECHA_ENTRADA
            };

            var pFechaSalida = new SqlParameter
            {
                ParameterName = "Fecha_Salida",
                Value = aux.FECHA_SALIDA
            };

            var pTipoHabitacion = new SqlParameter
            {
                ParameterName = "Tipo_Habitacion",
                Value = aux.TIPO_HABITACION
            };

            var pEstado = new SqlParameter
            {
                ParameterName = "Estado",
                Value = aux.ESTADO_RESERVACION
            };

            aux = _mandiolaDbContext.Database.SqlQuery<RESERVACION>("exec InsertReservacionAPI @ID_Cliente,@Fecha_Entrada,@Fecha_Salida,@Tipo_Habitacion,@Estado", pIDCliente, pFechaEntrada, pFechaSalida, pTipoHabitacion, pEstado).FirstOrDefault();
            aux = Cypher.DecryptObject(aux) as RESERVACION;

            return _mapper.Map<T>(aux);
        }

        /// <summary>Deletes the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public bool Delete<T>(T entity)
        {
            try
            {
                var aux = _mapper.Map<RESERVACION>(entity);
                var pReservacionID = new SqlParameter
                {
                    ParameterName = "ID_RESERVACION",
                    Value = aux.ID_RESERVACION
                };

                aux = _mandiolaDbContext.Database.SqlQuery<RESERVACION>("exec DeleteReservacionAPI @ID_Reservacion",pReservacionID).FirstOrDefault();
                //_mandiolaDbContext.Entry(aux).State = EntityState.Deleted;
                _mandiolaDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>Gets all.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <returns>all.</returns>
        public List<T> GetAll<T>()
            => _mapper.Map<List<T>>(_mandiolaDbContext.RESERVACIONs.ToList());

        /// <summary>Gets by identifier.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        public T GetById<T>(int id)
            => _mapper.Map<T>(_mandiolaDbContext.RESERVACIONs.FirstOrDefault(x => x.ID_RESERVACION == id.ToString()));

        /// <summary>Updates the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Update<T>(T entity)
        {
            var aux = _mapper.Map<RESERVACION>(entity);
            _mandiolaDbContext.RESERVACIONs.Attach(aux);
            _mandiolaDbContext.Entry(aux).State = EntityState.Modified;
            _mandiolaDbContext.SaveChanges();
            return _mapper.Map<T>(aux);
        }
    }
}