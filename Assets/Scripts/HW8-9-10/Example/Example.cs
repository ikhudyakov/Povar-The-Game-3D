using UnityEngine;
using Utils;

namespace hw
{
    public class Example : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(Interpreter.numbersToLetters(4500000));
            Debug.Log(Interpreter.numbersToLetters(44000));
            Debug.Log(Interpreter.numbersToLetters(20));
            Debug.Log(Interpreter.numbersToLetters(22456));
            Debug.Log(Interpreter.numbersToLetters(224256));
            Debug.Log(Interpreter.numbersToLetters(2124256));
            Debug.Log(Interpreter.numbersToLetters(352124256));
            Debug.Log(Interpreter.numbersToLetters(3521224256));
        }
    }
}