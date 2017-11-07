using System;
using System.Globalization;

namespace IAmMamba.DotNetHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static T To<T>(this object obj, IFormatProvider formatProvider = null)
        {
            switch (obj)
            {
                case T toT:
                    return toT;
                case IConvertible conv:
                    return To<T>(conv, formatProvider);
            }

            return default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conv"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        private static T To<T>(IConvertible conv, IFormatProvider formatProvider = null)
        {
            formatProvider = formatProvider ?? CultureInfo.CurrentCulture;
            switch (typeof(T).Name)
            {
                case TypeNames.BOOLEAN:
                    return conv.ToBoolean(formatProvider).To<T>();
                case TypeNames.BYTE:
                    return conv.ToByte(formatProvider).To<T>();
                case TypeNames.CHAR:
                    return conv.ToChar(formatProvider).To<T>();
                case TypeNames.DATE_TIME:
                    return conv.ToDateTime(formatProvider).To<T>();
                case TypeNames.DECIMAL:
                    return conv.ToDecimal(formatProvider).To<T>();
                case TypeNames.DOUBLE:
                    return conv.ToDouble(formatProvider).To<T>();
                case TypeNames.INT16:
                    return conv.ToInt16(formatProvider).To<T>();
                case TypeNames.INT32:
                    return conv.ToInt32(formatProvider).To<T>();
                case TypeNames.INT64:
                    return conv.ToInt64(formatProvider).To<T>();
                case TypeNames.S_BYTE:
                    return conv.ToSByte(formatProvider).To<T>();
                case TypeNames.SINGLE:
                    return conv.ToSingle(formatProvider).To<T>();
                case TypeNames.STRING:
                    return conv.ToString(formatProvider).To<T>();
                case TypeNames.U_INT16:
                    return conv.ToUInt16(formatProvider).To<T>();
                case TypeNames.U_INT32:
                    return conv.ToUInt32(formatProvider).To<T>();
                case TypeNames.U_INT64:
                    return conv.ToUInt64(formatProvider).To<T>();
                default:
                    return default(T);
            }
        }
    }
}