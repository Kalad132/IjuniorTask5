using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _alarm;
    private float _volumeChangeSpeed = 1f;
    private float _targetVolume;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
        _alarm.volume = 0f;
        _alarm.Play();
    }

    private void Update()
    {
        if (_targetVolume != _alarm.volume)
        {
            float volumeChange = _volumeChangeSpeed * Time.deltaTime;
            if (_targetVolume < _alarm.volume)
            {
                volumeChange *= -1;
            }
            float targetVolume = _alarm.volume + volumeChange;
            if (targetVolume < 0)
            {
                targetVolume = 0f;
            }
            else if (targetVolume > 1)
            {
                targetVolume = 1f;
            }
            _alarm.volume = targetVolume;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Thief")
            _targetVolume = 1f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Thief")
            _targetVolume = 0f;
    }

}
