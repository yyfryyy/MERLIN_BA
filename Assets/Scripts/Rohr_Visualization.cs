using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using UnityEngine.UI;

public class Rohr_Visualization : MonoBehaviour
{



    MeshRenderer[] meshRenderers;

    public Shader FadeShader;
    public Shader OpaqueShader;

    public GameObject interactableRohr;
    public GameObject directionArrow;

    public List<Toggle> checklist;

    public GameObject druckmesser;

    public AudioSource rohrRevealSound;

    public AudioSource checkSound;

    public AudioSource decompressedSound;

    public List<GameObject> UIButtons;

    bool rohrPlaced = false;
    bool fadedOut;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        interactableRohr.GetComponent<ConstrainMovement>().OnMinReached += ShowRohre;
        
    }

    public void ShowRohre()
    {
        interactableRohr.GetComponent<ObjectManipulator>().enabled = false;
        interactableRohr.GetComponent<BoundsControl>().enabled = false;
        interactableRohr.GetComponent<ConstrainMovement>().enabled = false;

        //Check off first Point
        checklist[0].isOn = true;
        checkSound.Play();
        checklist[1].gameObject.SetActive(true);

        //Play Sound
        rohrRevealSound.Play();
        rohrRevealSound.DOFade(0f, 3f).SetDelay(5f).OnComplete(() =>
        {
            rohrRevealSound.gameObject.SetActive(false);
        });
      
        directionArrow.GetComponent<AppearDissappear>().Hide();

        rohrPlaced = true;
        
        Sequence setactiveSequence = DOTween.Sequence();
        setactiveSequence.PrependInterval(2f);
        setactiveSequence.AppendCallback(() =>
        {
            interactableRohr.SetActive(false);
        });
 
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.DOFloat(2f, "_Reveal", 8f).SetEase(Ease.Linear).OnComplete(() => {
                meshRenderer.material.shader = OpaqueShader;
                if (meshRenderer.gameObject.tag == "Rohrleitung")
                {
                    meshRenderer.gameObject.SetActive(false);
                }
            });
        }
        Sequence checkListcheck = DOTween.Sequence();
        checkListcheck.PrependInterval(6f);
        checkListcheck.AppendCallback(() =>
        {
            druckmesser.gameObject.SetActive(true);
            druckmesser.GetComponent<AppearDissappear>().Show();
            druckmesser.GetComponent<Druckmessung>().OnDruckgemesst += () =>
            {
                checklist[1].isOn = true;
                checkSound.Play();
                checklist[2].gameObject.SetActive(true);

                decompressedSound.Play();

                //Show new UI
                foreach (GameObject uibutton in UIButtons)
                {
                    uibutton.SetActive(true);
                    uibutton.GetComponent<AppearDissappear>().Show();
                }

            };
        });



        /*
        foreach (MeshRenderer daemmung in daemmungen)
        {
            daemmung.material.DOFade(1f, "_Reveal", 3f);
        }

        foreach (MeshRenderer rohr in rohre)
        {
            rohr.material.DOFade(1f, "_Reveal", 3f);
        }
        */
    }

    public void rohrFadeOut()
    {
        if (rohrPlaced)
        {
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.material.shader = FadeShader;
                meshRenderer.material.DOFloat(0f, "Alpha_",2f);
            }
            fadedOut = true;
        }
    }

    public void rohrFadeIn()
    {
        if (rohrPlaced && fadedOut)
        {
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
               
                meshRenderer.material.DOFloat(1f, "Alpha_", 2f).OnComplete(()=> {
                    meshRenderer.material.shader = OpaqueShader;
                });
            }
            fadedOut = false;
        }
    }


}
