// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ODCSharpWriter
{
    public class ContainerGetUrlMethod : Method
    {
        public ContainerGetUrlMethod()
        {
            IsPublic = false;

            Name = "GetUrl";
            Parameters = new Parameter[] { };
            ReturnType = new Type(new Identifier("System", "Uri"));
        }
    }
}