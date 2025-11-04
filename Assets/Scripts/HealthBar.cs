using UnityEngine;
using UnityEngine.UI; 

[RequireComponent(typeof(Slider))] 
public class HealthBar : MonoBehaviour
{
    [Tooltip("The characters that this Health Bar will follow")]
    [SerializeField]
    private Character targetCharacter;

    private Slider healthBarSlider;

    private void Awake()
    {
        // หา Slider ที่อยู่ใน GameObject เดียวกัน
        healthBarSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (targetCharacter == null)
        {
            Debug.LogWarning("The Target Character has not been set for the HealthBar yet!", this);
            return;
        }

        
        targetCharacter.OnHealthChanged += UpdateHealthBar;

        
        UpdateHealthBar(targetCharacter.Health, targetCharacter.MaxHealth);
    }

    private void OnDestroy()
    {
    
        if (targetCharacter != null)
        {
            targetCharacter.OnHealthChanged -= UpdateHealthBar;
        }
    }

    // เมธอดนี้จะถูกเรียกอัตโนมัติโดย event
    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (maxHealth > 0)
        {
            // คำนวณค่าพลังชีวิตเป็นเปอร์เซ็นต์ (0.0 ถึง 1.0)
            healthBarSlider.value = (float)currentHealth / maxHealth;
        }
        else
        {
            // กันกรณี maxHealth เป็น 0
            healthBarSlider.value = 0;
        }
    }
}