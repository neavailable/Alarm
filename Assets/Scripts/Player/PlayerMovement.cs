using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(1.0f, 10.0f), SerializeField] private float _speed;
        [SerializeField] private Transform _cameraTransform;

        
        private void Move()
        {
            float moveDirectionZ = Input.GetAxis("Vertical"); 
            float moveDirectionX = Input.GetAxis("Horizontal"); 

            Vector3 cameraForward = _cameraTransform.forward;
            Vector3 cameraRight   = _cameraTransform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 move = (cameraForward * moveDirectionZ + cameraRight * moveDirectionX)
                           * _speed * Time.fixedDeltaTime;

            transform.position += move;
        }
        
        private void FixedUpdate()
        {
            Move();
        }
    }
}