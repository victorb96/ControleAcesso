using System.ComponentModel;
using System.Text.RegularExpressions;

namespace GF.ControleAcesso.Application.Helpers;

public static class ExtensionMethods
{
    public static string GetEnumDescription(this Enum enumValue)
    {
        var field = enumValue.GetType().GetField(enumValue.ToString());
        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            return attribute.Description;
        
        return string.Empty;
    }

    public static bool IsValidEmail(this string email)
        => new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(email);
}