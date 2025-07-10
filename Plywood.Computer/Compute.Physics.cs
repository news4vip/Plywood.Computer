using System.Numerics;
using System.Runtime.CompilerServices;

namespace Plywood.Computer;

/// <summary>
/// 物理演算に特化した機能を提供するpartial class
/// </summary>
public static partial class Compute
{
    // 慣性テンソル計算
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateSphereInertia(float mass, float radius)
    {
        var inertia = 0.4f * mass * radius * radius;
        return CreateScale(inertia);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateBoxInertia(float mass, Float3 dimensions)
    {
        var x2 = dimensions.X * dimensions.X;
        var y2 = dimensions.Y * dimensions.Y;
        var z2 = dimensions.Z * dimensions.Z;
        var factor = mass / 12.0f;
        
        return new Float4x4(
            factor * (y2 + z2), 0, 0, 0,
            0, factor * (x2 + z2), 0, 0,
            0, 0, factor * (x2 + y2), 0,
            0, 0, 0, 1
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float4x4 CreateCylinderInertia(float mass, float radius, float height)
    {
        var r2 = radius * radius;
        var h2 = height * height;
        var ixx = mass * (3.0f * r2 + h2) / 12.0f;
        var iyy = mass * r2 / 2.0f;
        var izz = ixx;
        
        return new Float4x4(
            ixx, 0, 0, 0,
            0, iyy, 0, 0,
            0, 0, izz, 0,
            0, 0, 0, 1
        );
    }

    // 衝突検出
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool SphereVsSphere(Float3 center1, float radius1, Float3 center2, float radius2)
    {
        var distanceSq = DistanceSquared(center1, center2);
        var radiusSum = radius1 + radius2;
        return distanceSq <= radiusSum * radiusSum;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool AABBVsAABB(Float3 min1, Float3 max1, Float3 min2, Float3 max2)
    {
        return max1.X >= min2.X && min1.X <= max2.X &&
               max1.Y >= min2.Y && min1.Y <= max2.Y &&
               max1.Z >= min2.Z && min1.Z <= max2.Z;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool SphereVsAABB(Float3 sphereCenter, float radius, Float3 aabbMin, Float3 aabbMax)
    {
        var closest = Clamp(sphereCenter, aabbMin, aabbMax);
        var distanceSq = DistanceSquared(sphereCenter, closest);
        return distanceSq <= radius * radius;
    }

    // レイキャスト
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool RayVsSphere(Float3 rayOrigin, Float3 rayDirection, Float3 sphereCenter, float radius, out float distance)
    {
        var oc = Subtract(rayOrigin, sphereCenter);
        var a = LengthSquared(rayDirection);
        var b = 2.0f * Dot(oc, rayDirection);
        var c = LengthSquared(oc) - radius * radius;
        var discriminant = b * b - 4 * a * c;
        
        if (discriminant < 0)
        {
            distance = 0;
            return false;
        }
        
        var sqrtDiscriminant = Sqrt(discriminant);
        var t1 = (-b - sqrtDiscriminant) / (2 * a);
        var t2 = (-b + sqrtDiscriminant) / (2 * a);
        
        if (t1 > 0)
        {
            distance = t1;
            return true;
        }
        else if (t2 > 0)
        {
            distance = t2;
            return true;
        }
        
        distance = 0;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool RayVsAABB(Float3 rayOrigin, Float3 rayDirection, Float3 aabbMin, Float3 aabbMax, out float distance)
    {
        var invDir = new Float3(1.0f / rayDirection.X, 1.0f / rayDirection.Y, 1.0f / rayDirection.Z);
        var t1 = Multiply(Subtract(aabbMin, rayOrigin), invDir);
        var t2 = Multiply(Subtract(aabbMax, rayOrigin), invDir);
        
        var tmin = Max(Max(Min(t1.X, t2.X), Min(t1.Y, t2.Y)), Min(t1.Z, t2.Z));
        var tmax = Min(Min(Max(t1.X, t2.X), Max(t1.Y, t2.Y)), Max(t1.Z, t2.Z));
        
        if (tmax < 0 || tmin > tmax)
        {
            distance = 0;
            return false;
        }
        
        distance = tmin > 0 ? tmin : tmax;
        return true;
    }

    // 剛体の運動
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 IntegrateVelocity(Float3 velocity, Float3 acceleration, float deltaTime)
    {
        return Add(velocity, Multiply(acceleration, deltaTime));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 IntegratePosition(Float3 position, Float3 velocity, float deltaTime)
    {
        return Add(position, Multiply(velocity, deltaTime));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 IntegrateAngularVelocity(Float3 angularVelocity, Float3 torque, Float4x4 inverseInertia, float deltaTime)
    {
        var angularAcceleration = ToFloat3(Transform(ToFloat4(torque, 0), inverseInertia));
        return Add(angularVelocity, Multiply(angularAcceleration, deltaTime));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Quaternion IntegrateRotation(Quaternion rotation, Float3 angularVelocity, float deltaTime)
    {
        var magnitude = Length(angularVelocity);
        if (magnitude < EPSILON)
            return rotation;
        
        var axis = Divide(angularVelocity, magnitude);
        var angle = magnitude * deltaTime;
        var deltaRotation = Quaternion.CreateFromAxisAngle(axis, angle);
        
        return Quaternion.Multiply(rotation, deltaRotation);
    }

    // 力とトルクの計算
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 CalculateTorque(Float3 position, Float3 force, Float3 centerOfMass)
    {
        var r = Subtract(position, centerOfMass);
        return Cross(r, force);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 CalculateGravityForce(float mass, Float3 gravity = default)
    {
        if (gravity.Equals(default))
            gravity = new Float3(0, -9.81f, 0);
        
        return Multiply(gravity, mass);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 CalculateDragForce(Float3 velocity, float dragCoefficient, float density, float area)
    {
        var speedSq = LengthSquared(velocity);
        if (speedSq < EPSILON)
            return new Float3(0, 0, 0);
        
        var dragMagnitude = 0.5f * density * speedSq * dragCoefficient * area;
        var dragDirection = Negate(Normalize(velocity));
        return Multiply(dragDirection, dragMagnitude);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Float3 CalculateSpringForce(Float3 position1, Float3 position2, float restLength, float springConstant, float dampingConstant, Float3 velocity1, Float3 velocity2)
    {
        var displacement = Subtract(position2, position1);
        var distance = Length(displacement);
        var direction = distance > EPSILON ? Divide(displacement, distance) : new Float3(0, 0, 0);
        
        var springForce = (distance - restLength) * springConstant;
        var relativeVelocity = Subtract(velocity2, velocity1);
        var dampingForce = Dot(relativeVelocity, direction) * dampingConstant;
        
        return Multiply(direction, springForce + dampingForce);
    }
}
