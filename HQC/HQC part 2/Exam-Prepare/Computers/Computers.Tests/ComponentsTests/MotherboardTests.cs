using Computers.Common.Contracts;
using Computers.Common.Components.Motherboard;

using NUnit.Framework;
using Telerik.JustMock;

namespace Computers.Tests.ComponentsTests
{
    [TestFixture]
    public class MotherboardTests
    {
        [Test]
        public void DrawnOnVideoCardShouldCallVideoCardMethorDrawOnce()
        {
            var mockerCpu = Mock.Create<ICpu>();
            var mockedRam = Mock.Create<IRam>();
            var mockedVideo = Mock.Create<IVideoCard>();
            var testMotherboard = new Motherboard(mockerCpu, mockedVideo, mockedRam);
            var testText = "Test";

            testMotherboard.DrawOnVideoCard(testText);

            Mock.Assert(() => mockedVideo.Draw(testText), Occurs.Once());
        }

        [Test]
        public void LoadRamValueShouldCallRamMMethodLoadOnce()
        {
            var mockerCpu = Mock.Create<ICpu>();
            var mockedRam = Mock.Create<IRam>();
            var mockedVideo = Mock.Create<IVideoCard>();
            var testMotherboard = new Motherboard(mockerCpu, mockedVideo, mockedRam);

            testMotherboard.LoadRamValue();

            Mock.Assert(() => mockedRam.LoadValue(), Occurs.Once());
        }

        [Test]
        public void SaveRamValueShouldCallRamMMethodSaveOnce()
        {
            var mockerCpu = Mock.Create<ICpu>();
            var mockedRam = Mock.Create<IRam>();
            var mockedVideo = Mock.Create<IVideoCard>();
            var testMotherboard = new Motherboard(mockerCpu, mockedVideo, mockedRam);
            int testData = 5;

            testMotherboard.SaveRamValue(testData);

            Mock.Assert(() => mockedRam.SaveValue(testData), Occurs.Once());
        }

        [Test]
        public void SquareNumberShouldCallRamMethodLoadCpuMethodSquareNumberAndVideoMethodDraw()
        {
            var mockerCpu = Mock.Create<ICpu>();
            var mockedRam = Mock.Create<IRam>();
            var mockedVideo = Mock.Create<IVideoCard>();
            var testMotherboard = new Motherboard(mockerCpu, mockedVideo, mockedRam);
            int testNumber = 5;
            string squaredText = "Yes";

            Mock.Arrange(() => mockedRam.LoadValue()).Returns(testNumber);
            Mock.Arrange(() => mockerCpu.SquareNumber(testNumber)).Returns(squaredText);

            testMotherboard.SquareNumber();

            Mock.Assert(() => mockedRam.LoadValue(), Occurs.Once());
            Mock.Assert(() => mockerCpu.SquareNumber(testNumber), Occurs.Once());
            Mock.Assert(() => mockedVideo.Draw(squaredText), Occurs.Once());
        }

        [Test]
        public void GetRandomNumberShouldCallCpuGetRandomMethodAndRamSaveValueMethod()
        {
            var mockerCpu = Mock.Create<ICpu>();
            var mockedRam = Mock.Create<IRam>();
            var mockedVideo = Mock.Create<IVideoCard>();
            var testMotherboard = new Motherboard(mockerCpu, mockedVideo, mockedRam);
            int testRandomNum = 1;
            int testMinNum = 1;
            int testMaxNum = 3;

            Mock.Arrange(() => mockerCpu.GetRandoNumber(Arg.IsAny<int>(), Arg.IsAny<int>())).Returns(testRandomNum);

            testMotherboard.GetRandomNumber(testMinNum, testMaxNum);

            Mock.Assert(() => mockerCpu.GetRandoNumber(testMinNum, testMaxNum), Occurs.Once());
            Mock.Assert(() => mockedRam.SaveValue(testRandomNum), Occurs.Once());
        }
    }
}
