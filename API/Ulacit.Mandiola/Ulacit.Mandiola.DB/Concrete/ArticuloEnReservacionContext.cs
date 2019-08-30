using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using AutoMapper;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.DB.MandiolaDb;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.DB.Concrete
{
    [Dependency(DependencyScope.Transient)]
    public class ArticuloEnReservacionContext : IArticuloEnReservacionContext
    {
        /// <summary>Context for the mandiola database.</summary>
        private readonly MandiolaDbContext _mandiolaDbContext;

        /// <summary>The mapper.</summary>
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.DB.Concrete.ConsecutiveContext class.</summary>
        /// <param name="mapper">The mapper.</param>
        public ArticuloEnReservacionContext(IMapper mapper)
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
            var aux = _mapper.Map<ArticuloEnReservacion>(entity);
            _mandiolaDbContext.ArticuloEnReservacion.Add(aux);
            _mandiolaDbContext.SaveChanges();
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
                var aux = _mapper.Map<ArticuloEnReservacion>(entity);
                _mandiolaDbContext.Entry(aux).State = EntityState.Deleted;
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
            => _mapper.Map<List<T>>(_mandiolaDbContext.ArticuloEnReservacion.ToList());

        /// <summary>Gets by identifier.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        public T GetById<T>(int id)
             => _mapper.Map<T>(_mandiolaDbContext.ArticuloEnReservacion.FirstOrDefault(x => x.ID_ArtEnReserv == id));

        /// <summary>Updates the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Update<T>(T entity)
        {
            var aux = _mapper.Map<ArticuloEnReservacion>(entity);
            _mandiolaDbContext.ArticuloEnReservacion.Attach(aux);
            _mandiolaDbContext.Entry(aux).State = EntityState.Modified;
            _mandiolaDbContext.SaveChanges();
            return _mapper.Map<T>(aux);
        }
        /// <summary>Returns the rooms asociated to a reservation.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A List<T></T>.</returns>
        public List<T> GetJoinArtcsEnResv<T>(string ID_reservacion)
        {
            var pID_Reservacion = new SqlParameter
            {
                ParameterName = "@ID_Reservacion",
                Value = ID_reservacion
            };

            return _mapper.Map<List<T>>(_mandiolaDbContext.Database.SqlQuery<ArticuloEnReservacion>("exec JoinReservacionArticulos @ID_Reservacion", pID_Reservacion).ToList());
        }
    }
}
