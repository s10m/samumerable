using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Samumerable.Tests
{
    public class SamFirstOrDefault
    {
        [Fact]
        public void SingleIntArray()
        {
            Util utils = new Util();
            //  Generate one 1.
            int singleElement = 1;
            IEnumerable<int> someInts = utils.IntArray(1, i => singleElement);
            someInts.SamFirstOrDefault().Should().Be(singleElement, "the only element in the array is {0}", singleElement);
            someInts.SamFirstOrDefault().Should().Be(someInts.FirstOrDefault(), "the reference implementation says so");
        }

        [Fact]
        public void ManyIntsInArray()
        {
            Util utils = new Util();
            //  Generate the naturals
            IEnumerable<int> someInts = utils.IntArray(5, i => i + 1);
            someInts.SamFirstOrDefault().Should().Be(1, "the first natural number is 1");
            someInts.SamFirstOrDefault().Should().Be(someInts.FirstOrDefault(), "the reference implementation says so");
        }

        [Fact]
        public void NoIntsInArray()
        {
            Util utils = new Util();
            //  Generate no elements
            IEnumerable<int> someInts = utils.IntArray(0, i => 1);
            someInts.SamFirstOrDefault().Should().Be(0, "the default int value is 0");
            someInts.SamFirstOrDefault().Should().Be(someInts.FirstOrDefault(), "the reference implementation says so");
        }

        [Fact]
        public void SingleObjectArray()
        {
            Util utils = new Util();
            //  Generate one element
            ARefType someType = new ARefType(1);
            IEnumerable<ARefType> someObjects = utils.ClassArray(1, i => someType);
            someObjects.SamFirstOrDefault().Should().Be(someType, "the only element in the array is an instance");
            someObjects.SamFirstOrDefault().Should().Be(someObjects.FirstOrDefault(), "the reference implementation says so");
        }

        [Fact]
        public void ManyObjectsArray()
        {
            Util utils = new Util();
            //  Generate some elements
            IEnumerable<ARefType> someObjects = utils.ClassArray(5, i => new ARefType(i+1));
            someObjects.SamFirstOrDefault().Should().Be(new ARefType(1), "the first element in the array has a reference of 1");
            someObjects.SamFirstOrDefault().Should().Be(someObjects.FirstOrDefault(), "the reference implementation says so");
        }

        [Fact]
        public void NoObjectsInArray()
        {
            Util utils = new Util();
            //  Generate no elements
            IEnumerable<ARefType> someObjects = utils.ClassArray(0, i => new ARefType(-1));
            someObjects.SamFirstOrDefault().Should().Be(null, "the default reference value is null");
            someObjects.SamFirstOrDefault().Should().Be(someObjects.FirstOrDefault(), "the reference implementation says so");
        }
    }
}
