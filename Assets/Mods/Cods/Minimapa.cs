using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapa : MonoBehaviour
{
    public Transform Player;


    private void LateUpdate()
    {
        // Ajuda a localizar a posição do player para o minimapa seguir corretamente
        Vector3 newPosition = Player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //transform.rotation = Quaternion.Euler(90f, Player.eulerAngles.y, 0f);
    }
}
