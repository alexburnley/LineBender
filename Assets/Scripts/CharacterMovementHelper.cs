using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class CharacterMovementHelper : MonoBehaviour
{

    public XROrigin m_XROrigin;
    public CharacterController m_CharacterController;
    public float m_MinHeight;
    public float m_MaxHeight;

    public float cameraHeightBuffer = .15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }

    protected virtual void UpdateCharacterController()
    {
        if (m_XROrigin == null || m_CharacterController == null)
            return;

        var height = Mathf.Clamp(m_XROrigin.CameraInOriginSpaceHeight + cameraHeightBuffer, m_MinHeight, m_MaxHeight);

        Vector3 center = m_XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + m_CharacterController.skinWidth;

        m_CharacterController.height = height;
        m_CharacterController.center = center;
    }
}
