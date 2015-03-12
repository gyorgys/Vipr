// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    internal class Interface : AttributableStructure
    {
        public Identifier Identifier { get; private set; }

        public string Namespace { get; private set; }

        public IEnumerable<InterfaceProperty> Properties { get; private set; }

        public IEnumerable<IndexerSignature> Indexers { get; private set; }

        public IEnumerable<Type> Interfaces { get; private set; }

        public IEnumerable<MethodSignature> Methods { get; private set; }

        private Interface()
        {
            Indexers = new List<Indexer>();
            Interfaces = new List<Type>();
            Methods = new List<Method>();
            Properties = new List<InterfaceProperty>();
        }

        public static Interface ForConcrete(OdcmClass odcmClass)
        {
            return new Interface
            {
                Attributes = global::ODCSharpWriter.Attributes.ForConcreteInterface,
                Identifier = NamesService.GetConcreteInterfaceName(odcmClass),
                Methods = global::ODCSharpWriter.Methods.ForConcreteInterface(odcmClass),
                Namespace = NamesService.GetNamespaceName(odcmClass.Namespace),
                Properties = global::ODCSharpWriter.Properties.ForConcreteInterface(odcmClass),
                Interfaces = global::ODCSharpWriter.ImplementedInterfaces.ForConcreteInterface(odcmClass)
            };
        }

        public static Interface ForFetcher(OdcmClass odcmClass)
        {
            return new Interface
            {
                Attributes = global::ODCSharpWriter.Attributes.ForFetcherInterface,
                Identifier = NamesService.GetFetcherInterfaceName(odcmClass),
                Interfaces = global::ODCSharpWriter.ImplementedInterfaces.ForFetcherInterface(odcmClass),
                Methods = global::ODCSharpWriter.Methods.ForFetcherInterface(odcmClass),
                Namespace = NamesService.GetNamespaceName(odcmClass.Namespace),
                Properties = global::ODCSharpWriter.Properties.ForFetcherInterface(odcmClass)
            };
        }

        public static Interface ForCollection(OdcmEntityClass odcmClass)
        {
            return new Interface
            {
                Attributes = global::ODCSharpWriter.Attributes.ForCollectionInterface,
                Identifier = NamesService.GetCollectionInterfaceName(odcmClass),
                Namespace = NamesService.GetNamespaceName(odcmClass.Namespace),
                Methods = global::ODCSharpWriter.Methods.ForCollectionInterface(odcmClass),
                Indexers = IndexerSignature.ForCollectionInterface(odcmClass),
                Interfaces = new[] { new Type(NamesService.GetExtensionTypeName("IReadOnlyQueryableSetBase"), new Type(NamesService.GetConcreteInterfaceName(odcmClass))) }
            };
        }

        public static Interface ForEntityContainer(OdcmClass odcmContainer)
        {
            return new Interface
            {
                Identifier = NamesService.GetEntityContainerInterfaceName(odcmContainer),
                Interfaces = null,
                Methods = global::ODCSharpWriter.Methods.ForEntityContainerInterface(odcmContainer),
                Properties = global::ODCSharpWriter.Properties.ForEntityContainerInterface(odcmContainer),
                Namespace = NamesService.GetNamespaceName(odcmContainer.Namespace)
            };
        }

        public static Interface ForCountableCollection(OdcmClass odcmClass)
        {
            return new Interface
            {
                Identifier = NamesService.GetCollectionInterfaceName(odcmClass),
                Methods = global::ODCSharpWriter.Methods.ForCountableCollectionInterface(odcmClass)
            };
        }
    }
}
