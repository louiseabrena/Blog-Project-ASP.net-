using System;
using System.Reflection;

namespace BlogProject_MaryLouiseAnhanceAbrena.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}