﻿/*
 * Copyright 2021 James Courtney
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Unity.Collections;

namespace FlatSharpTests.Compiler;

public class FullTests
{
#if NET5_0_OR_GREATER
    /// <summary>
    /// Tests that we can compile a complex schema.
    /// </summary>
    [Fact]
    public void FullTest()
    {
        foreach (FlatBufferDeserializationOption option in Enum.GetValues(typeof(FlatBufferDeserializationOption)))
        {
            this.Test(option);
        }
    }

    private void Test(FlatBufferDeserializationOption option)
    {
        string schema = $@"
        {MetadataHelpers.AllAttributes}

        namespace FullTest;

        enum RegularEnum : ubyte {{ A, B, C = 4, D, E = 10 }}
        enum FlagsEnum : uint ({MetadataKeys.BitFlags}) {{ A, B, C, D, E, F, G, H, I, J }}

        union Any {{ Table, InnerStruct, OuterStruct, IT : InnerTable }}

        table Table ({MetadataKeys.SerializerKind}:""{option}"") 
        {{ 
            Bool : bool;
            DeprecatedBool : bool ({MetadataKeys.Deprecated});
            Byte : ubyte ({MetadataKeys.Setter}:""Public"");
            SByte : byte ({MetadataKeys.Setter}:""None"");
            UShort : ushort = 3 ({MetadataKeys.Setter}:""PublicInit"");
            Short : short = null ({MetadataKeys.Setter}:""ProtectedInit"");
            DeprecatedShort : short ({MetadataKeys.Deprecated}, {MetadataKeys.Setter}:""ProtectedInit"");
            UInt : uint = null ({MetadataKeys.Setter}:""Protected"");
            Int : int = 3 ({MetadataKeys.Setter}:""ProtectedInternal"");
            ULong : ulong ({MetadataKeys.Setter}:""ProtectedInternalInit"");
            Long : long = null;
            Double : double = 10;
            Float : float;
            E1 : RegularEnum = null;
            E2 : FlagsEnum = E;

            Outer : OuterStruct;
            OuterVirtual : OuterStruct;

            StructVectorList : [OuterStruct] ({MetadataKeys.VectorKind}:""IList"");
            StructVectorArray : [OuterStruct] ({MetadataKeys.VectorKind}:""IReadOnlyList"");

            TableVectorList : [InnerTable] ({MetadataKeys.VectorKind}:""IList"", {MetadataKeys.SortedVector});
            TableVectorArray : [InnerTable] ({MetadataKeys.VectorKind}:""IReadOnlyList"");
            TableVectorIndexed : [InnerTable] ({MetadataKeys.VectorKind}:""IIndexedVector"");

            MemVector : [ubyte] ({MetadataKeys.VectorKind}:""Memory"");
            RoMemVector : [ubyte] ({MetadataKeys.VectorKind}:""ReadOnlyMemory"");
                
            ScalarVector : [uint] ({MetadataKeys.VectorKind}:""IList"");
            ScalarArray : [uint] ({MetadataKeys.VectorKind}:""IReadOnlyList"");
            ScalarUnityNativeArray : [uint] ({MetadataKeys.VectorKind}:""UnityNativeArray"");

            UnionVector : [Any] ({MetadataKeys.VectorKind}:""IList"");
            UnionArray : [Any] ({MetadataKeys.VectorKind}:""IReadOnlyList"");
        }}

        table InnerTable
        {{
            String : string ({MetadataKeys.Key});   
            String2 : string ({MetadataKeys.SharedString});
        }}

        struct InnerStruct {{
            Bytes : [ubyte:32];
        }}
            
        struct OuterStruct {{
            Inner : InnerStruct;
            RegEnum : RegularEnum;
            FEnum : FlagsEnum;
        }}
        ";

        FlatSharpCompiler.CompileAndLoadAssembly(schema, new() { UnityAssemblyPath = typeof(NativeArray<>).Assembly.Location});
    }
#endif
}
