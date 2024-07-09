namespace GF.ControleAcesso.Infra.CrossCutting.Helpers;
using System.ComponentModel;

public static class ExtensionMethods
{
    public static string GetEnumDescription(this Enum enumValue)
    {
        var field = enumValue.GetType().GetField(enumValue.ToString());
        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            return attribute.Description;
        
        return string.Empty;
    }
}