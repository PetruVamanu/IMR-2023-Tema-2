using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StickingDartToTarget : MonoBehaviour
{
    public Rigidbody rb ;
    public GameObject myTarget;
    public GameObject player;
    float distanceToTarget = Mathf.Infinity;
    public TMP_Text mText;
    float newDist ;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == myTarget)
        {
            distanceToTarget = (collision.gameObject.transform.position - transform.position).magnitude;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            float distance = Vector3.Distance(myTarget.transform.position, player.transform.position);
            mText.text = "Score: " + (distance * 100).ToString("0");
        }
    }


    private void FixedUpdate()
    {
        if (myTarget == null) return;

        newDist = (myTarget.transform.position - transform.position).magnitude;
        if(newDist > distanceToTarget + 0.05f || distanceToTarget == Mathf.Infinity)
        {
            rb.useGravity = true;
            rb.freezeRotation = false;
            distanceToTarget = Mathf.Infinity;
        }
    }
}
