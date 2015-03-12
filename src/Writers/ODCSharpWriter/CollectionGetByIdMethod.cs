﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    public class CollectionGetByIdMethod : Method
    {
        public CollectionGetByIdMethod(OdcmClass odcmClass)
        {
            Name = "GetById";
            Parameters = global::ODCSharpWriter.Parameters.GetKeyParameters(odcmClass);
            ReturnType = new Type(NamesService.GetFetcherInterfaceName(odcmClass));
        }
    }
}
