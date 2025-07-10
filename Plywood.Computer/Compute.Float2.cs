using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// Float2（Vector2）に関する演算を提供するpartial class
/// </summary>
public static partial class Compute
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Add(Float2 a, Float2 b) => Vector2.Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Subtract(Float2 a, Float2 b) => Vector2.Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Multiply(Float2 a, Float2 b) => Vector2.Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Multiply(Float2 a, float scalar) => Vector2.Multiply(a, scalar);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Divide(Float2 a, Float2 b) => Vector2.Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Divide(Float2 a, float scalar) => Vector2.Divide(a, scalar);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Negate(Float2 a) => Vector2.Negate(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Dot(Float2 a, Float2 b) => Vector2.Dot(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Length(Float2 a) => a.value.Length();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float LengthSquared(Float2 a) => a.value.LengthSquared();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Normalize(Float2 a) => Vector2.Normalize(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Distance(Float2 a, Float2 b) => Vector2.Distance(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float DistanceSquared(Float2 a, Float2 b) => Vector2.DistanceSquared(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Reflect(Float2 vector, Float2 normal) => Vector2.Reflect(vector, normal);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Lerp(Float2 a, Float2 b, float t) => Vector2.Lerp(a, b, t);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Min(Float2 a, Float2 b) => Vector2.Min(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Max(Float2 a, Float2 b) => Vector2.Max(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Clamp(Float2 value, Float2 min, Float2 max) => Vector2.Clamp(value, min, max);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Abs(Float2 value) => Vector2.Abs(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 SquareRoot(Float2 value) => Vector2.SquareRoot(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Transform(Float2 position, Float4x4 matrix) => Vector2.Transform(position, matrix);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 TransformNormal(Float2 normal, Float4x4 matrix) => Vector2.TransformNormal(normal, matrix);

    // 2D特有の演算
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Cross(Float2 a, Float2 b) => a.X * b.Y - a.Y * b.X;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Perpendicular(Float2 a) => new Float2(-a.Y, a.X);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Angle(Float2 a, Float2 b)
    {
        var dot = Dot(Normalize(a), Normalize(b));
        return Acos(Clamp(dot, -1.0f, 1.0f));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float2 Rotate(Float2 vector, float angle)
    {
        var cos = Cos(angle);
        var sin = Sin(angle);
        return new Float2(
            vector.X * cos - vector.Y * sin,
            vector.X * sin + vector.Y * cos
        );
    }
}
