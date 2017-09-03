using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNock : MonoBehaviour {

    Vector3 temp;
    float movez = 0f;
    float time;
    Vector3 originz;
    bool move = false;
    // Use this for initialization
    public AudioClip[] audioClip;
    private AudioSource audioSource;
    void Start ()
    {
        originz = this.gameObject.transform.position;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        if (GameManager.Instance.RadioClear && !GameManager.Instance.DoorClick)
        {
            if (time > 3)
            {
                time = 0;
                PlaySound(audioClip[0]);
            }
        }
        
        if(move && audioSource.isPlaying)
        HardNock();

        if(GameManager.Instance.DoorClick)
        {
            audioSource.Stop();
            PlaySound(audioClip[1]);
            move = true;
            
                
            GameManager.Instance.DoorClick = false;
            GameManager.Instance.RadioClear = false;
        }
	}

    void StopAndPlay(AudioClip clip)
    {
        audioSource.Stop(); //해주나 안해주나 차이가 그렇겐없으나 써주는게 좋음
        audioSource.clip = clip;
        audioSource.Play();

        //audioSource.PlayDelayed(0.5f); //0.5초동안 지연된후 play시켜주는 함수

    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying) return; // 사운드가 플레이되고있는지 bool반환

        audioSource.PlayOneShot(clip); //볼륨크기 받을수있음

    }

    void HardNock()
    {
       
        temp = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(temp.x, temp.y, temp.z + movez);
        movez = Random.Range(-0.01f, 0.01f);
        if (this.gameObject.transform.position.z > originz.z + 0.05f ||
            this.gameObject.transform.position.z < originz.z - 0.05f)
            this.gameObject.transform.position = originz;
    }
}
 