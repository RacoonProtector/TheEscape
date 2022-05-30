using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheEscape.Script
{
    public class Note : MonoBehaviour, IInteractable
    {

        [SerializeField] private Image randomImage;
        [SerializeField] private Text quitReading;

        private GameObject cockpit;
        public void Interact()
        {
            SetImageVisible();
        }
        
        public void disconnectInteraction()
        {
            SetImageInvincible();

            
        }

        private void SetImageInvincible()
        {
            try
            {
                randomImage.gameObject.SetActive(false);
                quitReading.gameObject.SetActive(false);
            }
            catch (NullReferenceException nullReferenceException)
            {
                Debug.Log($"nullReferenceException occured in Object: {gameObject.name}");
                Debug.LogException(nullReferenceException);

            }
        }

        private void SetImageVisible()
        {
            randomImage.gameObject.SetActive(true);
            quitReading.gameObject.SetActive(true);
        }
    }
}