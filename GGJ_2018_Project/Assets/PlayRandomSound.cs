using GGJ_2018.ContagionSystem;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip[] shoot;
    private AudioClip shootClip;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        int index = Random.Range(0, shoot.Length);
        shootClip = shoot[index];
        audioSource.clip = shootClip;
    }

    void Update()
    {
        if (GetComponent<ContactInfector>())
        {
            audioSource.Play();
        }
    }
}
