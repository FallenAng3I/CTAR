using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public Vector3 offset; // Смещение камеры относительно игрока
    public float smoothSpeed = 0.125f; // Скорость сглаживания камеры

    void LateUpdate()
    {
        // Если игрок не задан, выходим из метода
        if (player == null) return;

        // Определяем желаемую позицию камеры
        Vector3 desiredPosition = player.position + offset;
        
        // Плавно перемещаем камеру к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Обновляем позицию камеры
        transform.position = smoothedPosition;

        // Опционально: заставляем камеру смотреть на игрока
        transform.LookAt(player);
    }
}