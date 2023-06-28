using UnityEngine;

namespace Audio
{
    public class LoopAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        private bool _isPlaying;

        public void Play()
        {
            if (_isPlaying) return;
            _audioSource.Play();
            _isPlaying = true;
        }

        public void Stop()
        {
            _audioSource.Stop();
            _isPlaying = false;
        }
    }
}
