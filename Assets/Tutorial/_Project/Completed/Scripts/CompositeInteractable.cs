using System.Collections.Generic;
using UnityEngine;

namespace InfallibleCode.Completed
{
    public class CompositeInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<GameObject> interactables;

        public void Interact()
        {
            print("Interact");
            foreach (var go in interactables)
            {
                var interactable = go.GetComponent<IInteractable>();
                interactable?.Interact();
            }
        }
    }
}