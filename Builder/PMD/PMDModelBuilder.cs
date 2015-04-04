﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MMD.Adapter.PMD;
using UnityEngine;

namespace MMD.Builder.PMD
{
    public class PMDModelBuilder
    {
        SkinnedMeshRenderer renderer = new SkinnedMeshRenderer();
        Mesh mesh = new Mesh();
        List<GameObject> bones = new List<GameObject>();

        public PMDModelBuilder()
        {
            renderer.sharedMesh = mesh;
        }

        public void Read(MMD.Format.PMDFormat format)
        {
            mesh.vertices = ModelAdapter.Vertices(format.Vertices);
            mesh.uv = ModelAdapter.UVs(format.Vertices);
            mesh.normals = ModelAdapter.Nolmals(format.Vertices);
            mesh.SetTriangles(ModelAdapter.Triangles(format.Faces), 0);

            bones = BoneAdapter.BoneObjects(format.Bones);
        }
    }
}
