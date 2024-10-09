using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image dashBar;
    public float dashAmount;
    public TextMeshProUGUI startUIText_Ammo;
    public TextMeshProUGUI startUIText_ReserveAmmo;
    public Image dashMeter;

    //counts how much ammo the player has in their weapon
    public void UpdateAmmoCounter(int ammoLeft)
    {
        startUIText_Ammo.text = "" + ammoLeft.ToString();
    }

    public void UpdateReserveCounter(int reserveAmmoLeft)
    {
        startUIText_ReserveAmmo.text = "" + reserveAmmoLeft.ToString();
    }

    public void UpdateDashAmount(float dashAmount)
    {
        dashBar.fillAmount = dashAmount;
    }

}
