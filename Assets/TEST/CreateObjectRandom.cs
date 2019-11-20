using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CreateObjectRandom : MonoBehaviour
{

    public Transform cube;
    public int objectLength;
    public int sphereRange;
    public bool createCube;
    public bool sendCubeToDraw;
    private List<Transform> tList = new List<Transform>();
    //then function is called when the scripts is loaded or the 
    //value is changed on the inspector (called in the editor only)
    private void OnValidate()
    {
        if (createCube)
        {
            Debug.Log("createCube:" + createCube);
            tList.Clear();
            for (int i = 0; i < objectLength; i++)
            {
                CreateObject(i);
            }
        }
        if (sendCubeToDraw)
        {
            Debug.Log("sendcubetodraw:" + sendCubeToDraw);
          
        }
    }
    void CreateObject(int index)
    {
        Transform t = Instantiate(cube);
        t.name = "Cube_" + index;
        t.SetParent(this.transform);
        t.localPosition = Random.insideUnitSphere * sphereRange;
        tList.Add(t);
    }
    void DestroyObject()
    {

        //this.transform.GetChild();
    }
}
