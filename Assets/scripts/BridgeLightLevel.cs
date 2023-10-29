using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLightLevel : MonoBehaviour
{
    public LightOther lightOther;
    public Transform targetPoint;
    public Transform bridge;
    public float moveSpeed = 5.0f; // Скорость движения моста

    private bool isMoving = false; // Флаг для отслеживания движения моста


    void Update()
    {
        // Если мост движется, продолжаем двигаться к целевой точке
        if (isMoving)
        {
            MoveBridge();
        }

    }

    public void MoveToTarget()
    {
        // Проверяем, что целевая точка задана
        if (targetPoint != null)
        {
            // Включаем флаг движения моста
            isMoving = true;
        }
    }

    private void MoveBridge()
    {
        // Перемещаем мост в сторону целевой точки с использованием скорости
        float step = moveSpeed * Time.deltaTime;
        bridge.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        // Если мост достиг целевой точки, выключаем флаг движения
        if (transform.position == targetPoint.position)
        {
            isMoving = false;
        }
    }

}
