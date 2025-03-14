using UnityEngine;

public class ControlSchemes : MonoBehaviour
{
    void Update()
    {
        // Button Presses
        if (OVRInput.GetDown(OVRInput.Button.One)) // Typically "A" or "X" button
        {
            Debug.Log("Button");
        }

        // Touch (Capacitive)
        if (OVRInput.Get(OVRInput.Touch.One)) // Touch on the "A" or "X" button
        {
            Debug.Log("Touch");
        }

        // Near Touch (Proximity)
        if (OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger)) // Near touch on the index trigger
        {
            Debug.Log("Near Touch");
        }

        // Axis1D (Triggers)
        float indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger); // 0 to 1 value for index trigger pressure
        if (indexTrigger > 0.1f) // Slight pressure on the index trigger
        {
            Debug.Log($"Index Trigger Pressure: {indexTrigger}");
        }

        // Axis2D (Thumbsticks)
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick); // Thumbstick position
        if (thumbstick != Vector2.zero)
        {
            Debug.Log($"Thumbstick Position: {thumbstick}");
        }
    }
}
