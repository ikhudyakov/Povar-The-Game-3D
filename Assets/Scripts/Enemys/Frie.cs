using UnityEngine;

namespace povar3d
{
    public class Frie : Enemy
    {
        private void Awake()
        {
            Health = 1000;
            HealthText = GetComponentInChildren<TextMesh>();
            HealthText.text = Health.ToString();
            RotationSpeed = 3.0f;
            MoveSpeed = 1.5f;
            //Временно
            StopDistance = 1f;
        }
    }
}