using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//new inputsystem�� ����Ͽ� ����
//�ڵ� ���� �÷��̾� rigidbody�� ���̳����� �ƴ� ��� ������ ��ֹ� ���� �߻�


public class MonsterAI : MonoBehaviour
{
    public Tilemap map;
    [SerializeField] private float movementSpeed;

    public Transform target;
    private Vector3 destination;

    void FixedUpdate()
    {
        destination = target.position;
        if (Vector3.Distance(transform.position, destination) > 1f)
        transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
    }

}
