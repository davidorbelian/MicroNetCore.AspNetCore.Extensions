using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MicroNetCore.Collections.Tests
{
    public sealed class TypeListTests
    {
        private interface IInvalidInterface
        {
        }

        private interface IValidInterface
        {
        }

        private abstract class InvalidAbstractClass : IInvalidInterface
        {
        }

        private abstract class ValidAbstractClass : IValidInterface
        {
        }

        private sealed class ClassOne : ValidAbstractClass
        {
        }

        private sealed class ClassTwo : ValidAbstractClass
        {
        }

        [Fact]
        public void InvalidAbstract()
        {
            var argument = new List<Type> {typeof(ClassOne), typeof(ClassTwo)};

            Assert.Throws<TypeInitializationException>(() => new TypeBundle<InvalidAbstractClass>(argument));
        }

        [Fact]
        public void InvalidInterface()
        {
            var argument = new List<Type> {typeof(ClassOne), typeof(ClassTwo)};

            Assert.Throws<TypeInitializationException>(() => new TypeBundle<IInvalidInterface>(argument));
        }

        [Fact]
        public void ValidAbstract()
        {
            var argument = new List<Type> {typeof(ClassOne), typeof(ClassTwo)};

            var bundleAbstract = new TypeBundle<ValidAbstractClass>(argument);

            Assert.Equal(argument.Count, bundleAbstract.Types.Count());
        }

        [Fact]
        public void ValidInterface()
        {
            var argument = new List<Type> {typeof(ClassOne), typeof(ClassTwo)};

            var bundleInterface = new TypeBundle<IValidInterface>(argument);

            Assert.Equal(argument.Count, bundleInterface.Types.Count());
        }
    }
}