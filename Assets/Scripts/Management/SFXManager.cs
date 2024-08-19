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
    [SerializeField] AudioClip sProxIncr;
    [SerializeField] AudioClip sWaves;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Ambience();
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
                case "proximity increasing":
                    clip = sProxIncr;
                    break;
                default:
                    clip = sPlace;
                    break;
            }

            audioSource.PlayOneShot(clip);
        }
    }

    private IEnumerator Ambience()
    {
        Debug.Log("HEre?");
        yield return new WaitForSeconds(Random.Range(1, 2));
        audioSource.PlayOneShot(sWaves);
        Ambience();
    }
}
