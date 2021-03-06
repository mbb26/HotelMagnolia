﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;
using Ulacit.Mandiola.DB.EasyPayDb;

namespace Ulacit.Mandiola.DB.Concrete
{
    /// <summary>A UserEasyPayContext context.</summary>
    [Dependency(DependencyScope.Transient)]
    public class UserEasyPayContext : IUserEasyPayContext
    {
        /// <summary>Context for the EasyPayDbContext database.</summary>
        private readonly EasyPayDbContext _easyPayDbContext;

        /// <summary>The mapper.</summary>
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.DB.Concrete.UserEasyPayContext class.</summary>
        /// <param name="mapper">The mapper.</param>
        public UserEasyPayContext(IMapper mapper)
        {
            _mapper = mapper;
            _easyPayDbContext = new EasyPayDbContext();
        }

        /// <summary>Creates a new T.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Create<T>(T entity)
        {
            var aux = _mapper.Map<User>(entity);
            _easyPayDbContext.Users.Add(aux);
            _easyPayDbContext.SaveChanges();
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
                var aux = _mapper.Map<User>(entity);
                _easyPayDbContext.Entry(aux).State = EntityState.Deleted;
                _easyPayDbContext.SaveChanges();
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
            => _mapper.Map<List<T>>(_easyPayDbContext.Users.ToList());

        /// <summary>Gets by identifier.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The by identifier.</returns>
        public T GetById<T>(int id)
            => _mapper.Map<T>(_easyPayDbContext.Users.FirstOrDefault(x => x.Email == id.ToString()));

        /// <summary>Updates the given entity.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>A T.</returns>
        public T Update<T>(T entity)
        {
            var aux = _mapper.Map<User>(entity);
            _easyPayDbContext.Users.Attach(aux);
            _easyPayDbContext.Entry(aux).State = EntityState.Modified;
            _easyPayDbContext.SaveChanges();
            return _mapper.Map<T>(aux);
        }
    }
}