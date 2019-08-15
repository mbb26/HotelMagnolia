using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing room types information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class RoomTypeService : BasicService, IRoomTypeService
    {
        /// <summary>Context for the room.</summary>
        private readonly IRoomContext _roomContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.RoomTypeService class.</summary>
        /// <param name="roomContext">Context for the room.</param>
        public RoomTypeService(IRoomContext roomContext) : base(roomContext)
        {
            _roomContext = roomContext;
        }
    }
}