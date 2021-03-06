﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using ImageMagick;
using Xunit;

namespace Magick.NET.Core.Tests
{
    public partial class RationalTests
    {
        public class TheToStringMethod
        {
            [Fact]
            public void ShouldReturnPositiveInfinityWhenValueIsNan()
            {
                var rational = new Rational(double.NaN);
                Assert.Equal("Indeterminate", rational.ToString());
            }

            [Fact]
            public void ShouldReturnPositiveInfinityWhenValueIsPositiveInfinity()
            {
                var rational = new Rational(double.PositiveInfinity);
                Assert.Equal("PositiveInfinity", rational.ToString());
            }

            [Fact]
            public void ShouldReturnPositiveInfinityWhenValueIsNegativeInfinity()
            {
                var rational = new Rational(double.NegativeInfinity);
                Assert.Equal("PositiveInfinity", rational.ToString());
            }

            [Fact]
            public void ShouldReturnTheCorrectValue()
            {
                var rational = new Rational(0, 1);
                Assert.Equal("0", rational.ToString());

                rational = new Rational(2, 1);
                Assert.Equal("2", rational.ToString());

                rational = new Rational(1, 2);
                Assert.Equal("1/2", rational.ToString());
            }
        }
    }
}
