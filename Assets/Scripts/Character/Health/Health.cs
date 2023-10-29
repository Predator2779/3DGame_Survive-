using UnityEngine;

namespace Character.Health
{
    public class Health : IHealth
    {
        [Min(0)]private readonly float _minHitPoints = 0;
        private readonly float _maxHitPoints;
        [Min(1)] private readonly float _coefDefense = 1;
        private float _hitPoints;

        public float HitPoints => _hitPoints;

        #region Constructor

        public Health(float maxHitPoints, float coefDefense)
        {
            _maxHitPoints = maxHitPoints;
            _hitPoints = maxHitPoints;
            _coefDefense = coefDefense;
        }
        public Health(float maxHitPoints, float coefDefense, float startHitPoints)
        {
            _maxHitPoints = maxHitPoints;
            _hitPoints = startHitPoints;
            _coefDefense = coefDefense;
        }

        #endregion

        public void TakeDamage(float damage) => ApplyValue(-damage / _coefDefense);
    
        public void TakeHeavyDamage(float damage) => ApplyValue(-damage);

        public void TakeHeal(float heal) => ApplyValue(heal);

        private void ApplyValue(float value)
        {
            float hitPoints = _hitPoints + value;

            if (hitPoints > _maxHitPoints) _hitPoints = _maxHitPoints;
            else if (hitPoints < _minHitPoints) _hitPoints = _minHitPoints;
            else _hitPoints += value;
        }
    }
}