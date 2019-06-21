﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enum.Ext.Tests
{
    [TestFixture]
    public class YearlyPriceTests
    {
        [SetUp]
        public void InitYearlyPrice()
        {
            Initialize.InitStaticFields<YearlyPrice>();
        }

        [Test]
        public void QueryByDate_ShouldReturnCorrectEnum()
        {
            DateTime year_2018 = new DateTime(2018, 5, 3);

            YearlyPrice.GetPriceByDate(year_2018).Should().Be(YearlyPrice.Price_2018);
        }

        [Test]
        public void Enum_ShouldHoldCorrectAdditionalInformation()
        {
            var priceEnum = YearlyPrice.Price_2018;

            priceEnum.Price.Should().Be(15.99m);
        }
    }
}