using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Xml.XPath;
using Ulacit.Mandiola.API.Areas.HelpPage.ModelDescriptions;

namespace Ulacit.Mandiola.API.Areas.HelpPage
{
    /// <summary>A custom <see cref="IDocumentationProvider"/> that reads the API documentation from an XML documentation file.</summary>
    public class XmlDocumentationProvider : IDocumentationProvider, IModelDocumentationProvider
    {
        /// <summary>The document navigator.</summary>
        private XPathNavigator _documentNavigator;

        /// <summary>The type expression.</summary>
        private const string TypeExpression = "/doc/members/member[@name='T:{0}']";

        /// <summary>The method expression.</summary>
        private const string MethodExpression = "/doc/members/member[@name='M:{0}']";

        /// <summary>The property expression.</summary>
        private const string PropertyExpression = "/doc/members/member[@name='P:{0}']";

        /// <summary>The field expression.</summary>
        private const string FieldExpression = "/doc/members/member[@name='F:{0}']";

        /// <summary>The parameter expression.</summary>
        private const string ParameterExpression = "param[@name='{0}']";

        /// <summary>Initializes a new instance of the <see cref="XmlDocumentationProvider"/> class.</summary>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <param name="documentPath">The physical path to XML document.</param>
        public XmlDocumentationProvider(string documentPath)
        {
            if (documentPath == null)
            {
                throw new ArgumentNullException("documentPath");
            }
            XPathDocument xpath = new XPathDocument(documentPath);
            _documentNavigator = xpath.CreateNavigator();
        }

        /// <summary>Gets the documentation based on <see cref="T:System.Web.Http.Controllers.HttpActionDescriptor" />.</summary>
        /// <param name="controllerDescriptor">Information describing the controller.</param>
        /// <returns>The documentation for the controller.</returns>
        public string GetDocumentation(HttpControllerDescriptor controllerDescriptor)
        {
            XPathNavigator typeNode = GetTypeNode(controllerDescriptor.ControllerType);
            return GetTagValue(typeNode, "summary");
        }

        /// <summary>Gets the documentation based on <see cref="T:System.Web.Http.Controllers.HttpActionDescriptor" />.</summary>
        /// <param name="actionDescriptor">The action descriptor.</param>
        /// <returns>The documentation for the controller.</returns>
        public virtual string GetDocumentation(HttpActionDescriptor actionDescriptor)
        {
            XPathNavigator methodNode = GetMethodNode(actionDescriptor);
            return GetTagValue(methodNode, "summary");
        }

        /// <summary>Gets the documentation based on <see cref="T:System.Web.Http.Controllers.HttpParameterDescriptor" />.</summary>
        /// <param name="parameterDescriptor">The parameter descriptor.</param>
        /// <returns>The documentation for the controller.</returns>
        public virtual string GetDocumentation(HttpParameterDescriptor parameterDescriptor)
        {
            ReflectedHttpParameterDescriptor reflectedParameterDescriptor = parameterDescriptor as ReflectedHttpParameterDescriptor;
            if (reflectedParameterDescriptor != null)
            {
                XPathNavigator methodNode = GetMethodNode(reflectedParameterDescriptor.ActionDescriptor);
                if (methodNode != null)
                {
                    string parameterName = reflectedParameterDescriptor.ParameterInfo.Name;
                    XPathNavigator parameterNode = methodNode.SelectSingleNode(String.Format(CultureInfo.InvariantCulture, ParameterExpression, parameterName));
                    if (parameterNode != null)
                    {
                        return parameterNode.Value.Trim();
                    }
                }
            }

            return null;
        }

        /// <summary>Gets response documentation.</summary>
        /// <param name="actionDescriptor">Information describing the action.</param>
        /// <returns>The response documentation.</returns>
        public string GetResponseDocumentation(HttpActionDescriptor actionDescriptor)
        {
            XPathNavigator methodNode = GetMethodNode(actionDescriptor);
            return GetTagValue(methodNode, "returns");
        }

        /// <summary>Gets a documentation.</summary>
        /// <param name="member">The member.</param>
        /// <returns>The documentation.</returns>
        public string GetDocumentation(MemberInfo member)
        {
            string memberName = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", GetTypeName(member.DeclaringType), member.Name);
            string expression = member.MemberType == MemberTypes.Field ? FieldExpression : PropertyExpression;
            string selectExpression = String.Format(CultureInfo.InvariantCulture, expression, memberName);
            XPathNavigator propertyNode = _documentNavigator.SelectSingleNode(selectExpression);
            return GetTagValue(propertyNode, "summary");
        }

        /// <summary>Gets a documentation.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The documentation.</returns>
        public string GetDocumentation(Type type)
        {
            XPathNavigator typeNode = GetTypeNode(type);
            return GetTagValue(typeNode, "summary");
        }

        /// <summary>Gets method node.</summary>
        /// <param name="actionDescriptor">Information describing the action.</param>
        /// <returns>The method node.</returns>
        private XPathNavigator GetMethodNode(HttpActionDescriptor actionDescriptor)
        {
            ReflectedHttpActionDescriptor reflectedActionDescriptor = actionDescriptor as ReflectedHttpActionDescriptor;
            if (reflectedActionDescriptor != null)
            {
                string selectExpression = String.Format(CultureInfo.InvariantCulture, MethodExpression, GetMemberName(reflectedActionDescriptor.MethodInfo));
                return _documentNavigator.SelectSingleNode(selectExpression);
            }

            return null;
        }

        /// <summary>Gets member name.</summary>
        /// <param name="method">The method.</param>
        /// <returns>The member name.</returns>
        private static string GetMemberName(MethodInfo method)
        {
            string name = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", GetTypeName(method.DeclaringType), method.Name);
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length != 0)
            {
                string[] parameterTypeNames = parameters.Select(param => GetTypeName(param.ParameterType)).ToArray();
                name += String.Format(CultureInfo.InvariantCulture, "({0})", String.Join(",", parameterTypeNames));
            }

            return name;
        }

        /// <summary>Gets tag value.</summary>
        /// <param name="parentNode">The parent node.</param>
        /// <param name="tagName">   Name of the tag.</param>
        /// <returns>The tag value.</returns>
        private static string GetTagValue(XPathNavigator parentNode, string tagName)
        {
            if (parentNode != null)
            {
                XPathNavigator node = parentNode.SelectSingleNode(tagName);
                if (node != null)
                {
                    return node.Value.Trim();
                }
            }

            return null;
        }

        /// <summary>Gets type node.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The type node.</returns>
        private XPathNavigator GetTypeNode(Type type)
        {
            string controllerTypeName = GetTypeName(type);
            string selectExpression = String.Format(CultureInfo.InvariantCulture, TypeExpression, controllerTypeName);
            return _documentNavigator.SelectSingleNode(selectExpression);
        }

        /// <summary>Gets type name.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The type name.</returns>
        private static string GetTypeName(Type type)
        {
            string name = type.FullName;
            if (type.IsGenericType)
            {
                // Format the generic type name to something like: Generic{System.Int32,System.String}
                Type genericType = type.GetGenericTypeDefinition();
                Type[] genericArguments = type.GetGenericArguments();
                string genericTypeName = genericType.FullName;

                // Trim the generic parameter counts from the name
                genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
                string[] argumentTypeNames = genericArguments.Select(t => GetTypeName(t)).ToArray();
                name = String.Format(CultureInfo.InvariantCulture, "{0}{{{1}}}", genericTypeName, String.Join(",", argumentTypeNames));
            }
            if (type.IsNested)
            {
                // Changing the nested type name from OuterType+InnerType to OuterType.InnerType to match the XML documentation syntax.
                name = name.Replace("+", ".");
            }

            return name;
        }
    }
}