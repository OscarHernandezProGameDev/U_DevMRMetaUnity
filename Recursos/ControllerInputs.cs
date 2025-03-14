using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInputs : MonoBehaviour
{
    private MyInputActions inputActions;
    private Renderer cubeRenderer;

    private void Awake()
    {
        // Initialize the input action
        inputActions = new MyInputActions();

        // Register the TriggerButton action event
        inputActions.ControllerInputs.TriggerButton.performed += _ => ChangeCubeColor();

        // Get the Renderer component of the Cube
        cubeRenderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        // Enable the input actions
        inputActions.Enable();
    }

    private void OnDisable()
    {
        // Disable the input actions
        inputActions.Disable();
    }

    // Method to change the Cube's color
    private void ChangeCubeColor()
    {
        // Randomly change the Cube's color
        cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
