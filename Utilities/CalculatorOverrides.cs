using Utilities;

//https://www.codeproject.com/Articles/8531/Using-generics-for-calculations
namespace Utilities
{
    public abstract class Calculator<T>
    {
        public abstract T Add(T a, T b);
        public abstract T Sub(T a, T b);
        public abstract T Mult(T a, T b);
        public abstract T Div(T a, T b);
    }
}

// All Value types has to implement the abstract Calculator, else you won't get a result
// Value type overview: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/value-types

namespace SByte
{
    public class Calculator : Calculator<sbyte>
    {
        public override sbyte Add(sbyte a, sbyte b)
        {
            return (sbyte)(a + b);
        }
        public override sbyte Sub(sbyte a, sbyte b)
        {
            return (sbyte)(a - b);
        }
        public override sbyte Mult(sbyte a, sbyte b)
        {
            return (sbyte)(a * b);
        }
        public override sbyte Div(sbyte a, sbyte b)
        {
            return (sbyte)(a / b);
        }
    }
}

namespace Byte
{
    public class Calculator : Calculator<byte>
    {
        public override byte Add(byte a, byte b)
        {
            return (byte)(a + b);
        }
        public override byte Sub(byte a, byte b)
        {
            return (byte)(a - b);
        }
        public override byte Mult(byte a, byte b)
        {
            return (byte)(a * b);
        }
        public override byte Div(byte a, byte b)
        {
            return (byte)(a / b);
        }
    }
}

namespace Char
{
    public class Calculator : Calculator<char>
    {
        public override char Add(char a, char b)
        {
            return (char)(a + b);
        }
        public override char Sub(char a, char b)
        {
            return (char)(a - b);
        }
        public override char Mult(char a, char b)
        {
            return (char)(a * b);
        }
        public override char Div(char a, char b)
        {
            return (char)(a / b);
        }
    }
}

namespace Short
{
    public class Calculator : Calculator<short>
    {
        public override short Add(short a, short b)
        {
            return (short)(a + b);
        }
        public override short Sub(short a, short b)
        {
            return (short)(a - b);
        }
        public override short Mult(short a, short b)
        {
            return (short)(a * b);
        }
        public override short Div(short a, short b)
        {
            return (short)(a / b);
        }
    }
}

namespace UShort
{
    public class Calculator : Calculator<ushort>
    {
        public override ushort Add(ushort a, ushort b)
        {
            return (ushort)(a + b);
        }
        public override ushort Sub(ushort a, ushort b)
        {
            return (ushort)(a - b);
        }
        public override ushort Mult(ushort a, ushort b)
        {
            return (ushort)(a * b);
        }
        public override ushort Div(ushort a, ushort b)
        {
            return (ushort)(a / b);
        }
    }
}

namespace Int32
{
    public class Calculator : Calculator<int>
    {
        public override int Add(int a, int b)
        {
            return (int)(a + b);
        }
        public override int Sub(int a, int b)
        {
            return (int)(a - b);
        }
        public override int Mult(int a, int b)
        {
            return (int)(a * b);
        }
        public override int Div(int a, int b)
        {
            return (int)(a / b);
        }
    }
}

namespace UInt
{
    public class Calculator : Calculator<uint>
    {
        public override uint Add(uint a, uint b)
        {
            return (uint)(a + b);
        }
        public override uint Sub(uint a, uint b)
        {
            return (uint)(a - b);
        }
        public override uint Mult(uint a, uint b)
        {
            return (uint)(a * b);
        }
        public override uint Div(uint a, uint b)
        {
            return (uint)(a / b);
        }
    }
}

namespace Long
{
    public class Calculator : Calculator<long>
    {
        public override long Add(long a, long b)
        {
            return (long)(a + b);
        }
        public override long Sub(long a, long b)
        {
            return (long)(a - b);
        }
        public override long Mult(long a, long b)
        {
            return (long)(a * b);
        }
        public override long Div(long a, long b)
        {
            return (long)(a / b);
        }
    }
}

namespace ULong
{
    public class Calculator : Calculator<ulong>
    {
        public override ulong Add(ulong a, ulong b)
        {
            return (ulong)(a + b);
        }
        public override ulong Sub(ulong a, ulong b)
        {
            return (ulong)(a - b);
        }
        public override ulong Mult(ulong a, ulong b)
        {
            return (ulong)(a * b);
        }
        public override ulong Div(ulong a, ulong b)
        {
            return (ulong)(a / b);
        }
    }
}

namespace Float
{
    public class Calculator : Calculator<float>
    {
        public override float Add(float a, float b)
        {
            return (float)(a + b);
        }
        public override float Sub(float a, float b)
        {
            return (float)(a - b);
        }
        public override float Mult(float a, float b)
        {
            return (float)(a * b);
        }
        public override float Div(float a, float b)
        {
            return (float)(a / b);
        }
    }
}

namespace Double
{
    public class Calculator : Calculator<double>
    {
        public override double Add(double a, double b)
        {
            return (double)(a + b);
        }
        public override double Sub(double a, double b)
        {
            return (double)(a - b);
        }
        public override double Mult(double a, double b)
        {
            return (double)(a * b);
        }
        public override double Div(double a, double b)
        {
            return (double)(a / b);
        }
    }
}

namespace Decimal
{
    public class Calculator : Calculator<decimal>
    {
        public override decimal Add(decimal a, decimal b)
        {
            return (decimal)(a + b);
        }
        public override decimal Sub(decimal a, decimal b)
        {
            return (decimal)(a - b);
        }
        public override decimal Mult(decimal a, decimal b)
        {
            return (decimal)(a * b);
        }
        public override decimal Div(decimal a, decimal b)
        {
            return (decimal)(a / b);
        }
    }
}
