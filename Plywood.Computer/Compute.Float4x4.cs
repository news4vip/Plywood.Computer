using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// Float4x4（Matrix4x4）に関する演算を提供するpartial class
/// </summary>
public static partial class Compute
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 Add(Float4x4 a, Float4x4 b) => Matrix4x4.Add(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 Subtract(Float4x4 a, Float4x4 b) => Matrix4x4.Subtract(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 Multiply(Float4x4 a, Float4x4 b) => Matrix4x4.Multiply(a, b);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 Multiply(Float4x4 a, float scalar) => Matrix4x4.Multiply(a, scalar);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 Negate(Float4x4 a) => Matrix4x4.Negate(a);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 Transpose(Float4x4 matrix) => Matrix4x4.Transpose(matrix);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool Invert(Float4x4 matrix, out Float4x4 result)
    {
        var success = Matrix4x4.Invert(matrix, out Matrix4x4 inverted);
        result = inverted;
        return success;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Determinant(Float4x4 matrix) => matrix.value.GetDeterminant();

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 Identity() => Matrix4x4.Identity;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateTranslation(Float3 translation) => Matrix4x4.CreateTranslation(translation);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateTranslation(float x, float y, float z) => Matrix4x4.CreateTranslation(x, y, z);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateScale(Float3 scale) => Matrix4x4.CreateScale(scale);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateScale(float x, float y, float z) => Matrix4x4.CreateScale(x, y, z);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateScale(float scale) => Matrix4x4.CreateScale(scale);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateRotationX(float angle) => Matrix4x4.CreateRotationX(angle);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateRotationY(float angle) => Matrix4x4.CreateRotationY(angle);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateRotationZ(float angle) => Matrix4x4.CreateRotationZ(angle);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateRotationFromAxisAngle(Float3 axis, float angle) => Matrix4x4.CreateFromAxisAngle(axis, angle);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateFromYawPitchRoll(float yaw, float pitch, float roll) => Matrix4x4.CreateFromYawPitchRoll(yaw, pitch, roll);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateLookAt(Float3 cameraPosition, Float3 cameraTarget, Float3 cameraUpVector) => Matrix4x4.CreateLookAt(cameraPosition, cameraTarget, cameraUpVector);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateLookTo(Float3 cameraPosition, Float3 cameraDirection, Float3 cameraUpVector) => Matrix4x4.CreateLookTo(cameraPosition, cameraDirection, cameraUpVector);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance) => Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane) => Matrix4x4.CreateOrthographic(width, height, zNearPlane, zFarPlane);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane) => Matrix4x4.CreateOrthographicOffCenter(left, right, bottom, top, zNearPlane, zFarPlane);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateWorld(Float3 position, Float3 forward, Float3 up) => Matrix4x4.CreateWorld(position, forward, up);

    // 行列の分解
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool Decompose(Float4x4 matrix, out Float3 scale, out Quaternion rotation, out Float3 translation)
    {
        
        var ret = Matrix4x4.Decompose(matrix, out Vector3 s, out rotation, out Vector3 t);
        scale = s;
        translation = t;
        return ret;
    }

    // 変換行列の合成
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateTRS(Float3 translation, Quaternion rotation, Float3 scale)
    {
        var t = CreateTranslation(translation);
        var r = Matrix4x4.CreateFromQuaternion(rotation);
        var s = CreateScale(scale);
        return Multiply(Multiply(s, r), t);
    }

    // 行列の比較
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsIdentity(Float4x4 matrix) => matrix.value.IsIdentity;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool ApproximatelyEqual(Float4x4 a, Float4x4 b, float tolerance = EPSILON)
    {
        return Abs(a.M11 - b.M11) <= tolerance &&
               Abs(a.M12 - b.M12) <= tolerance &&
               Abs(a.M13 - b.M13) <= tolerance &&
               Abs(a.M14 - b.M14) <= tolerance &&
               Abs(a.M21 - b.M21) <= tolerance &&
               Abs(a.M22 - b.M22) <= tolerance &&
               Abs(a.M23 - b.M23) <= tolerance &&
               Abs(a.M24 - b.M24) <= tolerance &&
               Abs(a.M31 - b.M31) <= tolerance &&
               Abs(a.M32 - b.M32) <= tolerance &&
               Abs(a.M33 - b.M33) <= tolerance &&
               Abs(a.M34 - b.M34) <= tolerance &&
               Abs(a.M41 - b.M41) <= tolerance &&
               Abs(a.M42 - b.M42) <= tolerance &&
               Abs(a.M43 - b.M43) <= tolerance &&
               Abs(a.M44 - b.M44) <= tolerance;
    }

    // 行列の情報取得
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 GetTranslation(Float4x4 matrix) => matrix.value.Translation;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 GetRight(Float4x4 matrix) => new Float3(matrix.M11, matrix.M12, matrix.M13);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 GetUp(Float4x4 matrix) => new Float3(matrix.M21, matrix.M22, matrix.M23);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 GetForward(Float4x4 matrix) => new Float3(-matrix.M31, -matrix.M32, -matrix.M33);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 GetScale(Float4x4 matrix)
    {
        var right = GetRight(matrix);
        var up = GetUp(matrix);
        var forward = new Float3(matrix.M31, matrix.M32, matrix.M33);
        
        return new Float3(Length(right), Length(up), Length(forward));
    }
}
