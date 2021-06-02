using System;
using UnityEngine;

namespace MVVM
{
    internal sealed class InputView : MonoBehaviour, IExecute
    {
        public float Angle { get; set; }
        public void Execute(float deltaTime)
        {
            Angle = Input.GetAxis("Horizontal") * 200f * deltaTime;
        }
    }
}