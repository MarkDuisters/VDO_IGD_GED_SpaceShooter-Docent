using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //We maken een globale vector2 die we updaten met OnMove. Zo kan elke methode bij
    //deze waarde.
    Vector2 inputVector = Vector2.zero;
    [SerializeField] float speed = 1f;

    void Update()
    {
        transform.Translate(inputVector * speed * Time.deltaTime, Space.World);
    }

    //OnMove word automatisch uitgevoerd door de Player Input compoment z'n event handler.
    //Player Input zoekt door elk script op het object om te kijken of er methodes bestaan
    //met "OnMove" en voert deze uit iedere keer als de input waarde veranderd van de OnMove actie.
    void OnMove(InputValue context)
    {
        inputVector = context.Get<Vector2>();
//        print($"x:{inputVector.x}, y:{inputVector.y}");
    }
}
