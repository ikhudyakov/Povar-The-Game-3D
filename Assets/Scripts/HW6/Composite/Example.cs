using UnityEngine;

namespace hw6 {
    public class Example : MonoBehaviour
    {
        private CompositeFactory factory;
        void Start()
        {
            factory = new CompositeFactory();
            factory.Create("путь до json");
        }
    }
}