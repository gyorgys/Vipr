﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODCSharpWriter
{
    public static class StringExtensions
    {
        public static string ToLowerCamelCase(this string input)
        {
            return char.ToLower(input[0]) + input.Substring(1);
        }

        public static string ToPascalCase(this string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
