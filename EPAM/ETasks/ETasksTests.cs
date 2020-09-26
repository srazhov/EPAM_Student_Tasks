//-----------------------------------------------------------------------
// <copyright file="ETasksTests.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace EPAM.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests of ETasks' methods
    /// </summary>
    [TestFixture]
    public class ETasksTests
    {
        /// <summary>
        /// Test of FindNextBiggerNumber
        /// </summary>
        /// <param name="value">given value</param>
        /// <returns>Next big number that contains digits of the given value</returns>
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(1233, ExpectedResult = 1323)]
        public int FindNextBiggerNumber_thatContainsOnlyGivenDigits(int value)
        {
            return ETasks.FindNextBiggerNumber(value);
        }
    }
}