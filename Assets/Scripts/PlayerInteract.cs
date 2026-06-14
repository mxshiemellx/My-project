using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 5f;
    public LayerMask interactLayer;
    public Camera playerCamera;
    private int totalScore = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer)) // pass layer here
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                int earned = interactable.Interact();

                if(ScoreManager.instance != null)
                {
                ScoreManager.instance.AddScore(earned);
                Debug.Log("Coin collected, total score: " + ScoreManager.instance.GetScore());
                }
            }
        }
    }
}   