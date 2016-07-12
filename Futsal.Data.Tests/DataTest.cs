using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Futsal.Data.Tests
{
    public class DataTest
    {
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        [Fact]
        public void ItIsOdd()
        {
            Assert.True(IsOdd(3));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

    }
}
