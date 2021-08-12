using UnityEngine;

public class WeaponEntity : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    public void Fire()
    {
        weapon.Fire(transform.position, transform.parent.gameObject);
    }
}
