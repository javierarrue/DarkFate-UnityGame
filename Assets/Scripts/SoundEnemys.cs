using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnemys : MonoBehaviour
{
    public static AudioClip turretShot, hit;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        turretShot = Resources.Load<AudioClip>("turretShot");
        hit = Resources.Load<AudioClip>("hit");

        audioSource = GetComponent<AudioSource>();

    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "turretShot":
                audioSource.PlayOneShot(turretShot);
                break;

            case "hit":
                audioSource.PlayOneShot(hit);
                break;
        }
    }
}
