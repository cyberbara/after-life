using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLightLevel : MonoBehaviour
{
    public LightOther lightOther;
    public Transform targetPoint;
    public Transform bridge;
    public float moveSpeed = 5.0f; // �������� �������� �����

    private bool isMoving = false; // ���� ��� ������������ �������� �����


    void Update()
    {
        // ���� ���� ��������, ���������� ��������� � ������� �����
        if (isMoving)
        {
            MoveBridge();
        }

    }

    public void MoveToTarget()
    {
        // ���������, ��� ������� ����� ������
        if (targetPoint != null)
        {
            // �������� ���� �������� �����
            isMoving = true;
        }
    }

    private void MoveBridge()
    {
        // ���������� ���� � ������� ������� ����� � �������������� ��������
        float step = moveSpeed * Time.deltaTime;
        bridge.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        // ���� ���� ������ ������� �����, ��������� ���� ��������
        if (transform.position == targetPoint.position)
        {
            isMoving = false;
        }
    }

}
