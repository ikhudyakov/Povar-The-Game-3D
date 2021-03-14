using UnityEngine;

namespace povar3d
{
    public class PlayerGravityBody : MonoBehaviour
    {

        public PlanetScript attractorPlanet;
        private Transform playerTransform;

        private void Awake()
        {
            attractorPlanet = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetScript>();
        }

        void Start()
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            playerTransform = transform;
        }

        void FixedUpdate()
        {
            if (attractorPlanet)
            {
                attractorPlanet.Attract(playerTransform);
            }
        }
    }
}