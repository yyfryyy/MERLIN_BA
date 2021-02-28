using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppearDissappear : MonoBehaviour
{
    //public Ease easetype = Ease.Linear;

    public float Offset = -.25f;
    public float time = 2f;
    public float delay = 0f;

    public AudioSource audioShowOptional;
    public AudioSource audioHideOptional;

    Vector3 initialScale;
    Vector3 initialPos;

    private void Awake()
    {
        initialScale = transform.localScale;
        initialPos = transform.position;
    }

    public void Show()
    {
        gameObject.transform.localScale = initialScale;
        gameObject.transform.position = initialPos;
        gameObject.transform.DOScale(0, time).From().SetDelay(delay).SetEase(Ease.OutBack);
        gameObject.transform.DOMoveY(gameObject.transform.position.y + Offset, time).From().SetDelay(delay).SetEase(Ease.OutBack);
        if (audioShowOptional != null)
        {
            audioShowOptional.PlayDelayed(delay);
        }
    }

    public void Show(float yOffset, float time, float delay)
    {
        gameObject.transform.localScale = initialScale;
        gameObject.transform.position = initialPos;
        gameObject.transform.DOScale(0, time).From().SetDelay(delay).SetEase(Ease.OutBack);
        gameObject.transform.DOMoveY(gameObject.transform.position.y + Offset, time).From().SetDelay(delay).SetEase(Ease.OutBack);
        if (audioShowOptional != null)
        {
            audioShowOptional.PlayDelayed(delay);
        }
    }

    public void Hide()
    {
        initialScale = transform.localScale;
        initialPos = transform.position;
        gameObject.transform.DOScale(0, time).SetDelay(delay).SetEase(Ease.InBack);
        gameObject.transform.DOMoveY(gameObject.transform.position.y + Offset, time).SetDelay(delay).SetEase(Ease.InBack).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
        if (audioHideOptional != null)
        {
            audioHideOptional.PlayDelayed(delay);
        }
    }

    public void Hide(float yOffset, float time, float delay)
    {
        initialScale = transform.localScale;
        initialPos = transform.position;
        gameObject.transform.DOScale(0, time).SetDelay(delay).SetEase(Ease.InBack);
        gameObject.transform.DOMoveY(gameObject.transform.position.y + Offset, time).SetDelay(delay).SetEase(Ease.InBack).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
        if (audioHideOptional != null)
        {
            audioHideOptional.PlayDelayed(delay);
        }
    }

}
