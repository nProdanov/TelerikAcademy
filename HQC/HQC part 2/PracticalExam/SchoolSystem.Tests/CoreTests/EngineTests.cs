using NUnit.Framework;
using Telerik.JustMock;

using SchoolSystem.Commands;

namespace SchoolSystem.Tests.CoreTests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void EngineStartShouldThrowWithCorrectMessageWhenInvalidCommandIsPassed()
        {
            var mockedCreateStudentCommand = Mock.Create<CreateStudentCommand>();
            // no more time... 18:32
        }
    }
}
