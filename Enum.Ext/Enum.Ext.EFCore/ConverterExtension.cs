﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Enum.Ext.EFCore
{
    public static class ConverterExtension
    {
        public static void ConfigureEnumExt(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties()
                    .Where(p => IsDerived(p.PropertyType));

                foreach (var property in properties)
                {
                    var genericArguments = GetKeyType(property.PropertyType).GetTypeInfo().GenericTypeArguments;

                    var converterType = typeof(TypeSafeEnumConverter<,>)
                       .MakeGenericType(genericArguments[0], genericArguments[1]);

                    var converter = (ValueConverter)Activator.CreateInstance(converterType);

                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion(converter);
                }
            }
        }

        private static bool IsDerived(Type objectType)
        {
            Type currentType = objectType.BaseType;
            while (currentType != typeof(object))
            {
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == typeof(TypeSafeEnum<,>))
                    return true;

                currentType = currentType.BaseType;
            }

            return false;
        }

        private static Type GetKeyType(Type objectType)
        {
            Type currentType = objectType.BaseType;
            while (currentType != typeof(object))
            {
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == typeof(TypeSafeEnum<,>))
                    return currentType.GenericTypeArguments[1];

                currentType = currentType.BaseType;
            }

            return null;
        }
    }
}