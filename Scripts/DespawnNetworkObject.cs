using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace Unity.BossRoom.Infrastructure
{
    public class DespawnNetworkObject : NetworkBehaviour
    {
        public override void OnNetworkSpawn()
        {
            if (IsServer)
            {
                StartCoroutine("Despawn");
            }
        }

        IEnumerable Despawn()
        {
            yield return new WaitForSeconds(3f);
            NetworkObject no = gameObject.GetComponent<NetworkObject>();
            no.Despawn();
        }
    } 
}
