using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.xUnitTests
{
    public class StackXTests
    {
        public Fundamentals.Stack<string> _stack;
        public StackXTests()
        {
            _stack = new Fundamentals.Stack<string>();
        }
        [Fact]
        public void Push_ObjectIsNull_ThrowArgumentNullException()
        {
            Action func = () => _stack.Push(null);

            func.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Push_ObjectCorrect_CountListIsOne()
        {
            _stack.Push("Ivan");

            _stack.Count.Should().Be(1);
        }

        [Fact]
        public void Pop_ListCountisNull_ThrowInvalidOperationException()
        {
            Func<string> func = () => _stack.Pop();

            func.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void Pop_AddObjectsToTheStack_ReturnObjectOnTheTopAndRemoveItFromTheStack()
        {
            _stack.Push("Max");
            _stack.Push("Oleg");
            _stack.Push("Ivan");
            var result = _stack.Pop();

            using (new AssertionScope())
            {
                result.Should().Be("Ivan");
                _stack.Count.Should().Be(2);
            }
        }
        [Fact]
        public void Peek_ListCountisNull_ThrowInvalidOperationException()
        {
            Func<string> func = () => _stack.Peek();

            func.Should().ThrowExactly<InvalidOperationException>();
        }
        [Fact]
        public void Peek_AddObjectsToStack_ReturnOnTheTopAndDoesNotRemoveIt()
        {
            _stack.Push("Max");
            _stack.Push("Oleg");
            _stack.Push("Ivan");
            var result = _stack.Peek();

            using (new AssertionScope())
            {
                result.Should().Be("Ivan");
                _stack.Count.Should().Be(3);
            }
        }
    }
}
