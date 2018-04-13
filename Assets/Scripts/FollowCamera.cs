using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Transform player; // TODO: Change to player script when added.
    [SerializeField] private float delay;
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            new Vector3(player.position.x, player.position.y, transform.position.z), 
            delay);
    }
}
