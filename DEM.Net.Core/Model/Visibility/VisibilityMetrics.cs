﻿// ElevationMetrics.cs
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

using System;
using System.Collections.Generic;

namespace DEM.Net.Core
{
    /// <summary>
    /// Superset of elevation metrics for raycasting (intervisibility)
    /// All reliefs standing in between are listed in <see cref="Obstacles"/>
    /// </summary>
    public class VisibilityMetrics : ElevationMetrics
    {
        public bool Intervisible => Obstacles.Count == 0;

        public List<VisibilityObstacle> Obstacles { get; set; } = new List<VisibilityObstacle>();

        internal void AddObstacle(VisibilityObstacle obstacle)
        {
            Obstacles.Add(obstacle);
        }

        public new string ToString()
        {
            if (Intervisible)
            {
                return string.Concat("(Intervisible) ", base.ToString());
            }
            else
            {
                return string.Concat($"{Obstacles.Count} obstacle(s): ",
                    string.Join(Environment.NewLine + ", ", Obstacles),
                    Environment.NewLine,
                    base.ToString());
            }
        }
    }
}