public class Health : IHealth
{
    private readonly float _minHitPoints = 0;
    private readonly float _maxHitPoints;
    private readonly float _coefDefense;
    private float _hitPoints;

    public float HitPoints => _hitPoints;

    #region Constructor

    public Health(float MaxHitPoints, float CoefDefense)
    {
        _maxHitPoints = MaxHitPoints;
        _hitPoints = MaxHitPoints;
        _coefDefense = CoefDefense;
    }
    public Health(float MaxHitPoints, float CoefDefense, float StartHitPoints)
    {
        _maxHitPoints = MaxHitPoints;
        _hitPoints = StartHitPoints;
        _coefDefense = CoefDefense;
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