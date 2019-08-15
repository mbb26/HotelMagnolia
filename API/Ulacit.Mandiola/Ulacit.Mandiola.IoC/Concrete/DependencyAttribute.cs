using System;
using Ulacit.Mandiola.IoC.Enum;

namespace Ulacit.Mandiola.IoC.Concrete
{
    /// <summary>Indicates that a class is a dependency that must be registered in a dependency injection container.</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class DependencyAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="DependencyAttribute"/> class.</summary>
        /// <param name="scope">The scope of the dependency.</param>
        public DependencyAttribute(DependencyScope scope)
        {
            this.Scope = scope;
        }

        /// <summary>Gets the scope of the dependency.</summary>
        /// <value>The scope.</value>
        public DependencyScope Scope { get; }
    }
}