using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MicroNetCore.Collections
{
    public sealed class TypeBundle<TType>
    {
        public TypeBundle(IEnumerable<Type> types)
        {
            var typeArray = types as Type[] ?? types.ToArray();

            ValidateTypes(typeArray);
            Types = typeArray;
        }

        public IEnumerable<Type> Types { get; }

        private static void ValidateTypes(IEnumerable<Type> types)
        {
            foreach (var type in types)
                ValidateType(type);
        }

        private static void ValidateType(Type type)
        {
            if (!IsValidType(type))
                throw GetException(type);
        }

        private static bool IsValidType(Type type)
        {
            return typeof(TType).IsAssignableFrom(type);
        }

        private static Exception GetException(MemberInfo type)
        {
            var inner = new Exception($"Type {type.Name} is not a {typeof(TType).Name} type.");

            return new TypeInitializationException(type.Name, inner);
        }
    }
}