using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicChanger : MonoBehaviour
{
    [field: SerializeField] public AudioClip[] BackgroundMusic { get; private set; }

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = BackgroundMusic[0];
        audioSource.Play();
    }

    public void ChosenMusic(int arrayIndex)
    {
        audioSource.clip = BackgroundMusic[arrayIndex];
        audioSource.Play();
    }
}
