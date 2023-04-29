using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickableObject : MonoBehaviour
{
    private Camera mainCamera;
    private Tilemap tilemap;

    private void Start()
    {
        mainCamera = Camera.main;
        tilemap = FindObjectOfType<Tilemap>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit)
            {
                GameObject hitObject = hit.collider.gameObject;

                // ������Ʈ�� ��ȣ�ۿ��ϴ� ������ �ۼ��մϴ�.
                Debug.Log("Clicked object: " + hitObject.name);
            }
        }
    }
}
