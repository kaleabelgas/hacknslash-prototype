using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    public void Fire()
    {
        weapon.Fire(transform.position, transform.parent.gameObject);
    }
}
