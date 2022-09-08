using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFieldOfView : MonoBehaviour
{
    public float MinFOV = 64;
    public float MaxFOV = 84;
    public int PipesToMax = 15;

    private CinemachineVirtualCamera playerCam;

    private float targetFOV;

    public Pipe pipe;

    [SerializeField]
    private float MaxPipeLength = 4.1f;

    private float StartPipeLength;
    private float slope;
    private float b;

    private void Awake()
    {
        playerCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        targetFOV = MinFOV;
        pipe.OnPipeExtended += AdjustFOV;
        pipe.OnPipeCut += AdjustFOV;
        playerCam.m_Lens.FieldOfView = MinFOV;
        StartPipeLength = pipe.transform.localScale.y;
        slope = (MaxFOV - MinFOV) / (MaxPipeLength - StartPipeLength);
        b = MaxFOV - slope * MaxPipeLength;
    }

    public void AdjustFOV()
    {
        targetFOV = GetFOV();
    }

    private void Update()
    {
        if (targetFOV != MinFOV)
        {
            playerCam.m_Lens.FieldOfView = Mathf.Lerp(playerCam.m_Lens.FieldOfView, targetFOV, Time.deltaTime * 5f);
        }
    }

    private float GetFOV()
    {
        float pipeScaleY = pipe.transform.localScale.y;
        return slope * pipeScaleY + b;
    }
}
