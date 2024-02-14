using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // 플레이어의 Transform 컴포넌트
    public float distance = 5.0f;  // 카메라와 플레이어 간의 거리
    public float sensitivityX = 4.0f;  // 마우스 X축 감도
    public float sensitivityY = 1.0f;  // 마우스 Y축 감도
    public float minYAngle = -30.0f;  // 카메라의 최소 Y축 각도
    public float maxYAngle = 80.0f;   // 카메라의 최대 Y축 각도

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private LineRenderer lineRenderer;  

    private Vector3 sphericalCoordinates;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // 커서를 중앙에 고정

        // LineRenderer 컴포넌트 초기화
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }

    void Update()
    {
        // 마우스 입력 처리
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        // Y축 각도 제한
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    void LateUpdate()
    {
        // 구면 좌표계를 이용하여 카메라 위치 및 회전 설정
        Vector3 direction = new Vector3(0, 0, -distance);  // 반지름에 해당하는 방향
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);  // 극각과 방위각으로 회전 설정
        Vector3 targetPosition = target.position + rotation * direction;  // 구면 좌표를 이용한 최종 위치 계산

        UpdateLineRenderer(target.position, targetPosition);

        transform.position = targetPosition;  // 카메라 위치 설정
        transform.LookAt(target.position);  // 플레이어를 바라보도록 설정

        sphericalCoordinates = CartesianToSpherical(target.position - transform.position);

    }

    void OnGUI()
    {
        // GUI에 구면 좌표계 표시
        GUI.Label(new Rect(10, 10, 200, 20), "Spherical Coordinates:");
        GUI.Label(new Rect(10, 30, 200, 20), "Radius: " + sphericalCoordinates.x.ToString("F2"));
        GUI.Label(new Rect(10, 50, 200, 20), "Polar Angle: " + sphericalCoordinates.y.ToString("F2"));
        GUI.Label(new Rect(10, 70, 200, 20), "Azimuthal Angle: " + sphericalCoordinates.z.ToString("F2"));
    }

    void UpdateLineRenderer(Vector3 startPoint, Vector3 endPoint)
    {
        // 라인 렌더러의 시작점과 끝점 업데이트
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }

    Vector3 CartesianToSpherical(Vector3 cartesianCoordinates)
    {
        // 구면 좌표계로 변환
        float radius = cartesianCoordinates.magnitude;
        float polar = Mathf.Acos(cartesianCoordinates.y / radius);
        float azimuthal = Mathf.Atan2(cartesianCoordinates.z, cartesianCoordinates.x);

        return new Vector3(radius, polar * Mathf.Rad2Deg, azimuthal * Mathf.Rad2Deg);
    }
}
