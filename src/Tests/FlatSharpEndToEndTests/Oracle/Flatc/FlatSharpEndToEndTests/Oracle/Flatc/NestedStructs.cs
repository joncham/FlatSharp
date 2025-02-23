// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace FlatSharpEndToEndTests.Oracle.Flatc
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct NestedStructs : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_10_26(); }
  public static NestedStructs GetRootAsNestedStructs(ByteBuffer _bb) { return GetRootAsNestedStructs(_bb, new NestedStructs()); }
  public static NestedStructs GetRootAsNestedStructs(ByteBuffer _bb, NestedStructs obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public NestedStructs __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FlatSharpEndToEndTests.Oracle.Flatc.OuterStruct? Outer { get { int o = __p.__offset(4); return o != 0 ? (FlatSharpEndToEndTests.Oracle.Flatc.OuterStruct?)(new FlatSharpEndToEndTests.Oracle.Flatc.OuterStruct()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartNestedStructs(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddOuter(FlatBufferBuilder builder, Offset<FlatSharpEndToEndTests.Oracle.Flatc.OuterStruct> OuterOffset) { builder.AddStruct(0, OuterOffset.Value, 0); }
  public static Offset<FlatSharpEndToEndTests.Oracle.Flatc.NestedStructs> EndNestedStructs(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<FlatSharpEndToEndTests.Oracle.Flatc.NestedStructs>(o);
  }
  public NestedStructsT UnPack() {
    var _o = new NestedStructsT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(NestedStructsT _o) {
    _o.Outer = this.Outer.HasValue ? this.Outer.Value.UnPack() : null;
  }
  public static Offset<FlatSharpEndToEndTests.Oracle.Flatc.NestedStructs> Pack(FlatBufferBuilder builder, NestedStructsT _o) {
    if (_o == null) return default(Offset<FlatSharpEndToEndTests.Oracle.Flatc.NestedStructs>);
    StartNestedStructs(builder);
    AddOuter(builder, FlatSharpEndToEndTests.Oracle.Flatc.OuterStruct.Pack(builder, _o.Outer));
    return EndNestedStructs(builder);
  }
}

public class NestedStructsT
{
  public FlatSharpEndToEndTests.Oracle.Flatc.OuterStructT Outer { get; set; }

  public NestedStructsT() {
    this.Outer = new FlatSharpEndToEndTests.Oracle.Flatc.OuterStructT();
  }
}


}
