using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;  // O jogador ou objeto que a câmera deve seguir
    public float smoothSpeed = 7.5f;  // A velocidade suave de movimento da câmera

    private Vector3 offset;  // A distância entre a câmera e o jogador no início

    public float minX = 41.18f;
    public float maxX = -1.07f;
    public float minY = -9.48f;
    public float maxY = 4.3f;
    void Start()
    {
        // Calcula o deslocamento inicial entre a câmera e o jogador
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calcula a nova posição da câmera suavemente
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;


    }
}