// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    internal class CSharpProject
    {
        public IEnumerable<Namespace> Namespaces { get; set; }

        public CSharpProject(OdcmModel model)
        {
            Namespaces = global::ODCSharpWriter.Namespaces.ForModel(model);
        }
    }
}