using UnityEngine;
using UnityEngine.EventSystems;

namespace povar3d {
    public class UIAttack : MonoBehaviour
    {
        private Player player;
        void Start()
        {
            player = FindObjectOfType<Player>();
            EventTrigger trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry enter = new EventTrigger.Entry();
            EventTrigger.Entry exit = new EventTrigger.Entry();
            enter.eventID = EventTriggerType.PointerEnter;
            enter.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
            exit.eventID = EventTriggerType.PointerExit;
            exit.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
            trigger.triggers.Add(enter);
            trigger.triggers.Add(exit);
        }

        private void OnPointerEnter(BaseEventData data)
        {
            player.Attack();
        }

        private void OnPointerExit(BaseEventData data)
        {
            player.StopAttack();
        }
    }
}