using System.Reflection;
using System.Text;
using System.Web;

namespace System
{
    public static class ClassExtensions
    {
        public static string? ToQueryString(this object objeto)
        {
            if (objeto == null)
                return string.Empty;

            if (objeto.GetType() == typeof(string))
                return objeto.ToString();

            var result = new StringBuilder();
            
            var props = objeto.GetType().GetProperties(BindingFlags.Public);
            foreach(var prop in props)
            {
                if (result.Length > 0)
                    result.Append(",");

                result.Append($"{HttpUtility.UrlEncode(prop.Name)}=");
                if(prop.GetValue(objeto) != null)
                    result.Append(prop.GetValue(objeto));
            }

            return result.ToString();
        }
    }
}
