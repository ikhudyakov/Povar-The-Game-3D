using UnityEngine;

namespace povar3d
{
    public class MobileInputController : InputController, IExecute
    {
        private DynamicJoystick _dynamicJoystick;

        public MobileInputController(Player player)
        {
            player.Input = this;
            _dynamicJoystick = Object.FindObjectOfType<DynamicJoystick>();
        }

        public new void Execute(float deltaTime)
        {
            Horizontal = _dynamicJoystick.Horizontal;
            Vertical = _dynamicJoystick.Vertical;
        }
    }
}