using UnityEngine;
using UnityEditor.AssetImporters;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

[ScriptedImporter(1, "msh")]
public class MshImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new();
        vertices.Add(new Vector3(0, 0, 0));
        vertices.Add(new Vector3(0, 4, 0));
        vertices.Add(new Vector3(4, 4, 0));
        vertices.Add(new Vector3(4, 0, 0));
        mesh.SetVertices(vertices);
        List<Vector2> uv = new();
        uv.Add(new Vector2(0, 0));
        uv.Add(new Vector2(0, 1));
        uv.Add(new Vector2(1, 1));
        uv.Add(new Vector2(1, 0));
        mesh.SetUVs(0,uv);
        List<int> indices = new();
        indices.Add(0);
        indices.Add(1);
        indices.Add(2);
        indices.Add(0);
        indices.Add(2);
        indices.Add(3);
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);
        ctx.AddObjectToAsset("mesh", mesh);
    }
}
