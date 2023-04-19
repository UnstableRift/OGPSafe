using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace PointSystem
{
    public class SpawnInArea : NetworkBehaviour
    {
        public Vector3 _center;
        public Vector3 _size;
        public int _playerScoreInt;
        [SerializeField] private float _spawnHight = 0;
        [SerializeField] private GameObject TinyBoxTim;

        // Public and private point to UI elements.
        public Text _playerScorePublic;
        public TMP_Text _playerScorePrivate;

        private void SpawnTim()
        {
            Vector3 pos = _center + new Vector3(Random.Range(-_size.x / 2, _size.x / 2), _spawnHight, Random.Range(-_size.z / 2, _size.z / 2));
            GameObject go = Instantiate(TinyBoxTim, pos, Quaternion.identity);
            NetworkObject no = go.GetComponent<NetworkObject>();
            no.Spawn();
        }

        public void TestForPlayer()
        {
            if (IsClient)
            {
                SpawnTim();
                Debug.Log("HitSpawn");
                _playerScoreInt += _playerScoreInt;
                UpdateSprites();
            }
            else if (IsHost)
            {
                SpawnTim();
                Debug.Log("HitSpawn2");
                _playerScoreInt += _playerScoreInt;
                UpdateSprites();
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(_center, _size);
        }
        public void UpdateSprites()
        {
            _playerScorePublic.text = "Score " + _playerScoreInt.ToString();
            _playerScorePrivate.text = "Points " + _playerScoreInt.ToString();
        }
    } 
}
