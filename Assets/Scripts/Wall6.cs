using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall6 : MonoBehaviour
{
    public static GameObject walls(float width, float height, bool collider)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        Mesh m = new Mesh();
        float x = width / 2;

        m.vertices = new Vector3[]
        {
            new Vector3(-.5f,0.5f,-0.5f),
            new Vector3(-.5f,+0.5f,width-.5f),
            new Vector3(width-.5f,0.5f,width-.5f),
            new Vector3(width-.5f,0.5f,-0.5f)
        };
        /*   m.uv = new Vector2[]
           {
               new Vector2(0,0),
               new Vector2(1,0),
               new Vector2(1,1),
               new Vector2(1,0)
           };
         */
        m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        mf.mesh = m;
        if (collider)
            (go.AddComponent(typeof(MeshCollider)) as MeshCollider).sharedMesh = m;
        m.RecalculateBounds();
        m.RecalculateNormals();
        return go;
    }


}
