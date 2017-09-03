using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManageMent : MonoBehaviour {

    // Use this for initialization

    public UIButton btn = null;
    public Image sourceImage = null;

	void Start ()
    {
        btn = this.GetComponent<UIButton>();
        sourceImage = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
