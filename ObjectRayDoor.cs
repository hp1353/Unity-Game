using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRayDoor : MonoBehaviour {

    [Range(0, 10)]
    public float distance = 5.0f;
    private RaycastHit[] rayHits;
    private Ray ray;
    public Animator controllGhost;
    public Animation userAni;
    public GameObject thunder = null;
   



    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position + new Vector3(0, 1.5f, 0);
        ray.direction = new Vector3(1, 0, 0);
        

    }


    void Update()
    {
        ray.origin = this.transform.position + new Vector3(0, 1.5f, 0);
        ray.direction = new Vector3(1, 0, 0);
        RayShot();

    }

    void RayShot()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        for (int index = 0; index < rayHits.Length; index++)
        {
            if (rayHits[index].collider.gameObject.tag == "Player")
            {
                controllGhost.SetBool("GhostRayEvent1", true);
                thunder.SendMessage("ThunderPlay");


            }


        }





    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray.origin, 0.1f);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

    }
}
