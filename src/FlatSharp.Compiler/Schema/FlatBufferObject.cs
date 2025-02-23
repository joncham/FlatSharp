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

using FlatSharp.Attributes;

namespace FlatSharp.Compiler.Schema;

/*
table Object {  // Used for both tables and structs.
    name:string (required, key);
    fields:[Field] (required);  // Sorted.
    is_struct:bool = false;
    minalign:int;
    bytesize:int;  // For structs.
    attributes:[KeyValue];
    documentation:[string];
    /// File that this Object is declared in.
    declaration_file: string;
}
*/
[FlatBufferTable]
public class FlatBufferObject : INamedSchemaElement
{
    [FlatBufferItem(0, Required = true, Key = true)]
    public virtual string Name { get; set; } = string.Empty;

    [FlatBufferItem(1, Required = true, SortedVector = true)]
    public virtual IList<Field> Fields { get; set; } = new List<Field>();

    [FlatBufferItem(2)]
    public virtual bool IsStruct { get; set; }

    [FlatBufferItem(3)]
    public virtual int MinAlign { get; set; }

    // For structs, the size.
    [FlatBufferItem(4)]
    public virtual int ByteSize { get; set; }

    [FlatBufferItem(5)]
    public virtual IIndexedVector<string, KeyValue>? Attributes { get; set; }

    [FlatBufferItem(6)]
    public virtual IList<string>? Documentation { get; set; }

    [FlatBufferItem(7, Required = true)]
    public virtual string DeclarationFile { get; set; } = string.Empty;

    // Not part of flatbuffer schema -- flatsharp extension only.
    [FlatBufferItem(8)]
    public virtual string? OriginalName { get; set; }
}
