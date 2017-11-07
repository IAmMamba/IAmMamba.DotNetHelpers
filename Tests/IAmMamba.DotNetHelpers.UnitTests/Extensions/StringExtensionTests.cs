using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IAmMamba.DotNetHelpers.UnitTests.Extensions
{
    internal static class Helpers
    {
        internal static string TestLog(this Tuple<string, int, int, bool> tuple)
        {
            return $"{tuple.Item1}, {tuple.Item2}, {tuple.Item3}, {tuple.Item4}";
        }
    }
    internal class TestInterface : IConvertible {
        /// <inheritdoc />
        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void Check()
        {
            List<Tuple<string, int, int, bool>> tests = new List<Tuple<string, int, int, bool>>()
            {
                new Tuple<string, int, int, bool>(string.Empty, 0, 0, true)
                , new Tuple<string, int, int, bool>(null, 0,0,false)
                , new Tuple<string, int, int, bool>(null, 2,0,false)
                , new Tuple<string, int, int, bool>(null, 1,1,false)
                , new Tuple<string, int, int, bool>(null, 0,2,false)
                , new Tuple<string, int, int, bool>("A", 0,0,true)
                , new Tuple<string, int, int, bool>("A", 2,0,false)
                , new Tuple<string, int, int, bool>("A", 1,1,true)
                , new Tuple<string, int, int, bool>("A", 0,2,true)
                , new Tuple<string, int, int, bool>("ABC", 0,2,false)
                , new Tuple<string, int, int, bool>("ABC", 1,2,false)
            };

            foreach (var t in tests)
            {
                bool result = StringExtensions.Check(t.Item1, t.Item2, t.Item3);
                Assert.AreEqual(t.Item4, result, t.TestLog());
            }
        }

        [TestMethod]
        public void Left()
        {
            List<Tuple<string, string, int>> tests = new List<Tuple<string, string, int>>(){
                new Tuple<string, string, int>("", "", 3)
                , new Tuple<string, string, int>(null, null,3)
                , new Tuple<string, string, int>("a", "a",3)
                , new Tuple<string, string, int>("ab", "ab",3)
                , new Tuple<string, string, int>("abc", "abc",3)
                , new Tuple<string, string, int>("abcd", "abc", 3)
                , new Tuple<string, string, int>("abcdefga lkdf ;lkasjdf ", "abcd", 4)
            };

            foreach (var t in tests)
            {
                string result = t.Item1.Left(t.Item3);
                Assert.AreEqual(t.Item2, result);
            }
        }

        [TestMethod]
        public void Right()
        {
            List<Tuple<string, string, int>> tests = new List<Tuple<string, string, int>>(){
                  new Tuple<string, string, int>("", "", 3)
                , new Tuple<string, string, int>(null, null,3)
                , new Tuple<string, string, int>("a", "a",3)
                , new Tuple<string, string, int>("ab", "ab",3)
                , new Tuple<string, string, int>("abc", "abc",3)
                , new Tuple<string, string, int>("abcd", "bcd", 3)
                , new Tuple<string, string, int>("abcdefga lkdf ;lkasjdf ", "jdf ", 4)
            };

            foreach (var t in tests)
            {
                string result = t.Item1.Right(t.Item3);
                Assert.AreEqual(t.Item2, result);
            }
        }

        [TestMethod]
        public void LettersOnly()
        {
            List<Tuple<string, string>> tests = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("ASDF", "ASDF")
                , new Tuple<string, string>("AS3dF", "ASdF")
                , new Tuple<string, string>("A!SDF", "ASDF")
                , new Tuple<string, string>("AS%#$@DF", "ASDF")
                , new Tuple<string, string>("ASasadfDF", "ASasadfDF")
                , new Tuple<string, string>("", "")
                , new Tuple<string, string>(null, null)
            };

            foreach (var t in tests)
            {
                string result = t.Item1.LettersOnly();
                Assert.AreEqual(t.Item2, result);
            }
        }
    }

    [TestClass]
    public class ObjectExtensionTests
    {
        [TestMethod]
        public void To()
        {
            object intObject = (object) 1;
            
            int i = intObject.To<int>();

            Assert.AreEqual(1, i);

            object stringObject = "This";
            string s = stringObject.To<string>();
            Assert.AreEqual(stringObject.ToString(), s);

            object doubleObject = (double) 2;
            double d = doubleObject.To<double>();
            Assert.AreEqual((double) 2, d);

            int di = doubleObject.To<int>();
            Assert.AreEqual(2, di);



        }

        [TestMethod]
        public void As()
        {
            
        }
    }
}
