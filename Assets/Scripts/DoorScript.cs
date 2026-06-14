using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    public Vector3 rotateAmount = new Vector3(0, 90, 0);
    bool isOpen = false;

    public int Interact()
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("isOpen", isOpen);
        isOpen = !isOpen;

        return 0;
    }
}