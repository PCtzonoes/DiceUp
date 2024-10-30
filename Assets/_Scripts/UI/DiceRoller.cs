using Helper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DiceRoller : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private GameEvent _rollDiceEvent;
        private int _currentHealth = 1000;

        private void Start()
        {
            UpdateHealthText();
        }

        public void RollDice()
        {
            var d20Roll = Random.Range(1, 21);
            var d6Sum = Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);

            switch (d20Roll)
            {
                case 1:
                    _currentHealth -= (int)(_currentHealth * 0.20f);
                    break;
                case >= 2 and <= 5:
                    _currentHealth -= 10 * (d6Sum - 2) * (d6Sum - 2) / 400;
                    break;
                case >= 6 and <= 15:
                    _currentHealth += 10 * (d6Sum - 2) * (d6Sum - 2) / 400;
                    break;
                case >= 16 and <= 20:
                    _currentHealth += (int)((10000 - _currentHealth) * 0.20f);
                    break;
            }

            UpdateHealthText();
            UpdateDiceImage(d20Roll);
        }

        private void UpdateHealthText()
        {
            _healthText.text = "Health: " + _currentHealth;
        }

        private void UpdateDiceImage(int roll)
        {
            
        }
    }
}