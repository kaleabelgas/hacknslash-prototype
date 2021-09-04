using UnityEngine;

public class WeaponEntityController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    public void Fire()
    {
        weapon.Fire(transform.position, transform.parent.gameObject);
    }
    public void Equip(Transform parent)
    {
        gameObject.SetActive(true);
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
    public void UnEquip()
    {
        transform.SetParent(null);
        gameObject.SetActive(false);
    }
}
