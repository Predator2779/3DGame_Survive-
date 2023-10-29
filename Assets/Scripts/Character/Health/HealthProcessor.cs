using UnityEngine;

namespace Character.Health
{
    [RequireComponent(typeof(Person))]
    public class HealthProcessor : MonoBehaviour, IHealth
    {
        [Header("HealthBar")]
        [SerializeField] private Indicator _healthBar;

        [Header("Parameters")]
        [SerializeField] private float _maxHitPoints;
        [SerializeField] private float _currentHitPoints;
        [SerializeField] [Min(1)] private float _coefDefense;

        private Person _person;
        private Health _health;

        private void Start() => Initialize();

        private void Initialize()
        {
            _person = GetComponent<Person>();
            _health = new Health(_maxHitPoints, _coefDefense);

            DisplayHealthBar();
        }

        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);

            DisplayHealthBar();
            CheckDeath();
        }

        public void TakeHeavyDamage(float damage)
        {
            _health.TakeHeavyDamage(damage);

            DisplayHealthBar();
            CheckDeath();
        }

        public void TakeHeal(float heal)
        {
            if (!CanHealing()) return;

            _health.TakeHeal(heal);

            DisplayHealthBar();
        }     
        
        public void TakeHealCompletely()
        {
            if (!CanHealing()) return;

            _health.TakeHeal(_maxHitPoints);

            DisplayHealthBar();
        }

        public void DisplayHealthBar()
        {
            _currentHitPoints = _health.HitPoints;

            if (_healthBar != null)
                _healthBar.SetCurrentValue(_currentHitPoints * 100 / _maxHitPoints);
        }

        private bool CanHealing() => _currentHitPoints < _maxHitPoints;

        private void CheckDeath()
        {
            if (_currentHitPoints <= 0) Death();
        }

        private void Death() => _person.Death();
    }
}