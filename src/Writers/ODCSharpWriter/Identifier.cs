// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ODCSharpWriter
{
    public class Identifier
    {
        public Identifier(string @namespace, string name)
        {
            Name = name;
            Namespace = @namespace;
        }

        public string OriginalName { get; private set; }

        public string OriginalNamespace { get; private set; }


        public string Name { get; private set; }

        public string Namespace { get; private set; }

        public string FullName
        {
            get
            {
                return Namespace == null
                    ? Name
                    : Namespace + "." + Name;
            }
        }

        public override string ToString()
        {
            return Name;
        }


        public static Identifier Task { get { return new Identifier("global::System.Threading.Tasks", "Task"); } }
    }
}
