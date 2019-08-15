using Ulacit.Mandiola.Biz.Abstract;
using Ulacit.Mandiola.Common.Concrete;
using Ulacit.Mandiola.DB.Abstract;
using Ulacit.Mandiola.IoC.Concrete;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.Biz.Concrete
{
    /// <summary>A service for accessing articles information.</summary>
    [Dependency(DependencyScope.Transient)]
    public class ArticleService : BasicService, IArticleService
    {
        /// <summary>Context for the activity.</summary>
        private readonly IArticleContext _activityContext;

        /// <summary>Initializes a new instance of the Ulacit.Mandiola.Biz.Concrete.ArticleService class.</summary>
        /// <param name="articleContext">Context for the article.</param>
        public ArticleService(IArticleContext articleContext) : base(articleContext)
        {
            _activityContext = articleContext;
        }
    }
}