using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCheckSound : MonoBehaviour
{

    AudioSource checkSound;

    // Start is called before the first frame update


    // Update is called once per frame
    public void PlaySound()
    {
        checkSound.Play();
    }
}
