using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButtonState : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    bool click;
    public GameObject Controller = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
        Debug.Log("클릭중");
        Controller.SendMessage("RightKey");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        click = false;
        Debug.Log("클릭땜");
        Controller.SendMessage("RightKeyFalse");
    }
}