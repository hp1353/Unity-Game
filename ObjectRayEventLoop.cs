using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRayEventLoop : MonoBehaviour {

    [Range(0, 10)]
    public float distance = 5.0f;
    private RaycastHit[] rayHits;
    private Ray ray;
    public GameObject player = null;
    public GameObject Flight = null;
    public GameObject Ghost = null;
   


    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position + new Vector3(0, 1.5f, 0);
        ray.direction = new Vector3(0, 0, -1);

    }


    void Update()
    {
        ray.origin = this.transform.position + new Vector3(0, 1.5f, 0);
        ray.direction = new Vector3(0, 0, -1);
        RayShot();
        

    }

    void RayShot()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        for (int index = 0; index < rayHits.Length; index++)
        {
            if (rayHits[index].collider.gameObject.tag == "Player")
            {
                if (GameManager.Instance.min == 1 && GameManager.Instance.hour == 2)
                {
                    Flight.SetActive(true);
                    Ghost.SetActive(true);
                    Debug.Log("유령생성됨");
                    GameManager.Instance.DangerCount = 80;
                    
                }
                else
                {
                    Debug.Log("crush");
                    //player.transform.Rotate(new Vector3(0f, 180f, 0f));
                    player.transform.position = new Vector3(player.transform.position.x + 25, player.transform.position.y, player.transform.position.z);

                }//player.transform.forward = (new Vector3(player.transform.forward.x, player.transform.forward.y + 90f, player.transform.forward.z));
            }


        }





    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray.origin, 1.1f);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

    }
}
