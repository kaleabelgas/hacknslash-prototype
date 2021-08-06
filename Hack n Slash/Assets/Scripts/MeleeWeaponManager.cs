using UnityEngine;

public class MeleeWeaponManager : MonoBehaviour
{
    [SerializeField]
    private MeleeWeapon weapon;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.WeaponSprite;
    }
}
