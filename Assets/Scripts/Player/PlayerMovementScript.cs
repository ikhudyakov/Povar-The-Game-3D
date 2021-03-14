using System;
using System.Collections;
using UnityEngine;

namespace povar3d
{
    [Obsolete("Method1 is deprecated, please use Method2 instead.", true)]
    public class PlayerMovementScript : MonoBehaviour
    {
        UIController uIController;

        public float moveSpeed;
        public DynamicJoystick dynamicJoystick;
        public Animator animator;
        public Camera _camera;
        private Vector3 moveDirection;
        private Rigidbody componentRigidbody;
        private HandWeapon weapon;
        public int allHealth;
        public int health;


        public int Health { get => health; set => health = value; }

        private void Awake()
        {
            dynamicJoystick = FindObjectOfType<DynamicJoystick>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            allHealth = Health = 350;
            uIController = FindObjectOfType<UIController>();
            componentRigidbody = GetComponent<Rigidbody>();
            weapon = FindObjectOfType<HandWeapon>();
            weapon.GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(TestCoroutine());
        }

        private IEnumerator TestCoroutine()
        {
            while (Health >= 0)
            {
                Health -= 15;
                uIController.ShowHealth((float)Health / ((float)allHealth));
                yield return new WaitForSeconds(3f);
            }

        }

        private void Update()
        {
            moveDirection = new Vector3(dynamicJoystick.Horizontal, 0, dynamicJoystick.Vertical).normalized;
        }

        void FixedUpdate()
        {

            Vector3 down = Vector3.Project(componentRigidbody.velocity, transform.up);
            Vector3 forward = transform.forward * moveSpeed;
            forward = Vector3.ClampMagnitude(forward, moveSpeed);

            animator.SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);

            if (dynamicJoystick.Horizontal != 0f || dynamicJoystick.Vertical != 0f)
            {
                componentRigidbody.velocity = down + forward;
                transform.LookAt(moveDirection + transform.position);
            }
        }

        public void Attack()
        {
            animator.SetFloat("Attack", 1.0f);
            weapon.GetComponent<SphereCollider>().enabled = true;
        }

        public void StopAttack()
        {
            animator.SetFloat("Attack", 0.0f);
            weapon.GetComponent<SphereCollider>().enabled = false;
        }
    }
}