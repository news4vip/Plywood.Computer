using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// Float4（Vector4）に関する演算を提供するpartial class
/// </summary>
public static partial class Compute
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Add(Float4 a, Float4 b) => Vector4.Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Subtract(Float4 a, Float4 b) => Vector4.Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Multiply(Float4 a, Float4 b) => Vector4.Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Multiply(Float4 a, float scalar) => Vector4.Multiply(a, scalar);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Divide(Float4 a, Float4 b) => Vector4.Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Divide(Float4 a, float scalar) => Vector4.Divide(a, scalar);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Negate(Float4 a) => Vector4.Negate(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Dot(Float4 a, Float4 b) => Vector4.Dot(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Length(Float4 a) => a.value.Length();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float LengthSquared(Float4 a) => a.value.LengthSquared();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Normalize(Float4 a) => Vector4.Normalize(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Distance(Float4 a, Float4 b) => Vector4.Distance(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float DistanceSquared(Float4 a, Float4 b) => Vector4.DistanceSquared(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Lerp(Float4 a, Float4 b, float t) => Vector4.Lerp(a, b, t);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Min(Float4 a, Float4 b) => Vector4.Min(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Max(Float4 a, Float4 b) => Vector4.Max(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Clamp(Float4 value, Float4 min, Float4 max) => Vector4.Clamp(value, min, max);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Abs(Float4 value) => Vector4.Abs(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 SquareRoot(Float4 value) => Vector4.SquareRoot(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 Transform(Float4 vector, Float4x4 matrix) => Vector4.Transform(vector, matrix);

    // 4D特有の演算
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 HomogeneousNormalize(Float4 vector)
    {
        if (Abs(vector.W) < EPSILON)
            return vector;
        
        return new Float4(vector.X / vector.W, vector.Y / vector.W, vector.Z / vector.W, 1.0f);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 ToFloat3(Float4 vector) => new Float3(vector.X, vector.Y, vector.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4 ToFloat4(Float3 vector, float w = 1.0f) => new Float4(vector.X, vector.Y, vector.Z, w);
}
