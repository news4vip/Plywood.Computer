using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// 4次元ベクトル構造体 (System.Numerics.Vector4をラップ)
/// </summary>
public readonly struct Float4 : IEquatable<Float4>
{
    internal readonly Vector4 value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float4(float x, float y, float z, float w)
    {
        value = new Vector4(x, y, z, w);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float4(Vector4 vector)
    {
        value = vector;
    }

    public float X
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.X;
    }

    public float Y
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.Y;
    }

    public float Z
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.Z;
    }

    public float W
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.W;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector4(Float4 f) => f.value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Float4(Vector4 v) => new Float4(v);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Float4 other) => value.Equals(other.value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj) => obj is Float4 other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => value.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Float4 left, Float4 right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Float4 left, Float4 right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => value.ToString();
}