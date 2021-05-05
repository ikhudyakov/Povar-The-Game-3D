using UnityEngine;
using System.Collections.Generic;

namespace hw6
{
    public class DictionaryTest : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField]
        private DictionaryScriptableObject dictionaryData;

        [SerializeField]
        private List<string> keys = new List<string>();
        [SerializeField]
        private List<int> values = new List<int>();

        private Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        [Header("Изменить")]
        public bool modifyValues;

        private void Awake()
        {
            for (int i = 0; i < Mathf.Min(dictionaryData.Keys.Count, dictionaryData.Values.Count); i++)
            {
                myDictionary.Add(dictionaryData.Keys[i], dictionaryData.Values[i]);
            }
        }

        public void OnBeforeSerialize()
        {
            if (modifyValues == false)
            {
                keys.Clear();
                values.Clear();
                for (int i = 0; i < Mathf.Min(dictionaryData.Keys.Count, dictionaryData.Values.Count); i++)
                {
                    keys.Add(dictionaryData.Keys[i]);
                    values.Add(dictionaryData.Values[i]);
                }
            }
        }

        public void OnAfterDeserialize()
        {

        }

        public void DeserializeDictionary()
        {
            myDictionary = new Dictionary<string, int>();
            dictionaryData.Keys.Clear();
            dictionaryData.Values.Clear();
            for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
            {
                dictionaryData.Keys.Add(keys[i]);
                dictionaryData.Values.Add(values[i]);
                myDictionary.Add(keys[i], values[i]);
            }
            modifyValues = false;
        }
    }
}