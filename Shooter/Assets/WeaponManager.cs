using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<Transform> weapons;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 1;
        }
    }
}
