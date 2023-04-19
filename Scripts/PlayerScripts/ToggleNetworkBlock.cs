using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ToggleNetworkBlock : NetworkBehaviour
{
    [SerializeField] private GameObject MazeBlock;
    [SerializeField] private GameObject HoloGram;
    
    public string _timerCounter;
    [SerializeField] private float number;

    public float _waitfor = 7;
    public int _slow = 20;
    public void SetCoolDown()
    {
        _doWait = true;
    }
    void FixedUpdate()
    {
        if (_doWait == false)
        {
            number += (1f / _slow);
            _timerCounter = "Time: " + number;
        }
    }
    public void Timer()
    {
        if (_doWait == true)
        {
            _waitfor -= Time.deltaTime;
        }
    }
    public bool _doWait = false;

    private void Update()
    {
        // Reset count
        if (number >= 20) { number = 0f; }
        Timer();
        if (_waitfor <= 0)
        {
            _waitfor = 3;
            _doWait = false;
        }
    }
    public void SwitchState()
    {
        if (MazeBlock.activeSelf == true && _doWait == false)
        {
            MazeBlock.SetActive(false);
            HoloGram.SetActive(true);
        }
        else if (MazeBlock.activeSelf == false && _doWait == false)
        {
            MazeBlock.SetActive(true);
            HoloGram.SetActive(false);
        }
    }
}
