using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyGuide;
using NUnit.Framework;

namespace GalaxyGuideTests
{
    public class RomanConvertorTests
    {
        private RomanConvertor _convertor;

        [SetUp]
        public void Initialize()
        {
            _convertor = new RomanConvertor();
        }   

        [Test]
        public void DoNothing()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void IShouldReturnOne()
        {
            var number = _convertor.Convert("I");
            Assert.AreEqual(number, 1);
        }

        [Test]
        public void IIShouldReturnTwo()
        {
            var number = _convertor.Convert("II");
            Assert.AreEqual(2, number);
        }

        [Test]
        public void IIIShouldReturnThree()
        {
            var number = _convertor.Convert("III");
            Assert.AreEqual(3, number);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IIIIShouldThrowInvalidNumberException()
        {
            var number = _convertor.Convert("IIII");
        }

        [Test]
        public void VShouldReturnFive()
        {
            var number = _convertor.Convert("V");
            Assert.AreEqual(5,number);
        }

        [Test]
        public void VIShouldReturnSix()
        {
            var number = _convertor.Convert("VI");
            Assert.AreEqual(6, number);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VIIIIShouldThrowInvalidNumberException()
        {
            var number = _convertor.Convert("VIIII");
        }

        [Test]
        public void IVShouldReturnFour()
        {
            var number = _convertor.Convert("IV");
            Assert.AreEqual(4, number);
        }

        [Test]
        public void IXShouldReturnNine()
        {
            var number = _convertor.Convert("IX");
            Assert.AreEqual(9, number);
        }

        [Test]
        public void XIXShouldReturnNineteen()
        {
            var number = _convertor.Convert("XIX");
            Assert.AreEqual(19, number);
        }

        [Test]
        public void XXIVShouldReturnTwentyFour()
        {
            var number = _convertor.Convert("XXIV");
            Assert.AreEqual(24, number);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotContainMoreThanOneD()
        {
            var number = _convertor.Convert("DD");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotContainMoreThanOneL()
        {
            var number = _convertor.Convert("LL");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotContainMoreThanOneV()
        {
            var number = _convertor.Convert("VIV");
        }

        [Test]
        public void MCMIIIShouldReturn1903()
        {
            var number = _convertor.Convert("MCMIII");
            Assert.AreEqual(1903, number);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ILShouldThrowException()
        {
            var number = _convertor.Convert("IL");
        }


    }
}
