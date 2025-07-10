using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// Float3（Vector3）に関する演算を提供するpartial class
/// </summary>
public static partial class Compute
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Add(Float3 a, Float3 b) => Vector3.Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Subtract(Float3 a, Float3 b) => Vector3.Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Multiply(Float3 a, Float3 b) => Vector3.Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Multiply(Float3 a, float scalar) => Vector3.Multiply(a, scalar);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Divide(Float3 a, Float3 b) => Vector3.Divide(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Divide(Float3 a, float scalar) => Vector3.Divide(a, scalar);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Negate(Float3 a) => Vector3.Negate(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Dot(Float3 a, Float3 b) => Vector3.Dot(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Cross(Float3 a, Float3 b) => Vector3.Cross(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Length(Float3 a) => a.value.Length();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float LengthSquared(Float3 a) => a.value.LengthSquared();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Normalize(Float3 a) => Vector3.Normalize(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Distance(Float3 a, Float3 b) => Vector3.Distance(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float DistanceSquared(Float3 a, Float3 b) => Vector3.DistanceSquared(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Reflect(Float3 vector, Float3 normal) => Vector3.Reflect(vector, normal);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Lerp(Float3 a, Float3 b, float t) => Vector3.Lerp(a, b, t);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Min(Float3 a, Float3 b) => Vector3.Min(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Max(Float3 a, Float3 b) => Vector3.Max(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Clamp(Float3 value, Float3 min, Float3 max) => Vector3.Clamp(value, min, max);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Abs(Float3 value) => Vector3.Abs(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 SquareRoot(Float3 value) => Vector3.SquareRoot(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Transform(Float3 position, Float4x4 matrix) => Vector3.Transform(position, matrix);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 TransformNormal(Float3 normal, Float4x4 matrix) => Vector3.TransformNormal(normal, matrix);

    // 3D特有の演算
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 ProjectOntoPlane(Float3 vector, Float3 planeNormal)
    {
        var dot = Dot(vector, planeNormal);
        return Subtract(vector, Multiply(planeNormal, dot));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 ProjectOntoVector(Float3 vector, Float3 target)
    {
        var dot = Dot(vector, target);
        var lengthSq = LengthSquared(target);
        return Multiply(target, dot / lengthSq);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Angle(Float3 a, Float3 b)
    {
        var dot = Dot(Normalize(a), Normalize(b));
        return Acos(Clamp(dot, -1.0f, 1.0f));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 Slerp(Float3 a, Float3 b, float t)
    {
        var dot = Dot(Normalize(a), Normalize(b));
        var angle = Acos(Clamp(dot, -1.0f, 1.0f));
        
        if (Abs(angle) < EPSILON)
            return Lerp(a, b, t);
        
        var sinAngle = Sin(angle);
        var factorA = Sin((1.0f - t) * angle) / sinAngle;
        var factorB = Sin(t * angle) / sinAngle;
        
        return Add(Multiply(a, factorA), Multiply(b, factorB));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 RotateAroundAxis(Float3 vector, Float3 axis, float angle)
    {
        var normalizedAxis = Normalize(axis);
        var cosAngle = Cos(angle);
        var sinAngle = Sin(angle);
        
        var dot = Dot(vector, normalizedAxis);
        var cross = Cross(normalizedAxis, vector);
        
        return Add(
            Add(
                Multiply(vector, cosAngle),
                Multiply(cross, sinAngle)
            ),
            Multiply(normalizedAxis, dot * (1.0f - cosAngle))
        );
    }
}
