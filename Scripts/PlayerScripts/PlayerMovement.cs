using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace AD0260
{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private float movementSpeed = 8;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private int _carrySpeed;
        [SerializeField] private GameObject ObjectToFind;
        private bool _hasTim = false;

        // Update is called once per frame
        void Update()
        {
                if (IsOwner)
                {

                    Vector3 movementDirection = Vector3.zero;
                    Vector3 jump = Vector3.up;
                    TestForTim();
                    SlowMovment();

                    if (Input.GetKey(KeyCode.W))
                    {
                        movementDirection.z++;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        movementDirection.x--;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        movementDirection.z--;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        movementDirection.x++;
                    }
                    //Experemental;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        jump.y++;
                    }
                    transform.LookAt(transform.position + movementDirection);

                    //transform.localPosition += movementDirection * Time.deltaTime * movementSpeed;

                    characterController.Move(movementDirection * Time.deltaTime * (movementSpeed/_carrySpeed));
                }

        }
        void TestForTim()
        {
            if (ObjectToFind = transform.GetChild(0).gameObject) { _hasTim = true; }
            else { _hasTim = false; }
        }
        void SlowMovment()
        {
            if (_hasTim == true)
            {
                _carrySpeed = 5;
            }
            else { _carrySpeed = 4; }
        }
    } 
}
