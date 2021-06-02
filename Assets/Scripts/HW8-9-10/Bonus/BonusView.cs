using UnityEngine;

namespace MVVM
{
    public class BonusView : MonoBehaviour
    {
        private IBonusViewModel _bonusViewModel;

        private void Awake()
        {
            transform.position = new Vector3(Random.Range(-10, 10), 0.7f, Random.Range(-10, 10));
        }

        public void Initialize(IBonusViewModel bonusViewModel)
        {
            _bonusViewModel = bonusViewModel;
        }
    }
}