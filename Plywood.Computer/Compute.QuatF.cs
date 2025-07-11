using System.Runtime.CompilerServices;

namespace Plywood.Computer;

public partial class Compute
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static QuatF CreateQuatanionFromAxisAngle(Float3 axis, float angle)
    {
        var half = angle * 0.5f;
        var s = Sqrt(1f - half * half);          // cos(half)
        var sin = Sqrt(half * half);             // sin(half)
        var normAxis = Normalize(axis);
        return new QuatF(
            normAxis.X * sin,
            normAxis.Y * sin,
            normAxis.Z * sin,
            s
        );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static QuatF Multiply(QuatF a, QuatF b)
    {
        return new QuatF(
            a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y,
            a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X,
            a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W,
            a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z
        );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Dot(QuatF a, QuatF b)
        => a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Length(QuatF q)
        => Sqrt(Dot(q, q));

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static QuatF Normalize(QuatF q)
    {
        var len = Length(q);
        if (len < EPSILON) return QuatF.Identity;
        var inv = 1f / len;
        return new QuatF(q.X * inv, q.Y * inv, q.Z * inv, q.W * inv);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 MatrixFromQuat(QuatF q)
    {
        // 四元数を行列に変換
        var x2 = q.X + q.X; var y2 = q.Y + q.Y; var  z2 = q.Z + q.Z;
        var xx = q.X * x2; var  yy = q.Y * y2; var  zz = q.Z * z2;
        var xy = q.X * y2; var  xz = q.X * z2; var  yz = q.Y * z2;
        var wx = q.W * x2; var  wy = q.W * y2; var  wz = q.W * z2;

        return new Float4x4(
            1f - (yy + zz), xy - wz,       xz + wy,       0f,
            xy + wz,       1f - (xx + zz), yz - wx,       0f,
            xz - wy,       yz + wx,       1f - (xx + yy), 0f,
            0f,            0f,            0f,             1f
        );
    }
}