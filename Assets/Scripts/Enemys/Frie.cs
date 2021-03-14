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
            GetComponent<PlayerGravityBody>().attractorPlanet = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetScript>();
            //Временно
            StopDistance = 0.5f;
        }

        internal override void Move()
        {
            base.Move();
        }
    }
}