using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;


public class AudioChangeVolume : MonoBehaviour
{
    
    public AudioMixer group;
    public string floatParam = "MyExposedParam";
    public void ChangeValue(float f)
    {
        group.SetFloat(floatParam, f);
    }
}
