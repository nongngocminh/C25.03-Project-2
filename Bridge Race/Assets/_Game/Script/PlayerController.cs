using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterData
{
    [SerializeField] private float moveSpeed;
    [SerializeField] FloatingJoystick floatingJoystick;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask bridgeLayer;
    private Vector3 direction;
    private bool isGrounded = false;

    public void Update()
    {
        CheckGrounded();
        JoystickMover();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            BrickController brick = other.gameObject.GetComponent<BrickController>();
            if (brick == null) return;
            if (brick.IsSameColorData(colorData))
            {
                GameManager.Instance.IncreaseBrickCount();
                Debug.Log("Hit Brick!");
                CharacterAddBrick();
                brick.DisableBrick();
            }
        }

        if (other.gameObject.CompareTag("BridgeBrick"))
        {
            BridgeBrickController bridgeBrick = other.gameObject.GetComponent<BridgeBrickController>();
            if (bridgeBrick == null) return;
            if (!bridgeBrick.IsSameColorData(colorData) && GameManager.Instance.playerBrickCount > 0)
            {
                GameManager.Instance.DecreaseBrickCount();
                bridgeBrick.EnableBridge();
                bridgeBrick.ChangeColor(colorDataConfig.GetMaterial((int)colorData));
                CharacterRemoveBrick();
            }
        }
    }

    private void CheckGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * 3f, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, 3f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            Debug.Log("Not Grounded");
        }
    }

    private void JoystickMover()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        direction = (cameraForward * floatingJoystick.Vertical + cameraRight * floatingJoystick.Horizontal).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 nextPosition = transform.position + direction * moveSpeed * Time.deltaTime;
            
            if (CanMove(nextPosition))
            {
                transform.position = SetPosition(nextPosition);

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    private Vector3 SetPosition(Vector3 nextPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 3f, groundLayer))
        {
            return hit.point + Vector3.up * 1.1f;
        }
        return transform.position;
    }

    private bool CanMove(Vector3 nextPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 3f, bridgeLayer))
        {
            BridgeBrickController bridgeBrick = hit.collider.gameObject.GetComponent<BridgeBrickController>();
            if (bridgeBrick != null)
            {
                if (!bridgeBrick.IsSameColorData(colorData) && GameManager.Instance.playerBrickCount == 0 && direction.z > 0)
                {
                    Debug.Log("Blocked!");
                    return false;
                }
            }
        }
        return true;
    }
}
