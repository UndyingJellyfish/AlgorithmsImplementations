using System;

namespace DamsboSoftware.AlgorithmImplementations.Utilities
{
    //https://www.codeproject.com/Articles/8531/Using-generics-for-calculations
    public class GenericCalculator<T> where T : IComparable<T>, new()
    {
        private Calculator<T> Calculator { get; set; }
        
        public GenericCalculator(Calculator<T> calc)
        {
            this.Calculator = calc;
        }

        public static T GetMaxValue()
        {
            object maxValue = default(T);
            TypeCode typeCode = Type.GetTypeCode(typeof(T));
            switch (typeCode)
            {
                case TypeCode.Byte:
                    maxValue = byte.MaxValue;
                    break;
                case TypeCode.Char:
                    maxValue = char.MaxValue;
                    break;
                case TypeCode.DateTime:
                    maxValue = DateTime.MaxValue;
                    break;
                case TypeCode.Decimal:
                    maxValue = decimal.MaxValue;
                    break;
                case TypeCode.Double:
                    maxValue = decimal.MaxValue;
                    break;
                case TypeCode.Int16:
                    maxValue = short.MaxValue;
                    break;
                case TypeCode.Int32:
                    maxValue = int.MaxValue;
                    break;
                case TypeCode.Int64:
                    maxValue = long.MaxValue;
                    break;
                case TypeCode.SByte:
                    maxValue = sbyte.MaxValue;
                    break;
                case TypeCode.Single:
                    maxValue = float.MaxValue;
                    break;
                case TypeCode.UInt16:
                    maxValue = ushort.MaxValue;
                    break;
                case TypeCode.UInt32:
                    maxValue = uint.MaxValue;
                    break;
                case TypeCode.UInt64:
                    maxValue = ulong.MaxValue;
                    break;
                default:
                    maxValue = default(T);//set default value
                    break;
            }

            return (T) maxValue;
        }

        public static T GetMinValue()
        {
            object minValue = default(T);
            TypeCode typeCode = Type.GetTypeCode(typeof(T));
            switch (typeCode)
            {
                case TypeCode.Byte:
                    minValue = byte.MinValue;
                    break;
                case TypeCode.Char:
                    minValue = char.MinValue;
                    break;
                case TypeCode.DateTime:
                    minValue = DateTime.MinValue;
                    break;
                case TypeCode.Decimal:
                    minValue = decimal.MinValue;
                    break;
                case TypeCode.Double:
                    minValue = decimal.MinValue;
                    break;
                case TypeCode.Int16:
                    minValue = short.MinValue;
                    break;
                case TypeCode.Int32:
                    minValue = int.MinValue;
                    break;
                case TypeCode.Int64:
                    minValue = long.MinValue;
                    break;
                case TypeCode.SByte:
                    minValue = sbyte.MinValue;
                    break;
                case TypeCode.Single:
                    minValue = float.MinValue;
                    break;
                case TypeCode.UInt16:
                    minValue = ushort.MinValue;
                    break;
                case TypeCode.UInt32:
                    minValue = uint.MinValue;
                    break;
                case TypeCode.UInt64:
                    minValue = ulong.MinValue;
                    break;
                default:
                    minValue = default(T);//set default value
                    break;
            }

            return (T)minValue;
        }
    }
}