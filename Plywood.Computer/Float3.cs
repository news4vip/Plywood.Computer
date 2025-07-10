using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// 3次元ベクトル構造体 (System.Numerics.Vector3をラップ)
/// </summary>
public readonly struct Float3 : IEquatable<Float3>
{
    internal readonly Vector3 value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float3(float x, float y, float z)
    {
        value = new Vector3(x, y, z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float3(Vector3 vector)
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector3(Float3 f) => f.value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Float3(Vector3 v) => new Float3(v);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Float3 other) => value.Equals(other.value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj) => obj is Float3 other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => value.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Float3 left, Float3 right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Float3 left, Float3 right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => value.ToString();
}