using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class UpdatePulsePosition : MonoBehaviour
{
    public GameObject startIcon;
    public Material pulseShader;
    // Start is called before the first frame update
    void Start()
    {
        /*
        Vector4 startIconPosition = new Vector4(startIcon.transform.position.x, startIcon.transform.position.y, startIcon.transform.position.z, 0);
        //pulseShader = GetComponent<MeshRenderer>().material;
        pulseShader.SetVector("_PulseOrigin", startIconPosition);
        */
    }

    // Update is called once per frame
    void Update()
    {/*
     if (startIcon != null && startIcon.transform.hasChanged)
        {
            Vector4 startIconPosition = new Vector4(startIcon.transform.position.x, startIcon.transform.position.y, startIcon.transform.position.z, 0);
            pulseShader.SetVector("_PulseOrigin", startIconPosition);
        }  
        */
    }
}
