using UnityEngine;
using Cinemachine;

[SaveDuringPlay]
[AddComponentMenu("")]
public class LockCameraX : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    public float xPosition = 0f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize)
        {
            var pos = state.RawPosition;
            pos.x = xPosition;
            state.RawPosition = pos;
        }
    }
}
