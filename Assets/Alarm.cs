using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _thief;
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
            _alarm.volume = Mathf.Clamp(targetVolume,0f,1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SpriteRenderer>() == _thief)
            _targetVolume = 1f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<SpriteRenderer>() == _thief)
            _targetVolume = 0f;
    }

}
