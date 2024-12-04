using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angles : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float maxRotationAngleZ= 30f; // Maximale Rotationswinkel in Grad
    public float maxRotationAngleX = 30f;
    public float rotationSpeed = 5f; // Wie schnell das Raumschiff rotiert
    public float returnSpeed = 3f; // Geschwindigkeit, mit der das Raumschiff zurück rotiert

    private Vector3 targetRotation; // Zielrotation

    void Update()
    {
        // Input-Werte (Horizontal und Vertical) abfragen
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Zielrotation basierend auf Input berechnen
        float targetYaw = horizontalInput * maxRotationAngleZ; // Links/Rechts-Rotation
        float targetPitch = -verticalInput * maxRotationAngleX; // Hoch/Runter-Rotation

        targetRotation = new Vector3(targetPitch, 0f, -targetYaw);

        // Interpolierte Rotation (weiches Bewegen zum Ziel)
        Quaternion targetQuaternion = Quaternion.Euler(targetRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, Time.deltaTime * rotationSpeed);

        // Wenn kein Input, langsam zurückdrehen
        if (Mathf.Approximately(horizontalInput, 0) && Mathf.Approximately(verticalInput, 0))
        {
            ResetRotation();
        }
    }

    private void ResetRotation()
    {
        // Raumschiff zur Null-Position zurückdrehen
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * returnSpeed);
    }


}