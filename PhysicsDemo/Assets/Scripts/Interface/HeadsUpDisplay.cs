using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeadsUpDisplay : MonoBehaviour
{
    public HealthSystem _health { get; set; }
    public ICoinCounter _coins { get; set; }
    public IKeyCounter _keys { get; set; }
    [SerializeField] private TextMeshProUGUI _currentHealthText;
    [SerializeField] private TextMeshProUGUI _maxHealthText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _keyText;

    private void Update()
    {
        if(_health != null)
        {
            _currentHealthText.text = _health.GetCurrentHealth().ToString();
            _maxHealthText.text = _health.GetMaxHealth().ToString();
        }
        if(_coins != null)
        {
            _coinText.text = _coins.GetScore().ToString();
        }
        if (_keys != null)
        {
            _keyText.text = _keys.GetScore().ToString();
        }
    }
}
