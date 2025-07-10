namespace Plywood.Computer;

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// 数学演算を提供するComputeクラス
/// </summary>
public static partial class Compute
{
    // 基本的な数学定数
    public const float PI = MathF.PI;
    public const float E = MathF.E;
    public const float DEG2RAD = PI / 180.0f;
    public const float RAD2DEG = 180.0f / PI;
    public const float EPSILON = 1e-6f;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Abs(float value) => MathF.Abs(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Sqrt(float value) => MathF.Sqrt(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Sin(float value) => MathF.Sin(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Cos(float value) => MathF.Cos(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Tan(float value) => MathF.Tan(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Asin(float value) => MathF.Asin(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Acos(float value) => MathF.Acos(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Atan(float value) => MathF.Atan(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Atan2(float y, float x) => MathF.Atan2(y, x);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Pow(float value, float exponent) => MathF.Pow(value, exponent);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Exp(float value) => MathF.Exp(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Log(float value) => MathF.Log(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Log10(float value) => MathF.Log10(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Floor(float value) => MathF.Floor(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Ceiling(float value) => MathF.Ceiling(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Round(float value) => MathF.Round(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Min(float a, float b) => MathF.Min(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Max(float a, float b) => MathF.Max(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Clamp(float value, float min, float max) => MathF.Max(min, MathF.Min(max, value));

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Lerp(float a, float b, float t) => a + (b - a) * t;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Smoothstep(float edge0, float edge1, float x)
    {
        var t = Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
        return t * t * (3.0f - 2.0f * t);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsNaN(float value) => float.IsNaN(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsInfinity(float value) => float.IsInfinity(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsFinite(float value) => float.IsFinite(value);
}
