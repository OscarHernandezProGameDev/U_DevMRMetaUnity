using UnityEngine;

public class HandInteractiveCube : MonoBehaviour
{
    public OVRHand leftHand, rightHand;
    public LayerMask interactableLayer;
    public float pinchThreshold = 0.7f;
    
    private Renderer cubeRenderer;
    private bool leftHandWasPinching = false;
    private bool rightHandWasPinching = false;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        bool leftHandIsPinching = IsHandPinching(leftHand);
        bool rightHandIsPinching = IsHandPinching(rightHand);

        // Check for start of pinch with left hand
        if (leftHandIsPinching && !leftHandWasPinching && IsHandHovering(leftHand))
        {
            ChangeColor();
            leftHandWasPinching = true;
        }
        else if (!leftHandIsPinching)
        {
            leftHandWasPinching = false;
        }

        // Check for start of pinch with right hand
        if (rightHandIsPinching && !rightHandWasPinching && IsHandHovering(rightHand))
        {
            ChangeColor();
            rightHandWasPinching = true;
        }
        else if (!rightHandIsPinching)
        {
            rightHandWasPinching = false;
        }
    }

    bool IsHandPinching(OVRHand hand)
    {
        return hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > pinchThreshold;
    }

    bool IsHandHovering(OVRHand hand)
    {
        if (Physics.Raycast(hand.PointerPose.position, hand.PointerPose.forward, out RaycastHit hit, Mathf.Infinity, interactableLayer))
        {
            return hit.collider.gameObject == gameObject;
        }
        return false;
    }

    void ChangeColor()
    {
        cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    void OnDrawGizmos()
    {
        DrawGizmoForHand(leftHand);
        DrawGizmoForHand(rightHand);
    }

    void DrawGizmoForHand(OVRHand hand)
    {
        Gizmos.color = Color.green;
        Vector3 forwardDirection = hand.PointerPose.forward * 100.0f;
        RaycastHit hit;
        Vector3 endPosition = Physics.Raycast(hand.PointerPose.position, forwardDirection, out hit, 100.0f, interactableLayer) && hit.collider.gameObject == gameObject
            ? hit.point
            : hand.PointerPose.position + forwardDirection;
        Gizmos.DrawLine(hand.PointerPose.position, endPosition);
    }
}
