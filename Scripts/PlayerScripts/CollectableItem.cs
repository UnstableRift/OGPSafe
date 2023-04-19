using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD0260
{
    public class CollectableItem : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (transform.parent != other.transform && other.tag == "Player")
            {
                transform.parent = other.transform;
            }
            else if(transform.parent != other.transform && other.tag =="Drop")
            {
                transform.parent = null;
                DestroyBox();
            }
        }
        public void DestroyBox()
        {
            Destroy(gameObject);
        }
    } 
}
