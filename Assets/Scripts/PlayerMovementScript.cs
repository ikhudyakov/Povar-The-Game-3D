using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public DynamicJoystick dynamicJoystick;
    private Vector3 moveDirection;


    void Update()
    {
        moveDirection = new Vector3(dynamicJoystick.Horizontal, 0, dynamicJoystick.Vertical).normalized;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }
}
