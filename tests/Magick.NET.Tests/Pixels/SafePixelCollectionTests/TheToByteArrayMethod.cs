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

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class SafePixelCollectionTests
    {
        public class TheToByteArrayMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenXTooLow()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentOutOfRangeException>("x", () =>
                        {
                            pixels.ToByteArray(-1, 0, 1, 1, "RGB");
                        });
                    }
                }
            }

            [Fact]
            public void ShouldReturnPixelsWhenAreaIsCorrect()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var values = pixels.ToByteArray(60, 60, 63, 58, "RGBA");
                        int length = 63 * 58 * 4;

                        Assert.Equal(length, values.Length);
                    }
                }
            }

            [Fact]
            public void ShouldReturnPixelsWhenAreaIsCorrectAndMappingIsEnum()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var values = pixels.ToByteArray(60, 60, 63, 58, PixelMapping.RGBA);
                        int length = 63 * 58 * 4;

                        Assert.Equal(length, values.Length);
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenGeometryIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentNullException>("geometry", () =>
                        {
                            pixels.ToByteArray(null, "RGB");
                        });
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenGeometryIsNullAndMappingIsEnum()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentNullException>("geometry", () =>
                        {
                            pixels.ToByteArray(null, PixelMapping.RGB);
                        });
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenGeometryIsSpecifiedAndMappingIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentNullException>("mapping", () =>
                        {
                            pixels.ToByteArray(new MagickGeometry(1, 2, 3, 4), null);
                        });
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenGeometryIsSpecifiedAndMappingIsEmpty()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentException>("mapping", () =>
                        {
                            pixels.ToByteArray(new MagickGeometry(1, 2, 3, 4), string.Empty);
                        });
                    }
                }
            }

            [Fact]
            public void ShouldReturnArrayWhenGeometryIsCorrect()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var values = pixels.ToByteArray(new MagickGeometry(10, 10, 113, 108), "RG");
                        int length = 113 * 108 * 2;

                        Assert.Equal(length, values.Length);
                    }
                }
            }

            [Fact]
            public void ShouldReturnArrayWhenGeometryIsCorrectAndMappingIsEnum()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var values = pixels.ToByteArray(new MagickGeometry(10, 10, 113, 108), PixelMapping.RGB);
                        int length = 113 * 108 * 3;

                        Assert.Equal(length, values.Length);
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenMappingIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentNullException>("mapping", () =>
                        {
                            pixels.ToByteArray(null);
                        });
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenMappingIsEmpty()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentException>("mapping", () =>
                        {
                            pixels.ToByteArray(string.Empty);
                        });
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenMappingIsInvalid()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<MagickOptionErrorException>(() =>
                        {
                            pixels.ToByteArray("FOO");
                        });
                    }
                }
            }

            [Fact]
            public void ShouldReturnArrayWhenTwoChannelsAreSupplied()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var values = pixels.ToByteArray("RG");
                        int length = image.Width * image.Height * 2;

                        Assert.Equal(length, values.Length);
                    }
                }
            }

            [Fact]
            public void ShouldReturnArrayWhenTwoChannelsAreSuppliedAndMappingIsEnum()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var values = pixels.ToByteArray(PixelMapping.RGB);
                        int length = image.Width * image.Height * 3;

                        Assert.Equal(length, values.Length);
                    }
                }
            }
        }
    }
}
