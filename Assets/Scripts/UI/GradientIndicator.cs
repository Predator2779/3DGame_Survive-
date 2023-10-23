using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GradientHealthBar : Indicator
    {
        [SerializeField] private Gradient gradient;
        [SerializeField] private Image fill;
        
        public override void SetCurrentValue(float value)
        {
            base.SetCurrentValue(value);

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}