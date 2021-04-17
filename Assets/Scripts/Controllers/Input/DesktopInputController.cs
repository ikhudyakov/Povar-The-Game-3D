using UnityEngine;

namespace povar3d
{
    public class DesktopInputController : InputController, IExecute
    {
        public DesktopInputController(Player player)
        {
            player.Input = this;
            Object.FindObjectOfType<DynamicJoystick>().transform.gameObject.SetActive(false);
        }

        public new void Execute(float deltaTime)
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }
    }
}