using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    public AudioSource Hits;
    public AudioClip l_Attack;
    public AudioClip h_Attack;

    public void HitLight()
    {
        Hits.PlayOneShot(l_Attack, 1);
    }

    public void HitHeavy()
    {
        Hits.PlayOneShot(h_Attack, 1);
    }
}
