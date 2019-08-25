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
using Ulacit.Mandiola.DB.Util;
using System.Web.Http.Cors;

namespace Ulacit.Mandiola.DB.Concrete
{
    /// <summary>A consecutive context.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Dependency(DependencyScope.Transient)]
    public class UserContext : IUserContext
    {
        /// <summary>Context for the mandiola database.</summary>
        private readonly MandiolaDbContext _mandiolaDbContext;

        /// <summary>The mapper.</summary>
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.DB.Concrete.ConsecutiveContext class.</summary>
        /// <param name="mapper">The mapper.</param>
        public UserContext(IMapper mapper)
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
            var aux = _mapper.Map<USUARIO>(entity);
            aux = Cypher.EncryptObject(aux) as USUARIO;

            var pNombre = new SqlParameter
            {
                ParameterName = "nombre",
                Value = aux.NOMBRE
            };

            var pApellido1 = new SqlParameter
            {
                ParameterName = "apellido1",
                Value = aux.APELLIDO1
            };
            var pApellido2 = new SqlParameter
            {
                ParameterName = "apellido2",
                Value = aux.APELLIDO2
            };

            var pCorreo = new SqlParameter
            {
                ParameterName = "correo",
                Value = aux.CORREO
            };

            var pTelefono = new SqlParameter
            {
                ParameterName = "telefono",
                Value = aux.TELEFONO
            };

            var pPassword = new SqlParameter
            {
                ParameterName = "password",
                Value = aux.PASSWORD
            };

            var pUserName = new SqlParameter
            {
                ParameterName = "User_name",
                Value = aux.USER_NAME
            };

            var pIdRol = new SqlParameter
            {
                ParameterName = "Id_rol",
                Value = aux.ID_ROL
            };

            aux = _mandiolaDbContext.Database.SqlQuery<USUARIO>("exec InsertUsuarios @nombre, @apellido1, @apellido2, @correo, @telefono, @password, @User_name, @Id_rol", pNombre, pApellido1, pApellido2, pCorreo, pTelefono, pPassword, pUserName, pIdRol).FirstOrDefault();
            aux = Cypher.DecryptObject(aux) as USUARIO;

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
                var aux = _mapper.Map<USUARIO>(entity);
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
            => _mapper.Map<List<T>>(_mandiolaDbContext.USUARIOs.ToList());

        /// <summary>Gets by identifier.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        public T GetById<T>(int id)
            => _mapper.Map<T>(_mandiolaDbContext.USUARIOs.FirstOrDefault(x => x.ID_USUARIO == id.ToString()));

        /// <summary>Updates the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Update<T>(T entity)
        {
            var aux = _mapper.Map<USUARIO>(entity);
            _mandiolaDbContext.USUARIOs.Attach(aux);
            _mandiolaDbContext.Entry(aux).State = EntityState.Modified;
            _mandiolaDbContext.SaveChanges();
            return _mapper.Map<T>(aux);
        }

        public T Login<T>(T entity)
        {
            var aux = _mapper.Map<USUARIO>(entity);
            aux = Cypher.EncryptObject(aux) as USUARIO;

            var pPassword = new SqlParameter
            {
                ParameterName = "@Password",
                Value = aux.PASSWORD
            };

            var pUserName = new SqlParameter
            {
                ParameterName = "@Username",
                Value = aux.USER_NAME
            };
            string userId = _mandiolaDbContext.Database.SqlQuery<string>("exec ValidateUser @Username, @Password ", pUserName, pPassword).FirstOrDefault();
            aux = _mapper.Map<USUARIO>(_mandiolaDbContext.USUARIOs.FirstOrDefault(x => x.ID_USUARIO == userId));
            if (aux != null)
            {
                aux.PASSWORD = null;
                aux = Cypher.DecryptObject(aux) as USUARIO;
            }
            return _mapper.Map<T>(aux);
        }

        public bool IsUsernameAvailable(string username)
        {
            string usernameE = Cypher.Encrypt(username);

            var pUserName = new SqlParameter
            {
                ParameterName = "@Username",
                Value = usernameE
            };

            string available = _mandiolaDbContext.Database.SqlQuery<string>("exec UsernameAvailable @Username", pUserName).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine("AVailable SR Result: " + available);

            return available.Equals("true");
        }
    }
}