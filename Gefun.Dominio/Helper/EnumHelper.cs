using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

public class EnumItem<T> where T : struct, IConvertible
    {
        public string Descricao { get; set; }
        public T Valor { get; set; }
        public int ValorInt { get => Convert.ToInt32(Valor); }
        public int Index { get; set; }

        public override string ToString()
        {
            return Descricao;
        }

        public EnumItem(T valor, int index)
        {
            Valor = valor;
            Descricao = EnumHelper.ObterDescricao(valor);
            Index = index;
        }

        public EnumItem(T valor)
        {
            Valor = valor;
            Descricao = EnumHelper.ObterDescricao(valor);
            Index = Convert.ToInt32(valor);
        }
    }

    public class EnumHelper
    {
        public static string[] ObterDescricoes<T>()
        {
            return Enum.GetNames(typeof(T))
                .Select(name => ObterDescricao<T>(name))
                .ToArray();
        }

        public static string ObterDescricao<T>(T value)
        {
            if (value == null)
                return null;

            Type typeEnum = value.GetType();
            if (!typeEnum.IsEnum)
                throw new InvalidEnumArgumentException("O parâmetro não é um Enum");
            var property = typeEnum.GetField(value.ToString());
            if (property == null)
                return value.ToString();
            return ReflectionHelper.ObterNomeEnum(property);
        }

        public static T ObterEnum<T>(string descricao) where T : struct, IConvertible
        {
            if (descricao == null) return default(T);

            var name = Enum.GetNames(typeof(T))
                .FirstOrDefault(nam => descricao == nam || descricao.Equals(ObterDescricao<T>(nam)));
            return (T)Enum.Parse(typeof(T), name);
        }

        public static T ObterEnumMDFe<T>(string descricao)
        {
            var name = Enum.GetNames(typeof(T)).FirstOrDefault(nam => descricao == nam);
            return (T)Enum.Parse(typeof(T), name);
        }

        public static IList<EnumItem<T>> ObterLista<T>() where T : struct, IConvertible
        {
            var index = 0;
            var list = new List<EnumItem<T>>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                list.Add(new EnumItem<T>((T)item, index));
                index++;
            }

            return list;
        }

        private static string ObterDescricao<T>(string valor)
        {
            Type type = typeof(T);
            var name = Enum.GetNames(type)
                .Where(f => f.Equals(valor, StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefault();

            if (name == null)
                return string.Empty;

            var field = type.GetField(name);
            return ReflectionHelper.ObterNomeEnum(field);
        }

        /// <summary>
        /// https://stackoverflow.com/questions/3047125/retrieve-enum-value-based-on-xmlenumattribute-name-value
        /// </summary>
        public static T? ObterEnumByXmlEnumAttribute<T>(string value) where T : struct, IConvertible
        {
            // http://stackoverflow.com/a/3073272/194717
            foreach (object o in Enum.GetValues(typeof(T)))
            {
                T enumValue = (T)o;
                if (GetXmlAttributeNameFromEnumValue(enumValue).Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return enumValue;
                }
            }

            return null;
        }

        public static string GetXmlAttributeNameFromEnumValue<T>(T pEnumVal) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            return GetXmlAttrNameFromEnumValue(pEnumVal, enumType);
        }

        public static string GetXmlAttrNameFromEnumValue(object pEnumVal, Type enumType) 
        {
            // http://stackoverflow.com/q/3047125/194717
            var type = pEnumVal.GetType();
            var info = type.GetField(Enum.GetName(enumType, pEnumVal));
            var att = (XmlEnumAttribute)info.GetCustomAttributes(typeof(XmlEnumAttribute), false)[0];

            return att.Name;
        }

        
        
    }