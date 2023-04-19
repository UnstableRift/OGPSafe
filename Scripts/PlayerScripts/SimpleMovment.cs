using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace AD0260
{
    public class SimpleMovment : NetworkBehaviour
    {
        [SerializeField] private CharacterController characterController;
        public float speed = 10.0f;
        void Update()
        {
            if (IsOwner)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                Vector3 Moveplayer = new Vector3(horizontal, 0, vertical * speed * Time.deltaTime);
                characterController.Move(Moveplayer);
            }
        }

    } 
}
