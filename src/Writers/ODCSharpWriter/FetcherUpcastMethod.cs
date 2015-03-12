﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    public class FetcherUpcastMethod : UpcastMethodBase
    {
        public FetcherUpcastMethod(OdcmType baseType, OdcmType derivedType) : base(baseType, derivedType)
        {
            Name = "To" + derivedType.Name;
            Parameters = global::ODCSharpWriter.Parameters.Empty;
            ReturnType = new Type(NamesService.GetFetcherInterfaceName(derivedType));
        }
    }
}
