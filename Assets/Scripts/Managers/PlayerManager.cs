using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 40;

        public void MoveControl(GameObject controlObject)
        {
            var moveVelocity = Vector3.forward * (Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed);
            var rotateVelocity = Vector3.up * Input.GetAxis("Horizontal");
            
            controlObject.transform.Translate(moveVelocity);
            controlObject.transform.Rotate(rotateVelocity);
        }
    }
}