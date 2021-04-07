using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<Transform> weapons;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisableAllWeapons();
            weapons[0].transform.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisableAllWeapons();
            weapons[1].transform.gameObject.SetActive(true);
        }
    }

    private void DisableAllWeapons()
    {
        foreach (var item in weapons)
        {
            item.gameObject.SetActive(false);
        }
    }
}
