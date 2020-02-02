﻿// GeoPoint.cs
//
// Author:
//       Xavier Fischer 
//
// Copyright (c) 2019 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using DEM.Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEM.Net.Core
{
    public class GeoPoint : IEquatable<GeoPoint>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Elevation { get; set; }

        /// <summary>
        /// When this point is part of a List and ComputePointsDistances is called, this field
        /// stores the distance from this point to origin point in meters.
        /// </summary>
        public double? DistanceFromOriginMeters { get; set; }

        public GeoPoint(double latitude, double longitude, double? altitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Elevation = altitude;
            this.DistanceFromOriginMeters = null;
        }

        public GeoPoint(double latitude, double longitude) : this(latitude, longitude, null) { }
        public GeoPoint() : this(0,0) { }

        public GeoPoint Clone()
        {
            return new GeoPoint
            {
                DistanceFromOriginMeters = this.DistanceFromOriginMeters
                ,
                Elevation = this.Elevation
                ,
                Latitude = this.Latitude
                ,
                Longitude = this.Longitude
            };

        }

        public double DistanceSquaredTo(GeoPoint pt)
        {
            return (pt.Longitude - Longitude) * (pt.Longitude - Longitude)
                    + (pt.Latitude - Latitude) * (pt.Latitude - Latitude);
        }


        public static GeoPoint Zero
        {
            get { return new GeoPoint(0, 0); }
        }
        public override string ToString()
        {
            return $"Lat/Lon: {Latitude} / {Longitude} "
                + (Elevation.HasValue ? $", Elevation: {Elevation.Value:F2}" : "")
                + ((DistanceFromOriginMeters ?? 0) > 0 ? $", DistanceFromOrigin: {DistanceFromOriginMeters:F2}" : "");
        }

        public bool Equals(GeoPoint other)
        {
            if (this == null) return false;
            if (other == null) return false;

            return Math.Abs(this.Latitude - other.Latitude) < double.Epsilon
                  && Math.Abs(this.Longitude - other.Longitude) < double.Epsilon;
        }
    }


}
