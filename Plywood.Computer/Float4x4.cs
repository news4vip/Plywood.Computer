using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// 4x4行列構造体 (System.Numerics.Matrix4x4をラップ)
/// </summary>
public readonly struct Float4x4 : IEquatable<Float4x4>
{
    internal readonly Matrix4x4 value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float4x4(Matrix4x4 matrix)
    {
        value = matrix;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Float4x4(
        float m11, float m12, float m13, float m14,
        float m21, float m22, float m23, float m24,
        float m31, float m32, float m33, float m34,
        float m41, float m42, float m43, float m44)
    {
        value = new Matrix4x4(
            m11, m12, m13, m14,
            m21, m22, m23, m24,
            m31, m32, m33, m34,
            m41, m42, m43, m44);
    }

    public float M11
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M11;
    }

    public float M12
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M12;
    }

    public float M13
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M13;
    }

    public float M14
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M14;
    }

    public float M21
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M21;
    }

    public float M22
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M22;
    }

    public float M23
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M23;
    }

    public float M24
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M24;
    }

    public float M31
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M31;
    }

    public float M32
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M32;
    }

    public float M33
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M33;
    }

    public float M34
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M34;
    }

    public float M41
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M41;
    }

    public float M42
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M42;
    }

    public float M43
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M43;
    }

    public float M44
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => value.M44;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Matrix4x4(Float4x4 f) => f.value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Float4x4(Matrix4x4 m) => new Float4x4(m);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Float4x4 other) => value.Equals(other.value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj) => obj is Float4x4 other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => value.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Float4x4 left, Float4x4 right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Float4x4 left, Float4x4 right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => value.ToString();
}