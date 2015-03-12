﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    public class ConcreteNavigationCollectionProperty : ConcreteNavigationProperty
    {
        public OdcmType OdcmType { get; private set; }

        private ConcreteNavigationCollectionProperty(OdcmProperty odcmProperty) : base(odcmProperty)
        {
            FieldName = NamesService.GetConcreteFieldName(odcmProperty);
            OdcmType = odcmProperty.Type;
            PrivateSet = true;
            Type = new Type(NamesService.GetExtensionTypeName("IPagedCollection"),
                new Type(NamesService.GetConcreteInterfaceName(odcmProperty.Type)));
        }

        public new static ConcreteNavigationProperty ForConcrete(OdcmProperty odcmProperty)
        {
            return new ConcreteNavigationCollectionProperty(odcmProperty)
            {
                DefiningInterface = NamesService.GetConcreteInterfaceName(odcmProperty.Class),
            };
        }
    }
}
