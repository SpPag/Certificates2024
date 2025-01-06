using System.ComponentModel;

namespace Certificates2024.Data.Enums
{
    public enum TopicName
    {
        [Description("C# Basics")]
        CSharpBasics = 1,

        [Description("C# Advanced")]
        CSharpAdvanced,

        [Description("JavaScript Basics")]
        JavaScriptBasics,

        [Description("JavaScript Advanced")]
        JavaScriptAdvanced,

        [Description("C# Expert")]
        CSharpExpert,

        [Description("JavaScript Expert")]
        JavaScriptExpert
    }
}
