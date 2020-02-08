﻿using DEM.Net.Core;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DEM.Net.glTF.SharpglTF
{

    public partial class SharpGltfService
    {
        public class IndexedTriangulation
        {
            private Triangulation Triangulation;

            public List<Vector3> Positions { get; private set; }
            public List<int> Indices { get; private set; }

            public IndexedTriangulation(Triangulation triangulation, Matrix4x4 vectorTransform = default)
            {
                if (vectorTransform == default)
                    vectorTransform = Matrix4x4.Identity;
                this.Triangulation = triangulation;
                Positions = triangulation.Positions.Select(p => Vector3.Transform(p.ToVector3(), vectorTransform)).ToList();
                Indices = triangulation.Indices.ToList();
            }
            public IndexedTriangulation(IEnumerable<Vector3> positions, IEnumerable<int> indices, Matrix4x4 vectorTransform = default)
            {
                if (vectorTransform == default)
                    vectorTransform = Matrix4x4.Identity;
                Positions = vectorTransform == default ? positions.ToList() : positions.Select(p => Vector3.Transform(p, vectorTransform)).ToList();
                Indices = indices.ToList();
            }

            public IndexedTriangulation(TriangulationNormals triangulation)
            {
                Positions = triangulation.Positions.ToList();
                Indices = triangulation.Indices.ToList();
            }

            public Vector3 this[int index]
            {
                get
                {

                    return Positions[Indices[index]];
                }


            }
        }
    }
}
