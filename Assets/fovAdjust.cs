using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fovAdjust : MonoBehaviour
{
    public float scaleGet;
    public Camera PortraitCamera;
    public Camera LandscapeCamera;
    public float scale;
    public float orient;
    public GameObject ground;
     public void Update()
    {
        orient = Screen.width / Screen.height;

        if (orient == 1f)
        {
           
            if (ground.transform.rotation.y == 0)
            {
                ground.transform.Rotate(new Vector3(0f, -90f, 0f));
            }
        }
        else
        {
           
            if (ground.transform.rotation.y !=0)
            {
                ground.transform.Rotate(new Vector3(0f, 90f, 0f));
            }
        }

          
    }  
}


    
