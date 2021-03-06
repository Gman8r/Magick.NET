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

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick
{
    /// <summary>
    /// Extension methods for the <see cref="IExifProfile"/> interface.
    /// </summary>
    public static class IExifProfileExtensions
    {
        /// <summary>
        /// Returns the thumbnail in the exif profile when available.
        /// </summary>
        /// <param name="self">The exif profile.</param>
        /// <returns>The thumbnail in the exif profile when available.</returns>
        public static IMagickImage<QuantumType> CreateThumbnail(this IExifProfile self)
        {
            Throw.IfNull(nameof(self), self);

            var thumbnailLength = self.ThumbnailLength;
            var thumbnailOffset = self.ThumbnailOffset;

            if (thumbnailLength == 0 || thumbnailOffset == 0)
                return null;

            var data = self.GetData();

            if (data.Length < (thumbnailOffset + thumbnailLength))
                return null;

            var result = new byte[thumbnailLength];
            Array.Copy(data, thumbnailOffset, result, 0, thumbnailLength);
            return new MagickImage(result);
        }
    }
}
