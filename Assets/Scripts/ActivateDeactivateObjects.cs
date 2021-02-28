using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivateObjects : MonoBehaviour
{
    public GameObject target;

    private void OnEnable()
    {
        target.SetActive(true);
    }

    private void OnDisable()
    {
        if (target.activeSelf)
        {
            target.SetActive(false);
        }
    }
}
