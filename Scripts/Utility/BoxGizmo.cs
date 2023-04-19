using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD0260
{
    public class BoxGizmo : MonoBehaviour
    {
        [SerializeField] private int _red;
        [SerializeField] private int _green;
        [SerializeField] private int _blue;
        [SerializeField] private GameObject HiddenObject;
        [SerializeField] private bool _isVisible = true;
        private void OnDrawGizmos()
        {
            if(_isVisible == true) 
            {
                Gizmos.color = new Color(_red, _green, _blue, 0.5f);
                Gizmos.DrawCube(HiddenObject.transform.position, HiddenObject.transform.localScale);
            }
        }
    } 
}
