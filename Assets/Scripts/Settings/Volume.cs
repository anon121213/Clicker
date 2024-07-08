using UnityEngine;
using UnityEngine.Audio;

namespace Settings
{
    public class Volume : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        private string SFX = nameof(SFX);
        private string Music = nameof(Music);
        private string Master = nameof(Master);

        public void ChangeMasterVolume(float sliderValue)
        {
            _audioMixer.SetFloat(Master, sliderValue);
        }
    
        public void ChangeSfxVolume(float sliderValue)
        {
            _audioMixer.SetFloat(SFX, sliderValue);
        }

        public void ChangeMusicVolume(float sliderValue)
        {
            _audioMixer.SetFloat(Music, sliderValue);
        }
    }
}
