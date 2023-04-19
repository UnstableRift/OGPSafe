using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SpawnAtTransfrom : NetworkBehaviour
{
    [SerializeField] private GameObject _PlayerPrefabX;
    [SerializeField] private GameObject _SpawnPointX;
    // Start is called before the first frame update
    public void InstantiatePlayer()
    {
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
    }
    private void OnServerStarted()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                GameObject go = Instantiate(_PlayerPrefabX, _SpawnPointX.transform);
                NetworkObject no = go.GetComponent<NetworkObject>();
                no.SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
            }
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
        }
    }
    private void OnClientConnectedCallback(ulong clientID)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            GameObject go = Instantiate(_PlayerPrefabX, _SpawnPointX.transform);
            NetworkObject no = go.GetComponent<NetworkObject>();
            no.SpawnAsPlayerObject(clientID);
        }
    }
    public void StopListener()
    {
        NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnectedCallback;
    }
}
