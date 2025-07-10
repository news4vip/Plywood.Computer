using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// 2次元ベクトル構造体 (System.Numerics.Vector2をラップ)
/// </summary>
public readonly struct Float2 : IEquatable<Float2>
{
    internal readonly Vector2 value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float2(float x, float y)
    {
        value = new Vector2(x, y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float2(Vector2 vector)
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector2(Float2 f) => f.value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Float2(Vector2 v) => new Float2(v);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Float2 other) => value.Equals(other.value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj) => obj is Float2 other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => value.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Float2 left, Float2 right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Float2 left, Float2 right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => value.ToString();
}