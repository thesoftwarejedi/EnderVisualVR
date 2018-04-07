using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class InvertNormals : MonoBehaviour {

	void Start () {
        var mesh = GetComponent<MeshFilter>().mesh;
        var normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
            normals[i] = -mesh.normals[i];
        mesh.normals = normals;
        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            var tris = mesh.GetTriangles(i);
            for (int j = 0; j < tris.Length; j+=3)
            {
                tris[j] = tris[j] + tris[j + 1];
                tris[j + 1] = tris[j] - tris[j + 1];
                tris[j] = tris[j] - tris[j + 1];
            }
            mesh.SetTriangles(tris, i);
        }
	}
}
