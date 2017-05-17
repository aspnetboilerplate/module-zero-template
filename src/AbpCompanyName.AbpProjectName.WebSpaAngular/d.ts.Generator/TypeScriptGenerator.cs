using Abp.Application.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.WebSpaAngular.d.ts.Generator
{
    public static class TypeScriptGenerator
    {
        class TypeInfo
        {
            public string Name { get; set; }
            public Type ActualType { get; set; }
        }

        static List<Type> processedTypes { get; } = new List<Type>();
        static Action<string> WriteLine;

        static void ProcessType(Type type)
        {
            if (type == typeof(Task))
                return;

            var interfaces = new List<StringBuilder>();
            IterateType(type, interfaces);
            foreach (var item in interfaces)
                WriteLine(item.ToString());
            return;
        }

        static void IterateType(Type type, List<StringBuilder> interfaces)
        {
            var typeInfo = GetTypeName(type);
            if (new[] { "number", "boolean", "string", "any" }.Contains(typeInfo.Name) || processedTypes.Contains(type))
                return;

            var builder = new StringBuilder();
            builder.AppendFormat("interface {0} {{\n", typeInfo.Name);
            processedTypes.Add(type);

            foreach (var prop in type.GetProperties())
            {
                var result = GetTypeName(prop.PropertyType);
                IterateType(result.ActualType, interfaces);
                builder.AppendFormat("\t{0}: {1};\n", toJavaScriptStyle(prop.Name), result.Name);
            }                

            builder.Append("}\n");
            interfaces.Add(builder);            
        }

        static TypeInfo GetTypeName(Type type)
        {
            if (new[] { typeof(int), typeof(float), typeof(long), typeof(decimal) }.Contains(type))
                return new TypeInfo { ActualType = type, Name = "number" };
            if (typeof(bool) == type)
                return new TypeInfo { ActualType = type, Name = "boolean" };
            if (typeof(string) == type)
                return new TypeInfo { ActualType = type, Name = "string" };
            if (!type.IsClass && !typeof(IEnumerable).IsAssignableFrom(type))
            {
                if (type.IsGenericType)
                    return GetTypeName(type.GenericTypeArguments.First());
                return new TypeInfo { ActualType = type, Name = "any" };
            }
            if (type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type))
            {                
                var underType = type.GenericTypeArguments.First();
                return new TypeInfo { ActualType = underType, Name = string.Format("Array<{0}>", GetTypeName(underType).Name) };                                
            }
            if(type.Name.Contains("ListResultDto"))
            {
                var underType = type.GenericTypeArguments.First();
                return new TypeInfo { ActualType = underType, Name = string.Format("ListResultDto<{0}>", GetTypeName(underType).Name) };
            }            
            return new TypeInfo { ActualType = type, Name = type.Name };
        }

        static void ProcessService(Type serviceType)
        {
            WriteComments(template: '#');
            WriteComments(serviceType.Name);
            WriteComments();

            var argTypes2process = new List<Type>();
            var builder = new StringBuilder();
            builder.AppendFormat("interface {0} {{\n", serviceType.Name);

            Func<string, Dictionary<string, string>, string, string> createMethod = (methodName, args, returnTypeName) =>
            {
                return string.Format("\t{0}({1}): {2};\n", methodName, args.Count > 0 ? args.Select(x => x.Key + ": " + x.Value).Aggregate((a, b) => a + ", " + b) : "", returnTypeName);
            };

            foreach (var method in serviceType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(mi => !(mi.IsSpecialName && (mi.Name.StartsWith("set_") || mi.Name.StartsWith("get_")))))
            {
                var methodName = toJavaScriptStyle(method.Name);

                var args = new Dictionary<string, string>();
                foreach (var arg in method.GetParameters())
                {
                    var temp = GetTypeName(arg.ParameterType);
                    argTypes2process.Add(temp.ActualType);
                    args.Add(arg.Name, temp.Name);
                }
                args.Add("ajaxParams?", "JQueryAjaxSettings");

                var returnType = (method.ReturnType.IsGenericType && method.ReturnType.BaseType == typeof(Task)) ? method.ReturnType.GenericTypeArguments.First() : method.ReturnType;                
                var returnTypeActual = GetTypeName(returnType);

                argTypes2process.Add(returnTypeActual.ActualType);
                var returnTypeName = returnType == typeof(Task) ? "AbpResultVoid" : string.Format("AbpResult<{0}>", returnTypeActual.Name);

                builder.Append(createMethod(methodName, args, returnTypeName));                
            }

            builder.Append("}");

            argTypes2process.Distinct().ToList().ForEach(x => ProcessType(x));
            WriteLine(builder.ToString());

            WriteComments(template: '#');
            WriteLine("\n");
        }

        static string toJavaScriptStyle(string row)
        {
            return char.ToLower(row.ToCharArray()[0]) + row.Substring(1);
        }

        static void WriteComments(string message = "", char template = '-')
        {
            const int rowLength = 100;
            WriteLine("//" + message + new string(Enumerable.Repeat(template, rowLength - message.Length).ToArray()));
        }

        static void WriteCommonResult()
        {
            WriteComments(template: '#');
            WriteLine("//This file was created automatically with the help of TypeScriptGenerator class.");
            WriteComments(template: '#');

            WriteLine("interface AbpErrorResponse {\n\tcode: number;\n\tdetails;\n\tmessage: string;\n\tvalidationErrros;\n}");
            WriteLine("\ninterface AbpResult<TAnswer> {\n\tsuccess:(callback: (result: TAnswer) => void) => AbpResult<TAnswer>;\n\terror:(callback: (response: AbpErrorResponse) => void) => AbpResult<TAnswer>;\n}\n");
            WriteLine("interface AbpResultVoid {\n\tsuccess:(callback: () => void) => AbpResultVoid;\n\terror:(callback: (response: AbpErrorResponse) => void) => AbpResultVoid;\n}\n");
            WriteLine("interface ListResultDto<T> {\n\titems: Array<T>;\n}\n");
        }

        public static void Start(Action<string> writeLine)
        {
            WriteLine = writeLine;
            WriteCommonResult();
            typeof(AbpProjectNameApplicationModule).Assembly.GetTypes().Where(x => typeof(IApplicationService).IsAssignableFrom(x) && !x.IsAbstract).ToList().ForEach(x => ProcessService(x));
        }
    }
}
