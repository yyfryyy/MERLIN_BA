using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConvertToUI : MonoBehaviour
{

    public Transform targetUI;
    public GameObject mainUI;

    Vector3 originalPosition;

    public AudioSource audio;

    public void ConvertTo()
    {
        originalPosition = transform.position;
        transform.DOMove(targetUI.position, 0.5f).SetEase(Ease.InOutCubic).OnComplete(()=> {
            mainUI.SetActive(false);
            targetUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        });
        if (audio != null)
        {
            audio.Play();
        }
    }

    public void MoveBack()
    {
        gameObject.SetActive(true);
        transform.DOMove(originalPosition, 0.5f).SetEase(Ease.InOutCubic);
        if (audio!=null)
        {
            audio.Play();
        }
    }
}
