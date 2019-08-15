using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing activities information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class ActivityService : BasicService, IActivityService
    {
        /// <summary>Context for the activity.</summary>
        private readonly IActivityContext _activityContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.ActivityService class.</summary>
        /// <param name="activityContext">Context for the activity.</param>
        public ActivityService(IActivityContext activityContext) : base(activityContext)
        {
            _activityContext = activityContext;
        }
    }
}