using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Druckmessung : MonoBehaviour
{

    public GameObject pfeil;
    public TextMeshPro text;

    public delegate void druckmessungCallback();
    public druckmessungCallback OnDruckgemesst;

    public AudioSource pressureAudio;

    public MeshRenderer rohrShockwave;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Druckmessen()
    {
        pressureAudio.Play();
        pfeil.transform.DORotate(new Vector3(0, 0, -250), 5f, RotateMode.LocalAxisAdd);
        text.DOCounter(0, 60, 5f).OnComplete(()=> {
            OnDruckgemesst();
            rohrShockwave.material.DOFloat(10f, "_Progress", 30f).OnComplete(()=> {
                gameObject.SetActive(false);
            });
            animator.SetTrigger("triggerCheck");
        });
    }
}
