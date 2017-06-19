﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.FBX;

namespace TestProject
{
    class Program
    {
        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static void Initialize([MarshalAs(UnmanagedType.LPStr)] string SceneName);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static void SetFBXCompatibility(int CompatibilityVersion);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static void BeginMesh([MarshalAs(UnmanagedType.LPStr)] string MeshName);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static void EndMesh();

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl)]
        public extern static void AddVertices(FbxVector3[] Vertices, int Count);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl)]
        public extern static void AddIndices(int[] Triangles, int Count, int Material);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl)]
        public extern static void AddNormals(FbxVector3[] Normals, int Count);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl)]
        public extern static void AddTexCoords(FbxVector2[] TexCoords, int Count, int UVLayer, string ChannelName);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static void EnableDefaultMaterial([MarshalAs(UnmanagedType.LPStr)] string materialName);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl)]
        public extern static void SetMaterial([MarshalAs(UnmanagedType.LPStr)] string materialName, 
            FbxVector3 emissive, FbxVector3 ambient, FbxVector3 diffuse, FbxVector3 specular, 
            FbxVector3 reflection, double shininess);

        [DllImport("UnityFBXExporter", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static void Export([MarshalAs(UnmanagedType.LPStr)] string SceneName);

        static void ExportCube()
        {
            Initialize("CubeScene");
            SetFBXCompatibility(3);
            BeginMesh("CubeMesh");

            FbxVector3[] positions = new FbxVector3[8];
            FbxVector3[] normals = new FbxVector3[8];

            positions[0] = new FbxVector3(1, 0, 1);
            positions[1] = new FbxVector3(-1, 0, 1);
            positions[2] = new FbxVector3(1, 0, -1);
            positions[3] = new FbxVector3(-1, 0, -1);
            positions[4] = new FbxVector3(1, 2, 1);
            positions[5] = new FbxVector3(-1, 2, 1);
            positions[6] = new FbxVector3(1, 2, -1);
            positions[7] = new FbxVector3(-1, 2, -1);

            normals[0] = new FbxVector3(1, 0, 0);
            normals[1] = new FbxVector3(-1, 0, 0);
            normals[2] = new FbxVector3(0, 1, 0);
            normals[3] = new FbxVector3(0, -1, 0);
            normals[4] = new FbxVector3(0, 0, 1);
            normals[5] = new FbxVector3(0, 0, -1);
            normals[6] = new FbxVector3(1, 0, 0);
            normals[7] = new FbxVector3(-1, 0, 0);

            int[] indices = new int[36];
            // bottom
            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;
            indices[3] = 3;
            indices[4] = 2;
            indices[5] = 1;
            // top
            indices[6] = 6;
            indices[7] = 5;
            indices[8] = 4;
            indices[9] = 5;
            indices[10] = 6;
            indices[11] = 7;
            // left
            indices[12] = 0;
            indices[13] = 2;
            indices[14] = 4;
            indices[15] = 6;
            indices[16] = 4;
            indices[17] = 2;
            // right
            indices[18] = 5;
            indices[19] = 3;
            indices[20] = 1;
            indices[21] = 3;
            indices[22] = 5;
            indices[23] = 7;
            //// forward
            indices[24] = 4;
            indices[25] = 1;
            indices[26] = 0;
            indices[27] = 5;
            indices[28] = 1;
            indices[29] = 4;
            //// backward
            indices[30] = 2;
            indices[31] = 7;
            indices[32] = 6;
            indices[33] = 2;
            indices[34] = 3;
            indices[35] = 7;

            EnableDefaultMaterial("Material");
            AddVertices(positions, positions.Length);
            AddNormals(normals, normals.Length);
            AddIndices(indices, indices.Length, 0);
            EndMesh();

            Export(@"C:\Test\cube.fbx");
        }

        static void Main(string[] args)
        {
            ExportCube();
            ExportCube();
        }
    }
}
