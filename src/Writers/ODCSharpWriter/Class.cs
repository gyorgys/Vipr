// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    public class Class : AttributableStructure
    {
        private Class()
        {
            Constructors = global::ODCSharpWriter.Constructors.Empty;
            Fields = global::ODCSharpWriter.Fields.Empty;
            Indexers = global::ODCSharpWriter.Indexers.Empty;
            Interfaces = global::ODCSharpWriter.ImplementedInterfaces.Empty;
            Methods = global::ODCSharpWriter.Methods.Empty;
            NestedClasses = global::ODCSharpWriter.Classes.Empty;
            Properties = global::ODCSharpWriter.Properties.Empty;
        }

        public string AbstractModifier { get; private set; }
        public string AccessModifier { get; private set; }
        public Type BaseClass { get; private set; }
        public IEnumerable<Field> Fields { get; private set; }
        public Identifier Identifier { get; private set; }
        public IEnumerable<Indexer> Indexers { get; private set; }
        public IEnumerable<Type> Interfaces { get; private set; }
        public IEnumerable<Method> Methods { get; private set; }
        public IEnumerable<Property> Properties { get; private set; }
        public IEnumerable<Constructor> Constructors { get; private set; }
        public IEnumerable<Class> NestedClasses { get; private set; }

        public static Class ForFetcher(OdcmClass odcmClass)
        {
            return new Class
            {
                AccessModifier = "internal ",
                BaseClass =
                    new Type(odcmClass.Base == null
                        ? NamesService.GetExtensionTypeName("RestShallowObjectFetcher")
                        : NamesService.GetFetcherTypeName(odcmClass.Base)),
                Constructors = global::ODCSharpWriter.Constructors.ForFetcher(odcmClass),
                Fields = global::ODCSharpWriter.Fields.ForFetcher(odcmClass),
                Identifier = NamesService.GetFetcherTypeName(odcmClass),
                Interfaces = ImplementedInterfaces.ForFetcher(odcmClass),
                Methods = global::ODCSharpWriter.Methods.ForFetcher(odcmClass),
                Properties = global::ODCSharpWriter.Properties.ForFetcher(odcmClass),
            };
        }

        public static Class ForComplex(OdcmClass odcmClass)
        {
            return new Class
            {
                AbstractModifier = odcmClass.IsAbstract ? "abstract " : string.Empty,
                AccessModifier = "public ",
                Constructors = global::ODCSharpWriter.Constructors.ForComplex(odcmClass),
                BaseClass =
                    new Type(odcmClass.Base == null
                        ? NamesService.GetExtensionTypeName("ComplexTypeBase")
                        : NamesService.GetPublicTypeName(odcmClass.Base)),
                Fields = global::ODCSharpWriter.Fields.ForComplex(odcmClass),
                Identifier = NamesService.GetConcreteTypeName(odcmClass),
                Properties = global::ODCSharpWriter.Properties.ForComplex(odcmClass),
            };
        }

        public static Class ForConcrete(OdcmEntityClass odcmClass)
        {
            return new Class
            {
                AbstractModifier = odcmClass.IsAbstract ? "abstract " : string.Empty,
                AccessModifier = "public ",
                Attributes = global::ODCSharpWriter.Attributes.ForConcrete(odcmClass),
                BaseClass =
                    new Type(odcmClass.Base == null
                        ? NamesService.GetExtensionTypeName("EntityBase")
                        : NamesService.GetConcreteTypeName(odcmClass.Base)),
                Constructors = global::ODCSharpWriter.Constructors.ForConcrete(odcmClass),
                Fields = global::ODCSharpWriter.Fields.ForConcrete(odcmClass),
                Identifier = NamesService.GetConcreteTypeName(odcmClass),
                Interfaces = ImplementedInterfaces.ForConcrete(odcmClass),
                Methods = global::ODCSharpWriter.Methods.ForConcrete(odcmClass),
                Properties = global::ODCSharpWriter.Properties.ForConcrete(odcmClass)
            };
        }

        public static Class ForCollection(OdcmEntityClass odcmClass)
        {
            return new Class
            {
                AccessModifier = "internal ",
                BaseClass = new Type(NamesService.GetExtensionTypeName("QueryableSet"),
                                     new Type(NamesService.GetConcreteInterfaceName(odcmClass))),
                Constructors = global::ODCSharpWriter.Constructors.ForCollection(odcmClass),
                Interfaces = ImplementedInterfaces.ForCollection(odcmClass),
                Identifier = NamesService.GetCollectionTypeName(odcmClass),
                Methods = global::ODCSharpWriter.Methods.ForCollection(odcmClass),
                Indexers = global::ODCSharpWriter.Indexers.ForCollection(odcmClass)
            };
        }

        public static Class ForCountableCollection(OdcmClass odcmClass)
        {
            return new Class
            {
                AccessModifier = "internal ",
                Identifier = NamesService.GetCollectionTypeName(odcmClass),
                Methods = global::ODCSharpWriter.Methods.ForCountableCollectionInterface(odcmClass)
            };
        }

        internal static Class ForEntityContainer(OdcmModel odcmModel, OdcmClass odcmContainer)
        {
            return new Class
            {
                AccessModifier = "public ",
                Constructors = global::ODCSharpWriter.Constructors.ForEntityContainer(odcmContainer),
                Fields = global::ODCSharpWriter.Fields.ForEntityContainer(odcmContainer),
                Interfaces = ImplementedInterfaces.ForEntityContainer(odcmContainer),
                Identifier = NamesService.GetEntityContainerTypeName(odcmContainer),
                NestedClasses = new[] { ForGeneratedEdmModel(odcmModel) },
                Methods = global::ODCSharpWriter.Methods.ForEntityContainer(odcmContainer),
                Properties = global::ODCSharpWriter.Properties.ForEntityContainer(odcmContainer)
            };
        }

        internal static Class ForGeneratedEdmModel(OdcmModel odcmModel)
        {
            return new Class
            {
                AbstractModifier = "abstract ",
                AccessModifier = "private ",
                Fields = global::ODCSharpWriter.Fields.ForGeneratedEdmModel(odcmModel),
                Identifier = new Identifier("", "GeneratedEdmModel"),
                Methods = global::ODCSharpWriter.Methods.ForGeneratedEdmModel(),
            };
        }
    }
}