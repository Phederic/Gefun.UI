using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

public static class ReflectionHelper
    {
        public static string ObterNomeClasse<T>()
        {
            MemberInfo property = typeof(T);

            return ObterNomePropriedade(property);
        }

        private static string ObterNomePropriedade(MemberInfo property)
        {
            if (property.GetCustomAttribute(typeof(DisplayNameAttribute)) is DisplayNameAttribute dd)
                return dd.DisplayName;

            if (property.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute d)
                return d.Name;

            return property.Name;
        }

        public static string ObterDisplayNamePropriedade(FieldInfo field)
        {
            if (field.GetCustomAttribute(typeof(DisplayNameAttribute)) is DisplayNameAttribute dd)
                return dd.DisplayName;

            if (field.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute d)
                return d.Name;

            return field.Name;
        }

        public static string ObterNomePropriedade<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (expression.Body is MemberExpression member)
                return member.Member.Name;

            throw new ArgumentException("Expression is not a member access", "expression");
        }

        public static string ObterNomeEnum(FieldInfo field)
        {
            if (field.GetCustomAttribute(typeof(DescriptionAttribute)) is DescriptionAttribute dex)
                return dex.Description;
            return ObterDisplayNamePropriedade(field);
        }

        public static MemberInfo GetMemberInfo<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (expression.Body is MemberExpression member)
                return member.Member;

            throw new ArgumentException("Expression is not a member access", "expression");
        }

        public static string GetDisplayNomePropriedade<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var memberInfo = GetMemberInfo(expression);
            return ObterNomePropriedade(memberInfo);
        }
    }