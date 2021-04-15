using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    [SerializeField] Color[] colors;

    private Light _light;
    private int _index = 0;

    private void Awake()
    {
        _light = GetComponent<Light>();
        _light.color = colors[0];
    }

    public void NextLight()
    {
        _index++;

        if (_index > colors.Length - 1)
        {
            _index = 0;
            _light.color = colors[_index];
        }
        else
            _light.color = colors[_index];
    }

}
