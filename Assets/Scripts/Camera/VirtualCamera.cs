using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _cam;
    internal CinemachineTransposer _transposer;
    public static event Action<bool> OnDisableAttackRangeButton;
    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
        _transposer=_cam.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void OnEnable()
    {
        AttackRangeButton.OnIncreaseAttackRangeEvent += UpdateCameraPosition;
    }
    private void OnDisable()
    {
        AttackRangeButton.OnIncreaseAttackRangeEvent -= UpdateCameraPosition;

    }


    private void UpdateCameraPosition(float yPos)
    {

        if (_transposer.m_FollowOffset.y <= 30f)
        {
            _transposer.m_FollowOffset.y += 10f * yPos;
        }
        else
        {
            OnDisableAttackRangeButton?.Invoke(true);
        }
    }

}
