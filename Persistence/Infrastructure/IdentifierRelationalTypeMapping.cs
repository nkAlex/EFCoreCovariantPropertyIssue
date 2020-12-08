using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Identifiers;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.Infrastructure
{
    public class IdentifierRelationalTypeMapping : RelationalTypeMapping
    {
        private static readonly Dictionary<Type, ValueConverter> _converters = new();

        public IdentifierRelationalTypeMapping(Type type)
            : base(
                new RelationalTypeMappingParameters(
                    new CoreTypeMappingParameters(typeof(Guid), GetConverter(type)),
                    "uuid",
                    StoreTypePostfix.None,
                    System.Data.DbType.Guid))
        {
        }

        private static ValueConverter GetConverter(Type type)
        {
            if (!_converters.TryGetValue(type, out var converter))
            {
                converter = typeof(IdentifierToGuidValueConverter<>)
                            .MakeGenericType(type)
                            .GetProperty(nameof(IdentifierToGuidValueConverter<Identifier>.Default), BindingFlags.Public | BindingFlags.Static)!
                    .GetValue(null) as ValueConverter;
                _converters.TryAdd(type, converter!);
            }
            return converter;
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            return new IdentifierRelationalTypeMapping(parameters.CoreParameters.Converter.ModelClrType);
        }
    }
}
