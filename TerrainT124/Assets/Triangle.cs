using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    MeshRenderer meshRenderer;
    MeshFilter meshFilter; 
    int cellWidth = 20;
    int cellHeight = 20;
    int vertixWidth;
    int vertixHight;

    [SerializeField] Material material;

    private void Start()
    {
        vertixWidth = cellWidth + 1;
        vertixHight = cellHeight + 1;

        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer.material = material;


        
        Vector3[] vertices = new Vector3[4];
       
                vertices[0] = new Vector3(-1, -1, 0);
                vertices[1] = new Vector3(-1, 1, 0);
                vertices[2] = new Vector3(1, 1, 0);
                vertices[3] = new Vector3(1, -1, 0);
        
        
        meshFilter.mesh.vertices = vertices;
        int vert = 0;

        int[] indices = new int[vertixWidth * vertixHight];
        for(int z = 0; z < vertixHight; z++)
        {
            for(int x= 0; x < vertixWidth; x++)
            {
                indices[0 + x] = vert;
                indices[1 + x] = vert + 1;
                indices[2 + x] = vert + 2;
                indices[3 + x] = vert + 2;
                indices[4 + x] = vert + 3;
                indices[5 + x] = vert;
                vert++;
            }
            vert++;
        }
        meshFilter.mesh.triangles = indices;
    }
}
