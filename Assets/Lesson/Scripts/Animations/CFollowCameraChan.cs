using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCameraChan : MonoBehaviour
{
    #region public ����

    public float gravity = 10.0f;
    public float runSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    #endregion

    Transform oTransform; // �ڽ� ��ġ
    Transform unityChanModel;
    Transform cameraTransform;
    Transform cameraParentTransform;
    CharacterController chanController;
    Animator chanAnimator;


    Vector3 move;
    Vector3 mouseMove;

    void Awake()
    {
        oTransform = transform;
        unityChanModel = transform.GetChild(0);
        cameraTransform = Camera.main.transform;
        cameraParentTransform = cameraTransform.parent;
        chanController = this.GetComponent<CharacterController>();
        chanAnimator = unityChanModel.GetComponent<Animator>();
    }

    void Update()
    {
        Balance();
        CameraDistanceControll();

        if(chanController.isGrounded)
        {
            GroundChecking();
            MoveUnityChan(1.0f);
        }
        else
        {
            move.y -= gravity * Time.deltaTime;
            MoveUnityChan(0.01f);
        }

        chanController.Move(move * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            chanAnimator.SetTrigger("AJump");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            chanAnimator.SetTrigger("Attack");
        }
    }

    void LateUpdate()
    {
        // fix
        cameraParentTransform.position = oTransform.position + Vector3.up * 0.5f;

        // ���콺�� �������� ����
        mouseMove += new Vector3(-Input.GetAxisRaw("Mouse Y") * mouseSensitivity, Input.GetAxisRaw("Mouse X") * mouseSensitivity, 0);

        // ���� ����
        if(mouseMove.x < -5f)
        {
            mouseMove.x = -5f;
        }
        else if(50 < mouseMove.x)
        {
            mouseMove.x = 50;
        }

        cameraParentTransform.localEulerAngles = mouseMove;
    }

    // �ܺ� �������� / ���� ������ ���� ī�޶� ���� ���� �ٷ� ��� ����
    void Balance()
    {
        if(cameraTransform.eulerAngles.x != 0 || cameraTransform.eulerAngles.z != 0)
        {
            cameraTransform.eulerAngles = new Vector3(0, cameraTransform.eulerAngles.y, 0);
        }
    }

    void CameraDistanceControll()
    {
        // �ٷ� ī�޶��� �Ÿ� ����
        Camera.main.transform.localPosition += new Vector3(0, 0, Input.GetAxisRaw("Mouse ScrollWheel") * 2.0f);

        // ����ӵ� ����
        // (���ǹ�) ���װ� ������ ���� �����ϱ�

        // �ִ�� ����� ��ġ
        if (-2 < Camera.main.transform.localPosition.z)
        {
            Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, -2f);
        }

        // �ּ�
        else if (Camera.main.transform.localPosition.z < -5)
        {
            Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, -5f);
        }
    }

    void MoveUnityChan(float rate)
    {
        float tempMoveY = move.y;

        // y�� �ʿ� ���� ������ ��� �����ϰ� ���д�.
        move.y = 0;

        Vector3 inputMoveXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // �밢�� �̵� -> 2���� �̵� -> �ӵ��� 1�̻� �ö󰡸� -> �븻������ -> �׻� ������ �ӵ��� ���� �� �ְ� ó��

        float inputMoveXZMagnitude = inputMoveXZ.sqrMagnitude;

        inputMoveXZ = oTransform.TransformDirection(inputMoveXZ);
        // TransformDirection: ���� ����ֱ�

        if (inputMoveXZMagnitude <= 1)
        {
            inputMoveXZ *= runSpeed;
        }
        else
        {
            inputMoveXZ = inputMoveXZ.normalized * runSpeed;
        }

        // �����߿��� ī�޶��ǹ��⿡ ��������� ĳ���Ͱ� �����̴� ó���� �ؾ� �Ѵ�.
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Quaternion cameraRotation = cameraParentTransform.rotation;
            // �������� ���� ���� Quaternion�� ���

            // ī�޶�� ���� �ุ �ʿ��ұ�?
            cameraRotation.x = cameraRotation.z = 0;
            oTransform.rotation = Quaternion.Slerp(oTransform.rotation, cameraRotation, 10.0f * Time.deltaTime);

            if (move != Vector3.zero)
            {
                Quaternion characterRotation = Quaternion.LookRotation(move);
                // ���ʹϾ��� LookAt�� LookRotation ��ü

                characterRotation.x = characterRotation.z = 0;

                unityChanModel.rotation = Quaternion.Slerp(unityChanModel.rotation, characterRotation, 10.0f * Time.deltaTime);
            }

            // MoveTowards: �ݼ��� �� �� ���
            // ���ӵ� ���� �� ���
            // ����Ϸ��� rigidbody�� �پ�� �Ѵ�.
            move = Vector3.MoveTowards(move, inputMoveXZ, rate * runSpeed);
            // ���� ��ġ, ��ǥ ��ġ, �ӵ�
        }
        else
        {
            // ���� ���� ������ �����ϰڴ�.
            move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMagnitude) * rate);
            // ������ ���ٰ� ���߶�.
        }
        // ���� �ӵ��� �ִϸ����Ϳ� �ݿ�
        float speed = move.sqrMagnitude;
        chanAnimator.SetFloat("ASpeed", speed);

        move.y = tempMoveY;
    }

    void GroundChecking()
    {
        if(Physics.Raycast(oTransform.position, Vector3.down, 0.5f))
        {
            move.y -= 5f;
        }
        else
        {
            move.y = -1f;
        }
    }
}
