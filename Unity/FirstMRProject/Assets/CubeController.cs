using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Renderer cubeRenderer;
    private Color newColor;
    private Vector3 originalScale;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Move cube with left thumbstick (Virtual Mapping - Accessed as a Combined Controller)
        Vector2 moveInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime);

        // Change cube's color to a random color when Button.One (A/X) is pressed (Virtual Mapping - Accessed as Individual Controllers; Hand-Agnostic)
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            newColor = new Color(Random.value, Random.value, Random.value);
            cubeRenderer.material.color = newColor;
        }

        // Adjust cube's scale based on the trigger pressure of either controller (Raw Mapping)
        float triggerPressure = Mathf.Max(OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger), OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger));
        ScaleCube(triggerPressure);
    }

    private void ScaleCube(float pressure)
    {
        float scaleFactor = 1f + pressure;
        transform.localScale = originalScale * scaleFactor;
    }
}
