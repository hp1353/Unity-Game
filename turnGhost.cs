using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnGhost : MonoBehaviour {

    public GameObject ghost2 = null;
    public GameObject FirstPerson = null;
    public Animator ghost22 = null;
    bool IsSoundReady = false;
    bool IsLookForest;
    bool IsLookHouse;
    bool end;
    float time;

    public Camera MainCamera = null;
    public Camera HeartCamera = null;
    public GameObject BagIcon = null;
    public GameObject Dot = null;
    public Camera EndCamera = null;
    public GameObject EndC = null;

    public AudioClip[] audioClip;
    private AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	
	void Update ()
    {
        if (GameManager.Instance.Direction.x > 0.7f)
        {
            IsLookForest = false;
            IsLookHouse = true;
            // 반대쪽 쳐다봄
        }
        else if(GameManager.Instance.Direction.x < -0.7f)
        {
            IsLookForest = true;
            IsLookHouse = false;
            // 숲쪽쳐다봄
        }
        if (FirstPerson.transform.position.x < -95f)
        {
            Debug.Log("위치값 통과");
           
            if(IsLookHouse )
            {
                Debug.Log("앵글값 통과");
                ghost2.SetActive(true);
                Vector3 temp = new Vector3(FirstPerson.transform.position.x - 2.3f, FirstPerson.transform.position.y - 1, FirstPerson.transform.position.z);
                GameManager.Instance.DangerCount = 0;
                ghost2.transform.position = temp;
                IsSoundReady = true;
                
            }
        }
        if(IsSoundReady && IsLookForest &&!end)
        {
            
            PlaySound(audioClip[0]);
            ghost22.SetBool("Ready",true);
            end = true;
            Debug.Log("!!!!!!!!!!");
        }

        if(end)
        {

            time += Time.deltaTime;
            if(time >0.5f && time < 1f)
            {
                GameManager.Instance.GameClear = true;
                PlaySound(audioClip[1]);
                PlaySound(audioClip[2]);
                PlaySound(audioClip[3]);
                EndC.SetActive(true);
                MainCamera.enabled = false;
                HeartCamera.enabled = false;
                Dot.SetActive(false);
                BagIcon.SetActive(false);
                EndCamera.enabled = true;
            }
        }
	}

  

    void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying) return; // 사운드가 플레이되고있는지 bool반환

        audioSource.PlayOneShot(clip); //볼륨크기 받을수있음

    }
}
