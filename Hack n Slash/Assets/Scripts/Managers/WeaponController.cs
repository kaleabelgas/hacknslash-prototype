using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponData _weapon;

    private void Start()
    {
        if (_weapon.WeaponSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = _weapon.WeaponSprite;

        }
    }

    public void Fire()
    {
        _weapon.Fire(transform.position, transform.parent.gameObject);
    }
}
