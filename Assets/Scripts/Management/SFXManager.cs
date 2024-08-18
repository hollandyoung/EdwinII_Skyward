using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // Sound effects
    [SerializeField] AudioClip sPlace;
    [SerializeField] AudioClip sClick;
    [SerializeField] AudioClip sHitWall;
    [SerializeField] AudioClip sDestroy;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayClip(string clip)
    {
        clip = clip.ToLower();
        switch (clip)
        {
            case "place":
                audioSource.clip = sPlace;
                break;
            case "click":
                audioSource.clip = sClick;
                break;
            case "hit wall":
                audioSource.clip = sHitWall;
                break;
            case "destroy":
                audioSource.clip = sDestroy;
                break;
        }
        audioSource.Play();
    }
}
