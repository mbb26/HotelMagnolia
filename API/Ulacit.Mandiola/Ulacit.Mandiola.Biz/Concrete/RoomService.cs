using System.Collections.Generic;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;
using Ulacit.Mandiola.DB.MandiolaDb;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing rooms information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class RoomService : BasicService, IRoomService
    {
        /// <summary>Context for the room.</summary>
        private readonly IRoomContext _roomContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.RoomService class.</summary>
        /// <param name="roomContext">Context for the room.</param>
        public RoomService(IRoomContext roomContext) : base(roomContext)
        {
            _roomContext = roomContext;
        }

        public List<T> GetAvailable<T>()
        {
            return _roomContext.GetAvailable<T>();
        }
    }
}