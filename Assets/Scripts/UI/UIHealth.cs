using UnityEngine;
using UnityEngine.UI;

namespace povar3d
{

    public class UIHealth : IExecute
    {
        private Image _healthBar;
        private Player _player;

        public UIHealth(Player player)
        {
            _healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
            _player = player;
        }

        public void Execute(float deltaTime)
        {
            _healthBar.fillAmount = (float)_player.Health / _player.AllHealth;
        }
    }
}