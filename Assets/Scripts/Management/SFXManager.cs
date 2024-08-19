using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{
    // Sound effects
    [SerializeField] AudioClip sPlace;
    [SerializeField] AudioClip sClick;
    [SerializeField] AudioClip sHitWall;
    [SerializeField] AudioClip sDestroy;
    [SerializeField] AudioClip sCreak;

    // Music
    [SerializeField] AudioClip mus1;
    [SerializeField] AudioClip mus2;
    [SerializeField] AudioClip mus3;
    [SerializeField] AudioClip musIntro;
    private AudioClip currClip;

    private AudioSource audioSource;
    private AudioSource ambience;
    private AudioSource music;
    private int stage;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        music = gameObject.transform.GetChild(0).GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            currClip = mus1;
            StartCoroutine(PlayMusic(currClip));
        }
        else
        {
            currClip = musIntro;
            StartCoroutine(PlayMusic(currClip));
        }



    }

    public void PlayClip(string str)
    {
        if (!audioSource.isPlaying)
        {
            str = str.ToLower();
            AudioClip clip;
            switch (str)
            {
                case "place":
                    clip = sPlace;
                    break;
                case "click":
                    clip = sClick;
                    break;
                case "hit wall":
                    clip = sHitWall;
                    break;
                case "destroy":
                    clip = sDestroy;
                    break;
                case "creak":
                    clip = sCreak;
                    break;
                default:
                    clip = sPlace;
                    break;
            }

            audioSource.PlayOneShot(clip);
        }
    }

    public void SetStage(int num)
    {
        switch (num)
        {
            case 1:
                currClip = mus1;
                break;
            case 2:
                currClip = mus2;
                break;
            case 3:
                currClip = mus3;
                break;
        }
    }

    private IEnumerator PlayMusic(AudioClip current)
    {
        music.clip = currClip;
        music.Play();
        yield return new WaitUntil(() => music.time >= currClip.length);
        StartCoroutine(PlayMusic(currClip));
    }
}
