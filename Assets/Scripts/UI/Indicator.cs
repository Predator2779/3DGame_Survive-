using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    [SerializeField] protected Slider slider;
      
    public virtual void SetCurrentValue(float value) => slider.value = value;
}
