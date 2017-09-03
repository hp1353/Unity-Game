using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRayEvent2 : MonoBehaviour {

    [Range(0, 10)]
    public float distance = 5.0f;
    private RaycastHit[] rayHits;
    private Ray ray;
    public GameObject bottle = null;
   


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
                
                if(!GameManager.Instance.GlassBreakEvent2)
                {
                    GameManager.Instance.GlassBreakEvent2 = true;
                    bottle.SetActive(true);
                }

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
