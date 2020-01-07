using AbusedCSharp.Extensions.TaskExtensions;
using System;
using System.Threading.Tasks;
using Xunit;
using static Extensions.UnitTests.TestExtensions.BddExtensions;

namespace Extensions.UnitTests.TaskExtensions
{
    public class AwaitTupleExtensionsTests
    {
        [Fact]
        public async Task A_tuple_of_two_tasks_can_be_awaited()
        {
            Int32 expectedNumber = 5;
            String expectedText = "6";

            await Given(a_tuple_of_two_tasks)
                    .When(the_tuple_is_awaited)
                    .Then(it_returns_expected_values);

            // ReSharper disable InconsistentNaming
            (Task<Int32>, Task<String>) a_tuple_of_two_tasks() => (Task.FromResult(expectedNumber), Task.FromResult(expectedText));
            async Task<(Int32, String)> the_tuple_is_awaited((Task<Int32>, Task<String>) tuple) => await tuple;

            void it_returns_expected_values((Int32 number, String text) tuple)
            {
                Assert.Equal(tuple.number, expectedNumber);
                Assert.Same(tuple.text, expectedText);
            }
            // ReSharper restore InconsistentNaming
        }
    }
}
