using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCameraChan : MonoBehaviour
{
    #region public 변수

    public float gravity = 10.0f;
    public float runSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    #endregion

    Transform oTransform; // 자신 위치
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

        // 마우스의 움직임을 가감
        mouseMove += new Vector3(-Input.GetAxisRaw("Mouse Y") * mouseSensitivity, Input.GetAxisRaw("Mouse X") * mouseSensitivity, 0);

        // 높이 제한
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

    // 외부 영향으로 / 지형 등으로 인해 카메라가 기울어 지면 바로 잡는 역할
    void Balance()
    {
        if(cameraTransform.eulerAngles.x != 0 || cameraTransform.eulerAngles.z != 0)
        {
            cameraTransform.eulerAngles = new Vector3(0, cameraTransform.eulerAngles.y, 0);
        }
    }

    void CameraDistanceControll()
    {
        // 휠로 카메라의 거리 조절
        Camera.main.transform.localPosition += new Vector3(0, 0, Input.GetAxisRaw("Mouse ScrollWheel") * 2.0f);

        // 연산속도 차이
        // (조건문) 좌항과 우항의 차이 공부하기

        // 최대로 가까운 수치
        if (-2 < Camera.main.transform.localPosition.z)
        {
            Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, -2f);
        }

        // 최소
        else if (Camera.main.transform.localPosition.z < -5)
        {
            Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, -5f);
        }
    }

    void MoveUnityChan(float rate)
    {
        float tempMoveY = move.y;

        // y는 필요 없기 때문에 잠시 저장하고 빼둔다.
        move.y = 0;

        Vector3 inputMoveXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // 대각선 이동 -> 2배의 이동 -> 속도가 1이상 올라가면 -> 노말라이즈 -> 항상 일정한 속도를 가질 수 있게 처리

        float inputMoveXZMagnitude = inputMoveXZ.sqrMagnitude;

        inputMoveXZ = oTransform.TransformDirection(inputMoveXZ);
        // TransformDirection: 방향 잡아주기

        if (inputMoveXZMagnitude <= 1)
        {
            inputMoveXZ *= runSpeed;
        }
        else
        {
            inputMoveXZ = inputMoveXZ.normalized * runSpeed;
        }

        // 조작중에만 카메라의방향에 상대적으로 캐릭터가 움직이는 처리를 해야 한다.
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Quaternion cameraRotation = cameraParentTransform.rotation;
            // 짐벌락을 막기 위해 Quaternion을 사용

            // 카메라는 무슨 축만 필요할까?
            cameraRotation.x = cameraRotation.z = 0;
            oTransform.rotation = Quaternion.Slerp(oTransform.rotation, cameraRotation, 10.0f * Time.deltaTime);

            if (move != Vector3.zero)
            {
                Quaternion characterRotation = Quaternion.LookRotation(move);
                // 쿼터니언은 LookAt을 LookRotation 대체

                characterRotation.x = characterRotation.z = 0;

                unityChanModel.rotation = Quaternion.Slerp(unityChanModel.rotation, characterRotation, 10.0f * Time.deltaTime);
            }

            // MoveTowards: 반성을 줄 때 사용
            // 가속도 붙일 때 사용
            // 사용하려면 rigidbody가 붙어야 한다.
            move = Vector3.MoveTowards(move, inputMoveXZ, rate * runSpeed);
            // 현재 위치, 목표 위치, 속도
        }
        else
        {
            // 관성 같은 느낌을 구현하겠다.
            move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMagnitude) * rate);
            // 서서히 가다가 멈추라.
        }
        // 현재 속도를 애니메이터에 반영
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
