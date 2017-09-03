using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ItemManageMent : MonoBehaviour {

    
    public Sprite NoneImage;
    public Sprite LampImage;
    public Sprite PaperImage;
    public Sprite ClockImage;
    public Sprite Paper2Image;
    public Sprite DollImage;

    public Image[] item;


    public Camera MainCamera = null;
    public Camera ObjectCamera = null;
    public bool SaveMousePosition = false;
    Vector3 SaveMousePos;

    public bool IsMakeClone = false;

    GameObject ParTemp = null;
    GameObject temp = null;
    GameObject ClickObj = null;
   
    public GameObject nullObj = null;
    public GameObject Lamp = null;
    public GameObject Paper = null;
    public GameObject Clock = null;
    public GameObject Paper2 = null;
    public GameObject Doll = null;

    public bool test123;

    public GameObject ObjectName = null;
    public GameObject ObjectText = null;

    bool lampclick = false;
    bool paperclick = false;
    bool clockclick = false;
    bool dollclick = false;

    public GameObject InvenText = null;

    public GameObject clockbutton = null;
    


    void Start ()
    {
           //item[0].GetComponent<Image>().sprite.name = "lampIcon";
        
        for(int i = 0; i < 5; i++)
        item[i] = GetComponentsInChildren<Image>()[i+1];
        



    }


    void Update ()
    {
        test123 = GameManager.Instance.InvenOn;
        if(clockclick)
        {
            clockbutton.SetActive(true);
            

        }
        else
        {
            clockbutton.SetActive(false);
            
        }
        for (int i = 0; i < 5; i++)
        {
            if (GameManager.Instance.InvenNum[i] == GameManager.Instance.ItemCode_None)
            {
                item[i].sprite = NoneImage;
                
            }
            if (GameManager.Instance.InvenNum[i] == GameManager.Instance.ItemCode_Lamp)
            {
                item[i].sprite = LampImage;
            }
            if (GameManager.Instance.InvenNum[i] == GameManager.Instance.ItemCode_Paper1)
            {
                item[i].sprite = PaperImage;
            }
            if (GameManager.Instance.InvenNum[i] == GameManager.Instance.ItemCode_Clock)
            {
                item[i].sprite = ClockImage;
            }
            if (GameManager.Instance.InvenNum[i] == GameManager.Instance.ItemCode_Paper2)
            {
                item[i].sprite = Paper2Image;
            }
            if (GameManager.Instance.InvenNum[i] == GameManager.Instance.ItemCode_Doll)
            {
                item[i].sprite = DollImage;
            }
        }

       
        
       
        if (GameManager.Instance.InvenOn)
        {
            if (nullObj)
                ObjectExam(nullObj);
          
        }
        if (!GameManager.Instance.InvenOn)
        {
            //GameManager.Instance.IsObjectPopUp = false;
            Destroy(temp);
            MainCamera.enabled = true;
            ObjectCamera.enabled = false;
            IsMakeClone = false;
            Debug.Log("tset123");


        }

        
    }


    void ObjectExam(GameObject Obj)
    {


        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!SaveMousePosition)
            {
                SaveMousePos.x = Input.mousePosition.x;
                SaveMousePos.y = Input.mousePosition.y;
                SaveMousePos.z = Input.mousePosition.z;
                SaveMousePosition = true;


            }
            Obj.transform.Rotate(new Vector3((SaveMousePos.y - Input.mousePosition.y) / 100, (SaveMousePos.x - Input.mousePosition.x) / 100, 0));


        }
        else
        {
            SaveMousePosition = false;
        }


    }

    void MouseClickIntroExam()
    {
        //if (Input.GetKey(KeyCode.Mouse0))
        {
            //if (nullObj == null)
            //{
            //    nullObj = new GameObject();
            //}
            if (!IsMakeClone)
            {

                Vector3 pos = new Vector3(0f, -0.384f, -0.851f);
                if (paperclick)
                    pos = new Vector3(0f, -0.084f, -0.851f);
                else if (clockclick)
                    pos = new Vector3(0f, -0.184f, -0.851f);
                else if (dollclick)
                    pos = new Vector3(0f, -0.25f, -0.851f);
                if (!ParTemp)
                    ParTemp = Instantiate(nullObj, new Vector3(0f, -0.184f, -0.851f), Quaternion.identity);

                float yAngle = 180f;
                if (clockclick ) yAngle = 0f;
                
                float zAngle = 0f;
                if (dollclick) zAngle = 180f;
                float xAngle = 0f;
                if (dollclick) xAngle = 240f;
                temp = Instantiate(ClickObj, pos, Quaternion.Euler(xAngle, yAngle,zAngle));
                

                temp.transform.parent = ParTemp.transform;

                
                nullObj = ParTemp;
                
                MainCamera.enabled = false;
                ObjectCamera.enabled = true;
                
                IsMakeClone = true;
                Debug.Log("test");



            }
        }
    }

    public void LampClick()
    {

      ClickObj = Lamp;
      MouseClickIntroExam();
 
    }
    public void ClickItemOnInven(int invenNum)
    {

        //ClickObj = clickObj;
        if (GameManager.Instance.InvenNum[invenNum] == GameManager.Instance.ItemCode_None)
        {
            return;
        }
        if (GameManager.Instance.InvenNum[invenNum] == GameManager.Instance.ItemCode_Lamp)
        {
            ObjectName.SendMessage("LampName");
            ObjectText.SendMessage("LampText");
            ClickObj = Lamp;
                lampclick = true;
            if(clockclick || paperclick)
            {
                Destroy(temp);
                MainCamera.enabled = true;
                ObjectCamera.enabled = false;
                IsMakeClone = false;
                nullObj = Lamp;
                paperclick = false;
                clockclick = false;
            }
            MouseClickIntroExam();

            
        }
        if (GameManager.Instance.InvenNum[invenNum] == GameManager.Instance.ItemCode_Paper1)
        {
            ObjectName.SendMessage("PaperName");
            ObjectText.SendMessage("PaperText");
                paperclick = true;
            if(clockclick || lampclick)
            {
                Destroy(temp);
                MainCamera.enabled = true;
                ObjectCamera.enabled = false;
                IsMakeClone = false;
                nullObj = Paper;
                lampclick = false;
                clockclick = false;

                Debug.Log("woktest2");
                
            }
            ClickObj = Paper;
            ClickObj.transform.Translate(new Vector3(99999, 99999, 999));
           
            ClickObj.SetActive(true);
            
            MouseClickIntroExam();

        }
        if (GameManager.Instance.InvenNum[invenNum] == GameManager.Instance.ItemCode_Clock)
        {
            ObjectName.SendMessage("ClockName");
            ObjectText.SendMessage("ClockText");
                clockclick = true;
            if (lampclick || paperclick)
            {
                Destroy(temp);
                MainCamera.enabled = true;
                ObjectCamera.enabled = false;
                IsMakeClone = false;
                nullObj = Clock;
                
                lampclick = false;
                paperclick = false;
                Debug.Log("woktest1");
            }
            ClickObj = Clock;
            ClickObj.transform.Translate(new Vector3(99999, 99999, 999));

            ClickObj.SetActive(true);

            MouseClickIntroExam();

        }
        if (GameManager.Instance.InvenNum[invenNum] == GameManager.Instance.ItemCode_Paper2)
        {
            ObjectName.SendMessage("PaperName2");
            ObjectText.SendMessage("PaperText2");
            paperclick = true;
            if (clockclick || lampclick)
            {
                Destroy(temp);
                MainCamera.enabled = true;
                ObjectCamera.enabled = false;
                IsMakeClone = false;
                nullObj = Paper2;
                lampclick = false;
                clockclick = false;

                Debug.Log("woktest3");

            }
            ClickObj = Paper2;
            ClickObj.transform.Translate(new Vector3(99999, 99999, 999));

            ClickObj.SetActive(true);

            MouseClickIntroExam();

        }

        if (GameManager.Instance.InvenNum[invenNum] == GameManager.Instance.ItemCode_Doll)
        {
            ObjectName.SendMessage("DollName");
            ObjectText.SendMessage("DollText");
            dollclick = true;
            if (clockclick || lampclick)
            {
                Destroy(temp);
                MainCamera.enabled = true;
                ObjectCamera.enabled = false;
                IsMakeClone = false;
                nullObj = Doll;
                lampclick = false;
                clockclick = false;

               

            }
            ClickObj = Doll;
            ClickObj.transform.Translate(new Vector3(99999, 99999, 999));

            ClickObj.SetActive(true);

            MouseClickIntroExam();

        }



    }
    private void OnGUI()
    {
        GUI.TextArea(new Rect(100, 100, 100, 100), " test :" + Input.mousePosition.x);
    }

    public void DestroyObjectTemp()
    {
        Destroy(temp);
        MainCamera.enabled = true;
        ObjectCamera.enabled = false;
        IsMakeClone = false;
        Debug.Log("tset123");
    }

    public void LeftArrowClickMin()
    {
        GameManager.Instance.min -= 1;
        InvenText.SendMessage("ClockText");
    }
    public void RightArrowClickMin()
    {
        GameManager.Instance.min += 1;
        InvenText.SendMessage("ClockText");
    }
    public void LeftArrowClickHour()
    {
        GameManager.Instance.hour -= 1;
        InvenText.SendMessage("ClockText");
    }
    public void RightArrowClickHour()
    {
        GameManager.Instance.hour += 1;
        InvenText.SendMessage("ClockText");
    }
}
