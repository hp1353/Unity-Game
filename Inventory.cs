using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    
   
    private int InvenMax = 5;

	void Start ()
    {
        GameManager.Instance.InvenNum = new int[InvenMax];
       
       
        for (int i = 0; i < InvenMax; i++)
        {
            GameManager.Instance.InvenNum[i] = 0;
          
        }
    }
	
	
	void Update ()
    {
		
	}

    public void EatItem(int ItemCode)
    {
        for(int i = 0; i< InvenMax; i++)
        {
            if(GameManager.Instance.InvenNum[i] == 0)
            {
                GameManager.Instance.InvenNum[i] = ItemCode;
                Debug.Log("GetItem" + ItemCode);
                Debug.Log("" + i + " 번쨰 템 획득");
                return;
            }
            
        }
        
        if (GameManager.Instance.InvenNum[0] != 0 && GameManager.Instance.InvenNum[1] != 0 &&GameManager.Instance.InvenNum[2] != 0
                &&GameManager.Instance.InvenNum[3] != 0
            &&GameManager.Instance.InvenNum[4] != 0 )
        {
            
            Debug.Log("인벤토리가 꽉 찼습니다");
            return;
        }

    }

    public void DeleteItem(int ItemCode)
    {
        for (int i = 0; i < InvenMax; i++)
        {
            if (GameManager.Instance.InvenNum[i] == ItemCode)
            {
                GameManager.Instance.InvenNum[i] = 0;
                Debug.Log("DeleteITem" + ItemCode);
                Debug.Log("" + i + " 번쨰 템 삭제");
                return;
            }

        }

        if (GameManager.Instance.InvenNum[0] == 0 && GameManager.Instance.InvenNum[1] == 0 && GameManager.Instance.InvenNum[2] == 0
                && GameManager.Instance.InvenNum[3] == 0
            && GameManager.Instance.InvenNum[4] == 0)
        {

            Debug.Log("인벤토리에 아무것도 없습니다");
            return;
        }

    }
}
