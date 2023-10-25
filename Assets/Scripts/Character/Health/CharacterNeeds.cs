using Character.Control;
using Other;
using UnityEngine;

namespace Character.Health
{
    public class CharacterNeeds : MonoBehaviour
    {
        [SerializeField] private HealthProcessor _health;
        [SerializeField] private Indicator _water;
        [SerializeField] private Indicator _food;

        [Tooltip("Урон здоровью при низких показателях (в у.е.)")]
        [SerializeField] private float _healthDamage;

        [Tooltip("Расход воды в N секунд (в %)")]
        [SerializeField] private float _waterConsumption;

        [Tooltip("Расход еды в N секунд (в %)")]
        [SerializeField] private float _foodConsumption;
        
        [Tooltip("Проверка в указанные N секунд")]
        [SerializeField] private float _checkVitalSigns = 3f;

        [SerializeField] [Range(0, 100f)] private float _waterPoints;
        [SerializeField] [Range(0, 100f)] private float _foodPoints;

        private Timer _timer;

        private void Start()
        {
            _timer = new Timer(_checkVitalSigns, true);
            
            _waterPoints = 100f;
            _foodPoints = 100f;
        }

        private void Update() => ReducedVitalSigns();

        private void ReducedVitalSigns()
        {
            if (ItsTime())
            {
                ReduceWater(_waterConsumption);
                ReduceFood(_foodConsumption);

                if (_waterPoints < 10 || _foodPoints < 10)
                    _health.TakeHeavyDamage(_healthDamage);

                DisplayIndicators();
            }
        }

        private void DisplayIndicators()
        {
            _water.SetCurrentValue(_waterPoints);
            _food.SetCurrentValue(_foodPoints);
            _health.DisplayHealthBar();
        }

        private bool ItsTime() => _timer.IsTimesUp();

        public void AddWater(float value) => AddValue(ref _waterPoints, value);

        public void ReduceWater(float value) => AddValue(ref _waterPoints, -value);

        public void AddFood(float value) => AddValue(ref _foodPoints, value);

        public void ReduceFood(float value) => AddValue(ref _foodPoints, -value);

        private void AddValue(ref float mainPoints, float points)
        {
            if (mainPoints + points > 100f) mainPoints = 100f;
            else if (mainPoints + points < 0) mainPoints = 0;
            else mainPoints += points;
        }
    }
}