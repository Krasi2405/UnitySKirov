using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Transform player; // TODO: Change to player script when added.
    [SerializeField] private float delay;
    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(player.position.x, player.position.y, transform.position.z),
            ref velocity,
            delay
            );
    }
}
