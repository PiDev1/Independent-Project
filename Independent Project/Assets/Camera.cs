using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //variables that define all of the necessary components and values that are needed to move the camera. 
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    public Transform combatLookAt;

    public GameObject thirdPersonCam;
    public GameObject combatCam;
    public GameObject topDownCam;

    //creates the different states for each of the camera styles
    public CameraStyle currentStyle;
    public enum CameraStyle
    {
        Basic,
        Combat,
        Topdown
    }

    private void Start()
    {
        //locks the cursor to the middle of the screen and hides visibility
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // switch states by pressing either 1, 2, or 3.
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Basic);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCameraStyle(CameraStyle.Combat);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchCameraStyle(CameraStyle.Topdown);

        // rotate orientation of the player by creating a new view direction and changing the orientation into that direction
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object depending on camera style by grabbing the mouse input of the user and changing the forward face of the player to align with that input.
        if (currentStyle == CameraStyle.Basic || currentStyle == CameraStyle.Topdown)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

        else if (currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }
    }

    //changes the camera style according to which state it is in by deactivating the other cameras and activating the state selected
    private void SwitchCameraStyle(CameraStyle newStyle) 
    {
        combatCam.SetActive(false);
        thirdPersonCam.SetActive(false);
        topDownCam.SetActive(false);

        if (newStyle == CameraStyle.Basic) thirdPersonCam.SetActive(true);
        if (newStyle == CameraStyle.Combat) combatCam.SetActive(true);
        if (newStyle == CameraStyle.Topdown) topDownCam.SetActive(true);

        currentStyle = newStyle;
    }
}
