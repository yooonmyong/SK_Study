using UnityEngine;

public class PolarCameraController : MonoBehaviour
{
    private float cameraRadius = 5.0f;
    private float cameraPhi = Mathf.PI / 4; // polar angle

    private Vector3 lastMousePosition;

    void Update()
    {
        UpdateCameraPosition();

        // Update the camera's transform position
        transform.position = GetCameraPosition();

        // Look at the origin (you can modify this based on your scene requirements)
        transform.LookAt(Vector3.zero);
    }

    void UpdateCameraPosition()
    {
        // 가로 이동 W, S키
        float deltaPhi = Input.GetAxis("Vertical") * Time.deltaTime;
        // 스크롤로 거리 이동 (이동속도 -2f)
        float deltaRadius = Input.GetAxis("Mouse ScrollWheel") * (-2.0f);

        // Convert polar coordinates to Cartesian coordinates (1f ~ 10f)
        cameraRadius = Mathf.Clamp(cameraRadius + deltaRadius, 1.0f, 10.0f);

        // Ensure angle is within bounds (0.01f ~ 3.14f)
        cameraPhi += updateValue;
        cameraPhi = Mathf.Clamp(cameraPhi, 0.01f, Mathf.PI);
    }

    Vector3 GetCameraPosition()
    {
        // Convert polar coordinates to Cartesian coordinates
        float x = cameraRadius * Mathf.Cos(cameraPhi);
        float y = cameraRadius * Mathf.Sin(cameraPhi);
        float z = 0; // Assuming no rotation around the vertical axis in a 2D plane

        return new Vector3(x, y, z);
    }
}
