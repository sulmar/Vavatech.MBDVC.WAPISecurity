using System;
using System.Reflection;

namespace MBDVC.WAPISecurity.GoogleAuthentication.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}