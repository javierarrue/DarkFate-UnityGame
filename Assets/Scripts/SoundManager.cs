using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip fireSound, heal;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("fireSound");
        heal = Resources.Load<AudioClip>("heal");

        audioSource = GetComponent<AudioSource>();
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "fireSound":
                audioSource.PlayOneShot(fireSound);
                break;

            case "heal":
                audioSource.PlayOneShot(heal);
                break;
        }
    }

}
