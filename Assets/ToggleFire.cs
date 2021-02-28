using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class ToggleFire : MonoBehaviour
{

    Interactable interactableScript;
    ButtonConfigHelper buttonConfigHelper;

    bool fireStarted = false;

    //public GameObject fireVisualizationObject;
    public Animator brandschutzAnimator;


    // Start is called before the first frame update
    void Start()
    {
        interactableScript = GetComponent<Interactable>();
        buttonConfigHelper = GetComponent<ButtonConfigHelper>();
        interactableScript.OnClick.AddListener(OnToggle);
    }

    void OnToggle()
    {
        if (!fireStarted)
        {
            fireStarted = true;
            
            interactableScript.IsToggled = true;
            buttonConfigHelper.SetQuadIconByName("fire_icon_crossed_out_Zeichenfläche 1");
            buttonConfigHelper.MainLabelText = "Feuer löschen";
            buttonConfigHelper.SeeItSayItLabelText = "Feuer löschen";
            brandschutzAnimator.SetTrigger("startFire");
        }
        else
        {
            fireStarted = false;
            interactableScript.IsToggled = false;
            buttonConfigHelper.SetQuadIconByName("fire_icon_Zeichenfläche 1");
            buttonConfigHelper.MainLabelText = "Feuer entfachen";
            buttonConfigHelper.SeeItSayItLabelText = "Feuer entfachen";
            brandschutzAnimator.SetTrigger("stopFire");
        }

    }
  
}
