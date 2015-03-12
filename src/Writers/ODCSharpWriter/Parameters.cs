// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Vipr.Core;
using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    public class Parameters
    {
        public static IEnumerable<Parameter> GetKeyParameters(OdcmClass odcmClass)
        {
            return odcmClass is OdcmEntityClass ? ((OdcmEntityClass)odcmClass).Key.Select(Parameter.FromProperty) : null;
        }

        public static IEnumerable<Parameter> Empty { get { return Enumerable.Empty<Parameter>(); } }
    }
}