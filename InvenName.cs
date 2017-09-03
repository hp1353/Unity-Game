using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvenName : MonoBehaviour {

    
    public Text text;
	// Use this for initialization
	void Start () {
        text = this.GetComponent<Text>();
        text.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.Instance.InvenNameInIt)
        {
            NullName();
            GameManager.Instance.InvenNameInIt = false;
        }
	}
    void NullName()
    {
        text.text = "";
    }
    void LampName()
    {
        text.text = "램프";
    }
    void PaperName()
    {
        text.text = "단서";
    }
    void ClockName()
    {
        text.text = "시계";
    }
    void PaperName2()
    {
        text.text = "단서";
    }
    void DollName()
    {
        text.text = "인형";
    }
}
