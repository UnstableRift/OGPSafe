using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _restrictor;
    [SerializeField] private float _counter;
    [SerializeField] private bool _doWait = false;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Disc"))
        {
            Debug.Log("P1Hit!");
            Restrict();
            _playerPrefab.transform.position = _spawnPoint.transform.position;
            _doWait = true;
        }
    }
    private void Restrict()
    {
        _restrictor.transform.position = new Vector3((-3/2), 1, (3/2));
    }
    void Update()
    {
        if(_doWait == true) 
        {
            _counter -= Time.deltaTime;
        }
        if (_counter <= 0)
        {
            _restrictor.transform.position = new Vector3((-3 / 2), 5, (3 / 2) * Time.deltaTime);
            _doWait = false;
        }
        _counter = 3f;
    }
}
