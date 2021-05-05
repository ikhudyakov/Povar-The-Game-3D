using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace hw6
{
    [CustomEditor(typeof(DictionaryTest))]
    public class DictionaryScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Сохранить"))
            {
                ((DictionaryTest)target).DeserializeDictionary();
            }
        }
    }
}