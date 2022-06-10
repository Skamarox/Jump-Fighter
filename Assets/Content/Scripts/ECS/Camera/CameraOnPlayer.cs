using UnityEngine;

public class CameraOnPlayer : MonoBehaviour
{
    private float OffsetY = 4f;
    [SerializeField] private Transform player;

    private void Update()
    {
        Camera.main.transform.position = new Vector3(0, player.position.y + OffsetY, -10f);
    }
}
