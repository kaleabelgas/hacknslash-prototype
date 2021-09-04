using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform firePoint;

    public void Fire(Team team)
    {
        Debug.Log("firing");
        weapon.Fire(firePoint.position, team);
    }
}
