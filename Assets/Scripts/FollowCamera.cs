using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Transform player; // TODO: Change to player script when added.
<<<<<<< HEAD
    [SerializeField] private float delay;
=======
    [SerializeField] private float followCoefficient = 0.15f;


>>>>>>> c437758e38e17bbbf4cf4cccc7954e23bc47dc23
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            new Vector3(player.position.x, player.position.y, transform.position.z), 
<<<<<<< HEAD
            delay);
=======
            followCoefficient);
>>>>>>> c437758e38e17bbbf4cf4cccc7954e23bc47dc23
    }
}
