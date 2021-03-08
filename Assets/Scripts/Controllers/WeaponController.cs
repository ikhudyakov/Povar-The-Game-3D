using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int Damage;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().GetDamage(Damage);
        }
    }
}
