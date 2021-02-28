using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainMovement : MonoBehaviour
{

    public enum Axis
    {
        xAxis,
        yAxis,
        zAxis
    };

    public float minVal=0f;
    public float maxVal=1f;

    public Axis constrainAxis;

    public bool useLocalAxis;

    public delegate void maxReachedCallback();
    public maxReachedCallback OnMaxReached;

    public delegate void minReachedCallback();
    public minReachedCallback OnMinReached;

    private void Update()
    {
        if (transform.hasChanged)
        {
            Constrain();
        }    
    }

    public void Constrain()
    {
        if (constrainAxis == Axis.xAxis)
        {
            if (useLocalAxis)
            {

                transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, minVal, maxVal), transform.localPosition.y, transform.localPosition.z);
                if (transform.localPosition.x == maxVal)
                {
                    OnMaxReached();
                }
                if (transform.localPosition.x == minVal)
                {
                    OnMinReached();
                }
            }
            else
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minVal, maxVal), transform.position.y, transform.position.z);
                if (transform.position.x == maxVal)
                {
                    OnMaxReached();
                }
                if (transform.position.x == minVal)
                {
                    OnMinReached();
                }
            }
        }
        else if (constrainAxis == Axis.yAxis)
        {
            if (useLocalAxis)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, minVal, maxVal), transform.localPosition.z);
                if (transform.localPosition.y == maxVal)
                {
                    OnMaxReached();
                }
                if (transform.localPosition.y == minVal)
                {
                    OnMinReached();
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minVal, maxVal), transform.position.z);
                if (transform.position.y == maxVal)
                {
                    OnMaxReached();
                }
                if (transform.position.y == minVal)
                {
                    OnMinReached();
                }
            }
        }
        else if (constrainAxis == Axis.zAxis)
        {
            if (useLocalAxis)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, minVal, maxVal));
                if (transform.localPosition.z == maxVal)
                {
                    OnMaxReached();
                }
                if (transform.localPosition.z == minVal)
                {
                    OnMinReached();
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, minVal, maxVal));
                if (transform.position.z == maxVal)
                {
                    OnMaxReached();
                }
                if (transform.position.z == minVal)
                {
                    OnMinReached();
                }
            }
        }
    }
}
