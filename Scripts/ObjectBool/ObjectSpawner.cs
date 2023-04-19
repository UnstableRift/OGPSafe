using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace AD0260
{
    public class ObjectSpawner : NetworkBehaviour
    {
        [SerializeField] private GameObject Spawnable;
        private void SpawnObject()
        {
            GameObject go = Instantiate(Spawnable);
            NetworkObject no = go.GetComponent<NetworkObject>();
            no.Spawn();
        }

        public override void OnNetworkSpawn()
        {
            if (IsServer)
            {
                SpawnObject();
            }
        }
    }

}