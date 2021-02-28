using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeOutWall : MonoBehaviour
{

    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();

    }

    public void FadeOut()
    {
        foreach (Material material in meshRenderer.materials)
        {
            material.DOFloat(0.2f, "_AlphaStrength", 2f);
        }
        
    }

    public void FadeIn()
    {
        foreach (Material material in meshRenderer.materials)
        {
            material.DOFloat(1f, "_AlphaStrength", 2f);
        }
    }
}
