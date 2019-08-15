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
    /// <summary>A consecutive context.</summary>
    [Dependency(DependencyScope.Transient)]
    public class ActivityContext : IActivityContext
    {
        /// <summary>Context for the mandiola database.</summary>
        private readonly MandiolaDbContext _mandiolaDbContext;

        /// <summary>The mapper.</summary>
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.DB.Concrete.ConsecutiveContext class.</summary>
        /// <param name="mapper">The mapper.</param>
        public ActivityContext(IMapper mapper)
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
            var aux = _mapper.Map<ACTIVIDAD>(entity);

            var pName = new SqlParameter
            {
                ParameterName = "Nombre",
                Value = aux.NOMBRE
            };
            var pDescription = new SqlParameter
            {
                ParameterName = "Descripcion",
                Value = aux.DESCRIPCION
            };

            var pImage = new SqlParameter
            {
                ParameterName = "Img",
                Value = aux.IMG
            };

            var pLogUserId = new SqlParameter
            {
                ParameterName = "LOG_UserID",
                Value = 1
            };

            var pLogDate = new SqlParameter
            {
                ParameterName = "LOG_fecha",
                Value = DateTime.Now
            };

            var pLogType = new SqlParameter
            {
                ParameterName = "LOG_Tipo",
                Value = 1
            };
            var pLogDesc = new SqlParameter
            {
                ParameterName = "LOG_Desc",
                Value = "Testing"
            };

            var pLogDetail = new SqlParameter
            {
                ParameterName = "LOG_Detalle",
                Value = "Testing"
            };

            aux = _mandiolaDbContext.Database.SqlQuery<ACTIVIDAD>("exec InsertActividad @Nombre, @Descripcion, @Img, @LOG_UserID, @LOG_fecha, @LOG_Tipo, @LOG_Desc, @LOG_Detalle", pName, pDescription, pImage, pLogUserId, pLogDate, pLogType, pLogDesc, pLogDetail).FirstOrDefault();
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
                var aux = _mapper.Map<ACTIVIDAD>(entity);
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
            => _mapper.Map<List<T>>(_mandiolaDbContext.ACTIVIDADs.ToList());

        /// <summary>Gets by identifier.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        public T GetById<T>(int id)
            => _mapper.Map<T>(_mandiolaDbContext.ACTIVIDADs.FirstOrDefault(x => x.ID_ACTIVIDAD == id.ToString()));

        /// <summary>Updates the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Update<T>(T entity)
        {
            var aux = _mapper.Map<ACTIVIDAD>(entity);
            _mandiolaDbContext.ACTIVIDADs.Attach(aux);
            _mandiolaDbContext.Entry(aux).State = EntityState.Modified;
            _mandiolaDbContext.SaveChanges();
            return _mapper.Map<T>(aux);
        }
    }
}