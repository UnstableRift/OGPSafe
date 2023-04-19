using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class StartGame : NetworkBehaviour
{
    [SerializeField] private GameObject _startButton;

    [SerializeField] private GameObject _restrictor1;
    [SerializeField] private GameObject _restrictor2;
    [SerializeField] private GameObject _restrictor3;
    [SerializeField] private GameObject _restrictor4;
    public TMP_Text _timeInd;
    private int _speed = 3;
    private bool _endGame = false;
    private bool _startGame = false;
    private NetworkVariable<int> _timeLeft;
    // Update is called once per frame
    void Awake()
    {
        if(IsHost)
        {
            _startButton.SetActive(true);
        }
    }
    public void GameGo()
    {
        _restrictor1.transform.Translate(Vector3.up * _speed * Time.deltaTime);
        _startGame = true;
    }
    private void FixedUpdate()
    {
        if(_startGame == true)
        {
            // Seconds timer
        }
        else if(_timeLeft = 0)
        {

        }
        _timeInd.text = "T- " + _timeLeft.ToString();
    }
}
