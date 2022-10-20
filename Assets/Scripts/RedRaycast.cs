using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRaycast : MonoBehaviour
{
    public GameObject RaycastStartPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(RaycastStartPoint.transform.position, RaycastStartPoint.transform.position - new Vector3(0, -1, 0));
        
    }
}
