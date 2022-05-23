using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace TheEscape.Script
{
    public class CameraController : MonoBehaviour
    {
        [FormerlySerializedAs("mouseSensivity")] public float mouseSensitivity = 100f;

        [FormerlySerializedAs("PlayerBody")] public Transform playerBody;

        private float _xRotation = 0f;
    
        private IEnumerator Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            var cachedTransform = transform;
        
            var initialRotationX = cachedTransform.localRotation;
        
            var initialRotationY = playerBody.localRotation;
        
            yield return null;
            
            cachedTransform.localRotation = initialRotationX;

            playerBody.localRotation = initialRotationY;
        }

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            _xRotation -= mouseY;

            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}