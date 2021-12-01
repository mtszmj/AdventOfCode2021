using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    public class Tests
    {
        
        [Test]
        public void Test1()
        {
            var result = new Day01Task1().Test();

            result.Should().BeTrue();
        }
    }
}