using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void Start()
    {
        if (!(_weapon.WeaponSprite == null))
        {
            GetComponent<SpriteRenderer>().sprite = _weapon.WeaponSprite;

        }
    }
}
