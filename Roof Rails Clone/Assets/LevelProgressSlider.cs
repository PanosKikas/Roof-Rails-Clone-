using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressSlider : MonoBehaviour
{
    public Transform EndLocation;
    public Transform PlayerLocation;

    public Slider LevelSlider;
    private float TotalDistanceZ;

    private void Start()
    {
        TotalDistanceZ = EndLocation.position.z - PlayerLocation.position.z;
    }

    private void Update()
    {
        float percentage = PlayerLocation.position.z / TotalDistanceZ;
        LevelSlider.value = percentage;
    }
}
