using UnityEngine;

namespace Character
{
    public class Timer
    {
        public Timer(float time, bool repeated)
        {
            _time = time;
            _currentTime = _time;
            _isRepeat = repeated;
        }

        private float _time;
        private bool _isRepeat;
        private float _currentTime;

        public bool IsTimesUp()
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                ResetTimer();

                return true;
            }

            return false;
        }

        public float GetTime() => _currentTime;
        
        private void ResetTimer()
        {
            if (_isRepeat) _currentTime = _time;
        }
    }
}