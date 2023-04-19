using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [SerializeField] private UnityEvent SpawnNewItem;

    // Event Trigger used to exeute a script if teh if statement is true.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnNewItem.Invoke();
            Debug.Log("PointGet");
        }
    }
}
