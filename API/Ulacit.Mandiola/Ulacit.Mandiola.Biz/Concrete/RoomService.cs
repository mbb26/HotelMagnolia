using System.Collections.Generic;
using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;
using System.Web.Http.Cors;


namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing rooms information.</summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        /// <summary>Initialices getting all available rooms.</summary>
        /// <param name="roomContext">All available rooms.</param>
        public List<T> GetAvailable<T>()
        {
            return _roomContext.GetAvailable<T>();

        }
    }
}