using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToUser : MonoBehaviour
{
    public Transform target;

    public float speed = 1f;

    private void Update()
    {

        Vector3 direction = transform.position - target.position;
        direction = direction.normalized;
        Quaternion rotation = Quaternion.LookRotation(direction.normalized, transform.up);
        Vector3 eulerRot = rotation.eulerAngles;
        eulerRot.Scale(new Vector3(0, 1, 0));
        rotation = Quaternion.Euler(eulerRot);
        transform.rotation = Quaternion.Lerp(transform.rotation,rotation,Time.time*speed);
    }
}
