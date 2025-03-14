using UnityEngine;

public class OVRInputUsage : MonoBehaviour
{
    void Update()
    {
        // Check if the Primary Index Trigger is currently pressed down.
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Get");
        }

        // Check if the Primary Index Trigger was just pressed down this frame.
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Get Down");
        }

        // Check if the Primary Index Trigger was just released this frame.
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Get Up");
        }
    }
}
