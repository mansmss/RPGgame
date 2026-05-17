using UnityEngine;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    public WeaponController weaponController;

    public TextMeshProUGUI pistolText;
    public TextMeshProUGUI shotgunText;
    public TextMeshProUGUI katanaText;

    void Update()
    {
        ResetColors();

        switch (weaponController.currentWeapon)
        {
            case WeaponType.Pistol:

                pistolText.color = Color.yellow;

                break;

            case WeaponType.Shotgun:

                shotgunText.color = Color.yellow;

                break;

            case WeaponType.Katana:

                katanaText.color = Color.yellow;

                break;
        }
    }

    void ResetColors()
    {
        pistolText.color = Color.white;

        shotgunText.color = Color.white;

        katanaText.color = Color.white;
    }
}