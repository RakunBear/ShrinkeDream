using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // ������ ���

    void Update()
    {
        // ����� ������ �������� ����
        if (target == null)
            return;

        // ī�޶� ��ġ�� ��� ��ġ�� ������Ʈ
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
