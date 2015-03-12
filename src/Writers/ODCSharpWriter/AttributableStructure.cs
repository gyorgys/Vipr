﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace ODCSharpWriter
{
    public abstract class AttributableStructure
    {
        public IEnumerable<Attribute> Attributes { get; protected set; }

        protected AttributableStructure()
        {
            Attributes = new List<Attribute>();
        }
    }
}
