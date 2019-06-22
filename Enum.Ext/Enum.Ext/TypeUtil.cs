﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Enum.Ext
{
    internal static class TypeUtil
    {
        public static bool IsDerived(Type objectType, Type mainType)
        {
            Type currentType = objectType.BaseType;

            if (currentType == null)
            {
                return false;
            }

            while (currentType != typeof(object))
            {
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == mainType)
                    return true;

                currentType = currentType.BaseType;
            }

            return false;
        }

        public static Type GetKeyType(Type objectType, Type mainType)
        {
            Type currentType = objectType.BaseType;

            if (currentType == null)
            {
                return null;
            }

            while (currentType != typeof(object))
            {
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == mainType)
                    return currentType.GenericTypeArguments[1];

                currentType = currentType.BaseType;
            }

            return null;
        }
    }
}