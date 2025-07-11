using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

public readonly struct QuatF : IEquatable<QuatF>
{
    public static QuatF Identity => new QuatF(0f, 0f, 0f, 1f);
    
    internal readonly Quaternion value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public QuatF(float x, float y, float z, float w)
    {
        value = new Quaternion(x, y, z, w);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public QuatF(Quaternion quaternion)
    {
        value = quaternion;
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
    public static implicit operator Quaternion(QuatF f) => f.value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator QuatF(Quaternion v) => new QuatF(v);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(QuatF other) => value.Equals(other.value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj) => obj is QuatF other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => value.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(QuatF left, QuatF right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(QuatF left, QuatF right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => value.ToString();
}