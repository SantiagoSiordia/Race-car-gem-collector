using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField] private AudioSource audioSource;
    public AudioClip[] diamondClips;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayDiamondSound() {
        audioSource.PlayOneShot(diamondClips[Random.Range(0, diamondClips.Length)], 0.3f);
    }
}
