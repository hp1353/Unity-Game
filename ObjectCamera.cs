using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCamera : MonoBehaviour {

    // Use this for initialization

    public Camera objcam = null;
    public Light camlight = null;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!objcam.enabled)
            camlight.intensity = 0f;
        else if (objcam.enabled)
            camlight.intensity = 1f;
	}
}
