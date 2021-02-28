using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;

//[ExecuteInEditMode]
public class FollowUser : Solver
{

    public Transform worldAnchor;
    Plane targetPlane;

    public float minXPosition = -2f;
    public float maxXPosition = 0f;

    public override void SolverUpdate()
    {
        if (SolverHandler != null && SolverHandler.TransformTarget != null)
        {
            targetPlane = new Plane(transform.position + worldAnchor.transform.up, transform.position + worldAnchor.transform.right, transform.position);
            //Debug.Log("Solver Handler is " + SolverHandler.TransformTarget);
            var target = SolverHandler.TransformTarget;
            Vector3 positionOnPlane = targetPlane.ClosestPointOnPlane(target.position);

            Vector3 localPosition = worldAnchor.transform.InverseTransformPoint(positionOnPlane);

            localPosition.x = Mathf.Clamp(localPosition.x, minXPosition, maxXPosition);
            localPosition.y = 0.25f;

            positionOnPlane = worldAnchor.transform.TransformPoint(localPosition);

            //Debug.Log("Goal Position " + positionOnPlane);
           // Debug.Log(worldAnchor.transform.InverseTransformPoint(positionOnPlane));

            GoalPosition = positionOnPlane;



            //GoalPosition = target.position + target.forward * 2.0f;
            /*Vector3 localTargetPos = gameObject.transform.InverseTransformPoint(target.position);
            Debug.Log(localTargetPos);
            GoalPosition = new Vector3(transform.position.x, transform.position.y, localTargetPos.z);
            */
        }
        else
        {
            Debug.Log("No SOlver Handler Found");
        }
    }

    public void SetNewMaxPosition(float newMaxPos)
    {
        maxXPosition = newMaxPos;
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward*-1);
        Gizmos.color = new Color(1, 0, 0, .5f);
        //Gizmos.DrawCube(transform.position, new Vector3(1, 1, 0.01f));

        //Gizmos.DrawRay(testTarget.position, transform.forward);


       // Vector3 targetPos = Vector3.ProjectOnPlane(testTarget.position, localForward * -1);

        Gizmos.color = Color.green;
        
        //Plane targetPlane = new Plane(transform.position + worldAnchor.transform.up, transform.position + worldAnchor.transform.right, transform.position);

        //Gizmos.DrawWireSphere(targetPlane.ClosestPointOnPlane(testTarget.position), .2f);
       
        Ray ray = new Ray(testTarget.position, transform.forward);

        float enter = 0f;

        if (targetPlane.Raycast(ray, out enter)) {
            Vector3 hitPoint = ray.GetPoint(enter);
            Gizmos.DrawWireSphere(hitPoint, .2f);
        }
        

    }
    */

}
