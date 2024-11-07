using UnityEngine;
using UnityEngine.UI;

public class HpStat : MonoBehaviour
{
    public int maxValue = 100;

    [Header("References")]
    public Image hpImage;

    private int _currentValue;

    public float CurrentPercentage => _currentValue / (float)maxValue;

    void Start()
    {
        _currentValue = maxValue;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentValue -= damageAmount;

        if (_currentValue < 0)
        {
            _currentValue = 0;
        }

        if (hpImage)
        {
            hpImage.fillAmount = CurrentPercentage;
        }
    }
}
