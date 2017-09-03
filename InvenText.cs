using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenText : MonoBehaviour {

    public Text text;
    // Use this for initialization
    void Start()
    {
        text = this.GetComponent<Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.InvenTextInIt)
        {
            NullText();
            GameManager.Instance.InvenTextInIt = false;
        }

    }
    void NullText()
    {
        text.text = "";
    }
    void LampText()
    {
        text.text =
        "낡아보이는 램프다.\n기름은 많은걸로 보아 넉넉히 쓸수있을것 같다.";
    }
    void PaperText()
    {
        text.text = "음..";
    }
    void ClockText()
    {
        text.text = "시계는" + GameManager.Instance.hour + "시" + GameManager.Instance.min + "분 에 멈춰있다";
        
    }
    void PaperText2()
    {
        text.text = "숫자가 규칙성을 가지고 있는것으로 보인다.";
    }
    void DollText()
    {
        text.text = "인형은 뭔가 사연이 있어 보인다.";
    }
}


