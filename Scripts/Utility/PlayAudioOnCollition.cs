using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayAudioOnCollition : MonoBehaviour
{
    [SerializeField] private GameObject _disc;
    [SerializeField] private AudioSource _self;
    // Get audio source from gameObject and use "." to effect the audio.
    void OnTriggerEnter(Collider any)
    {
        _self = GetComponent<AudioSource>();
        _self.Play(0);
        Debug.Log("PingSound");
    }
}
