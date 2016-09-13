using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class MyVector3 {

    public float x;
    public float y;
    public float z;

    public void Fill(Vector3 v3)
    {
        x = v3.x;
        y = v3.y;
        z = v3.z;
    }

    public Vector3 GetV3()
    {
        return new Vector3(x, y, z);
    }

}
