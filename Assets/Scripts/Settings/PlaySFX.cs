using UnityEngine;

namespace Settings
{
    public class PlaySFX: MonoBehaviour
    {
        public static PlaySFX instance = null;

        private AudioSource _audioSource;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                _audioSource = GetComponent<AudioSource>();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        public void PlayMusic(AudioClip clip)
        {
            _audioSource.Stop();
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}