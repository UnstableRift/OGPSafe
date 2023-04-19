using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Netcode;
using UnityEngine.Networking;
using System;

namespace AD0260
{
    public class SpawnMultiplePlayers : NetworkBehaviour
    {
        [SerializeField] private GameObject _playerPrefab = null;

        // List of plyer spawn positions.
        private static List<Transform> _spawnPoints = new List<Transform>();
        private int _nextIndex = 0;
        
        public static void AddSpawnPoint(Transform transform)
        {
            _spawnPoints.Add(transform);
            _spawnPoints = _spawnPoints.OrderBy(x => x.GetSiblingIndex()).ToList();
        }

        public static void RemoveSpawnPoint(Transform transform) => _spawnPoints.Remove(transform);
        //public override void OnNetworkSpawn();
        
        public void SpawnPlayer(NetworkClient client)
        {
            Transform spawnpoint = _spawnPoints.ElementAtOrDefault(_nextIndex);
            if (spawnpoint == null)
            {
                Debug.LogError($"Missing spawnpoint {_nextIndex}");
                return;
            }
            GameObject playerInstance = Instantiate(_playerPrefab, _spawnPoints[_nextIndex].position, _spawnPoints[_nextIndex].rotation);
            //OnNetworkSpawn(playerInstance, client);

            _nextIndex++;
        }
        private void Awake()
        {
            AddSpawnPoint(transform);
        }
        private void OnDestroy()
        {
            RemoveSpawnPoint(transform);
        }
    } 
}
