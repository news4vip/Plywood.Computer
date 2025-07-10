namespace Plywood.Computer.Benchmarks;

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net80)]
public class MathLibraryBenchmark
{
    private const int IterationCount = 100000;
    private Float2[] float2Array;
    private Float3[] float3Array;
    private Float4[] float4Array;
    private Float4x4[] matrixArray;
    private Vector2[] vector2Array;
    private Vector3[] vector3Array;
    private Vector4[] vector4Array;
    private Matrix4x4[] matrix4x4Array;
    private Random random;

    [GlobalSetup]
    public void Setup()
    {
        random = new Random(42);
        
        // float2配列の初期化
        float2Array = new Float2[IterationCount];
        vector2Array = new Vector2[IterationCount];
        for (int i = 0; i < IterationCount; i++)
        {
            var x = (float)random.NextDouble();
            var y = (float)random.NextDouble();
            float2Array[i] = new Float2(x, y);
            vector2Array[i] = new Vector2(x, y);
        }
        
        // float3配列の初期化
        float3Array = new Float3[IterationCount];
        vector3Array = new Vector3[IterationCount];
        for (int i = 0; i < IterationCount; i++)
        {
            var x = (float)random.NextDouble();
            var y = (float)random.NextDouble();
            var z = (float)random.NextDouble();
            float3Array[i] = new Float3(x, y, z);
            vector3Array[i] = new Vector3(x, y, z);
        }
        
        // float4配列の初期化
        float4Array = new Float4[IterationCount];
        vector4Array = new Vector4[IterationCount];
        for (int i = 0; i < IterationCount; i++)
        {
            var x = (float)random.NextDouble();
            var y = (float)random.NextDouble();
            var z = (float)random.NextDouble();
            var w = (float)random.NextDouble();
            float4Array[i] = new Float4(x, y, z, w);
            vector4Array[i] = new Vector4(x, y, z, w);
        }
        
        // float4x4配列の初期化
        matrixArray = new Float4x4[IterationCount];
        matrix4x4Array = new Matrix4x4[IterationCount];
        for (int i = 0; i < IterationCount; i++)
        {
            var matrix = Matrix4x4.CreateRotationX((float)random.NextDouble()) *
                        Matrix4x4.CreateRotationY((float)random.NextDouble()) *
                        Matrix4x4.CreateRotationZ((float)random.NextDouble()) *
                        Matrix4x4.CreateTranslation((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
            matrixArray[i] = matrix;
            matrix4x4Array[i] = matrix;
        }
    }

    [Benchmark]
    public float Float2_Length_Wrapped()
    {
        float sum = 0;
        for (int i = 0; i < IterationCount; i++)
        {
            sum += Compute.Length(float2Array[i]);
        }
        return sum;
    }

    [Benchmark]
    public float Vector2_Length_Direct()
    {
        float sum = 0;
        for (int i = 0; i < IterationCount; i++)
        {
            sum += vector2Array[i].Length();
        }
        return sum;
    }

    [Benchmark]
    public float Float3_Length_Wrapped()
    {
        float sum = 0;
        for (int i = 0; i < IterationCount; i++)
        {
            sum += Compute.Length(float3Array[i]);
        }
        return sum;
    }

    [Benchmark]
    public float Vector3_Length_Direct()
    {
        float sum = 0;
        for (int i = 0; i < IterationCount; i++)
        {
            sum += vector3Array[i].Length();
        }
        return sum;
    }

    [Benchmark]
    public float Float4_Length_Wrapped()
    {
        float sum = 0;
        for (int i = 0; i < IterationCount; i++)
        {
            sum += Compute.Length(float4Array[i]);
        }
        return sum;
    }

    [Benchmark]
    public float Vector4_Length_Direct()
    {
        float sum = 0;
        for (int i = 0; i < IterationCount; i++)
        {
            sum += vector4Array[i].Length();
        }
        return sum;
    }

    [Benchmark]
    public Float3 Float3_Cross_Wrapped()
    {
        Float3 result = new Float3(0, 0, 0);
        for (int i = 0; i < IterationCount - 1; i++)
        {
            result = Compute.Cross(float3Array[i], float3Array[i + 1]);
        }
        return result;
    }

    [Benchmark]
    public Vector3 Vector3_Cross_Direct()
    {
        Vector3 result = Vector3.Zero;
        for (int i = 0; i < IterationCount - 1; i++)
        {
            result = Vector3.Cross(vector3Array[i], vector3Array[i + 1]);
        }
        return result;
    }

    [Benchmark]
    public Float4x4 Matrix_Multiply_Wrapped()
    {
        Float4x4 result = Compute.Identity();
        for (int i = 0; i < IterationCount - 1; i++)
        {
            result = Compute.Multiply(result, matrixArray[i]);
        }
        return result;
    }

    [Benchmark]
    public Matrix4x4 Matrix_Multiply_Direct()
    {
        Matrix4x4 result = Matrix4x4.Identity;
        for (int i = 0; i < IterationCount - 1; i++)
        {
            result = Matrix4x4.Multiply(result, matrix4x4Array[i]);
        }
        return result;
    }

    [Benchmark]
    public Float3 Vector3_Normalize_Wrapped()
    {
        Float3 result = new Float3(0, 0, 0);
        for (int i = 0; i < IterationCount; i++)
        {
            result = Compute.Normalize(float3Array[i]);
        }
        return result;
    }

    [Benchmark]
    public Vector3 Vector3_Normalize_Direct()
    {
        Vector3 result = Vector3.Zero;
        for (int i = 0; i < IterationCount; i++)
        {
            result = Vector3.Normalize(vector3Array[i]);
        }
        return result;
    }

    [Benchmark]
    public Float3 Physics_IntegrateVelocity()
    {
        Float3 velocity = new Float3(0, 0, 0);
        Float3 acceleration = new Float3(0, -9.81f, 0);
        float deltaTime = 0.016f;
        
        for (int i = 0; i < IterationCount; i++)
        {
            velocity = Compute.IntegrateVelocity(velocity, acceleration, deltaTime);
        }
        
        return velocity;
    }

    [Benchmark]
    public Float3 Physics_IntegratePosition()
    {
        Float3 position = new Float3(0, 0, 0);
        Float3 velocity = new Float3(10, 0, 0);
        float deltaTime = 0.016f;
        
        for (int i = 0; i < IterationCount; i++)
        {
            position = Compute.IntegratePosition(position, velocity, deltaTime);
        }
        
        return position;
    }

    [Benchmark]
    public bool Collision_SphereVsSphere()
    {
        bool result = false;
        Float3 center1 = new Float3(0, 0, 0);
        Float3 center2 = new Float3(1, 0, 0);
        float radius1 = 0.5f;
        float radius2 = 0.6f;
        
        for (int i = 0; i < IterationCount; i++)
        {
            center2 = new Float3(i * 0.001f, 0, 0);
            result = Compute.SphereVsSphere(center1, radius1, center2, radius2);
        }
        
        return result;
    }

    [Benchmark]
    public Float3 Matrix_Transform_Wrapped()
    {
        Float3 result = new Float3(0, 0, 0);
        Float3 vector = new Float3(1, 2, 3);
        
        for (int i = 0; i < IterationCount; i++)
        {
            result = Compute.Transform(vector, matrixArray[i % matrixArray.Length]);
        }
        
        return result;
    }

    [Benchmark]
    public Vector3 Matrix_Transform_Direct()
    {
        Vector3 result = Vector3.Zero;
        Vector3 vector = new Vector3(1, 2, 3);
        
        for (int i = 0; i < IterationCount; i++)
        {
            result = Vector3.Transform(vector, matrix4x4Array[i % matrix4x4Array.Length]);
        }
        
        return result;
    }
}
