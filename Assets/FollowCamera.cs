using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Transform player; // TODO: Change to player script when added.

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            new Vector3(player.position.x, player.position.y, transform.position.z), 
            0.2f);
    }
}
