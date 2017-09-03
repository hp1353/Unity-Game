using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollRoomEvent : MonoBehaviour {

    [Range(0, 10)]
    public float distance = 5.0f;
    private RaycastHit[] rayHits;
    private Ray ray;
    public GameObject Wall = null;
    
    float movingX;
    public AudioClip[] audioClip;
    private AudioSource audioSource;

    public Animator doll1;
    public Animator doll2;
    public Animator doll3;
    public Animator doll4;
    public Animator doll5;
    public Animator doll6;

    public AudioSource doll1s;
    public AudioSource doll2s;
    public AudioSource doll3s;
    public AudioSource doll4s;
    public AudioSource doll5s;
    public AudioSource doll6s;



    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position + new Vector3(0, 1.5f, 0);
        ray.direction = new Vector3(-1, 0, 0);
        audioSource = GetComponent<AudioSource>();

        doll1.Stop();
        doll2.Stop();
        doll3.Stop();
        doll4.Stop();
        doll5.Stop();
        doll6.Stop();

        doll1s.volume = 0f;
        doll2s.volume = 0f;
        doll3s.volume = 0f;
        doll4s.volume = 0f;
        doll5s.volume = 0f;
        doll6s.volume = 0f;

    }


    void Update()
    {
        ray.origin = this.transform.position + new Vector3(0, 1.5f, 0);
        ray.direction = new Vector3(-1, 0, 0);
        RayShot();

        if (GameManager.Instance.IsWallMove && !GameManager.Instance.IsWallEnd)
        {
            PlaySound(audioClip[0]);
            GameManager.Instance.DangerCount = 80;
            movingX += 0.01f;
            Wall.transform.Translate(new Vector3(0, movingX, 0));
            // Wall.transform.position.x = Wall.transform.position.x + 5;
            if (Wall.transform.position.x > -43)
            GameManager.Instance.IsWallEnd = true;
            GameManager.Instance.DollRoomEventing = true;
            Debug.Log("했음" + Wall.transform.position);
            doll1.Rebind();
            doll2.Rebind();
            doll3.Rebind();
            doll4.Rebind();
            doll5.Rebind();
            doll6.Rebind();
            doll1s.volume = 1f;
            doll2s.volume = 1f;
            doll3s.volume = 1f;
            doll4s.volume = 1f;
            doll5s.volume = 1f;
            doll6s.volume = 1f;
        }

        if(GameManager.Instance.DollEventEnd)
        {
            GameManager.Instance.DollRoomEventing = false;
            doll1.Stop();
            doll2.Stop();
            doll3.Stop();
            doll4.Stop();
            doll5.Stop();
            doll6.Stop();

            doll1s.volume = 0f;
            doll2s.volume = 0f;
            doll3s.volume = 0f;
            doll4s.volume = 0f;
            doll5s.volume = 0f;
            doll6s.volume = 0f;
        }
    }

    void RayShot()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        for (int index = 0; index < rayHits.Length; index++)
        {
            if (rayHits[index].collider.gameObject.tag == "Player")
            {
                
                GameManager.Instance.IsWallMove = true;
              

            }


        }





    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray.origin, 1.1f);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying) return; // 사운드가 플레이되고있는지 bool반환

        audioSource.PlayOneShot(clip); //볼륨크기 받을수있음

    }

    
}
