using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkObjectPush : MonoBehaviour
{
    [SerializeField] private float forceAmount;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if(rigidbody != null)
        {
            Vector3 direction = hit.gameObject.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            rigidbody.AddForceAtPosition(direction * forceAmount, transform.position, ForceMode.Impulse);
        }
    }
}
