using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning_Atoms : MonoBehaviour
{
     public Vector3[] AtomPositions { get; private set; }
     
    // Start is called before the first frame update
    void Start()
    {
        // Get the Mesh component
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        
        // Convert local vertex positions to world space
        AtomPositions = new Vector3[mesh.vertexCount];
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            AtomPositions[i] = transform.TransformPoint(mesh.vertices[i]);
        }
        // Prevent accessing an empty mesh
        if (mesh == null || mesh.vertexCount == 0)
        {
         Debug.LogError("Mesh is missing or has no vertices!");
         return;
        }

        MeshFilter meshFilter = GetComponent<MeshFilter>();

if (meshFilter == null || meshFilter.sharedMesh == null)
{
    Debug.LogError("MeshFilter or Mesh is missing on " + gameObject.name);
    return; // Stop execution to prevent a crash
}

// Instead of declaring a new 'mesh' variable, reuse it
meshFilter.mesh = Instantiate(meshFilter.sharedMesh); // Duplicate the mesh

if (!meshFilter.mesh.isReadable)
{
    Debug.LogError("Mesh is still not readable!");
}

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
