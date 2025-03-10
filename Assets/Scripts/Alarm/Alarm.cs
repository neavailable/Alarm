using UnityEngine;
using UnityEngine.Events;


namespace Alarm
{
    [RequireComponent(typeof(AudioSource), typeof(AlarmTrigger))]

    public class Alarm : MonoBehaviour
    {
        [Range(0.3f, 0.5f), SerializeField] private float _maxVolume;
        [Range(0.01f, 0.05f), SerializeField] private float _volumeStep;
        private const float _minVolume = 0.0f;   
        private AudioSource _audioSource;
        private AlarmTrigger _alarmTrigger;
        private bool _isPlaying;
        

        private void OnEnable()
        {
            _alarmTrigger = GetComponent<AlarmTrigger>();
            _audioSource = GetComponent<AudioSource>();

            _alarmTrigger.ShouldStartAlarm += ShouldPlaySound;
        }

        private void Start()
        {
            _isPlaying = false;
            _audioSource.volume = _minVolume;
            _audioSource.Play();
        }

        private void Update()
        {
            float volumeTimedStep = _volumeStep * Time.fixedDeltaTime;

            if (_isPlaying)
            {
                if (_audioSource.volume > _maxVolume) return;
                
                _audioSource.volume += volumeTimedStep;
            }

            else
            {
                if (_audioSource.volume < _minVolume) return;
                
                _audioSource.volume -= volumeTimedStep;
            }
        }
        
        private void ShouldPlaySound(bool shouldPlaySound)
        {
            _isPlaying = shouldPlaySound;
        }

        private void OnDisable()
        {
            _alarmTrigger.ShouldStartAlarm -= ShouldPlaySound;
        }
    }	
}