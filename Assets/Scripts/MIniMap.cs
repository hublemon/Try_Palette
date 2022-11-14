using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIniMap : MonoBehaviour
{
    public Transform _player;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        Vector3 newPosition=_player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
