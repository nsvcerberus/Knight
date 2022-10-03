using UnityEngine;

namespace Fight.Gameplay
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected CharacterController characterController;
        [SerializeField] protected float goSpeed;
        [SerializeField] protected float runSpeed;


        protected virtual void Awake()
        {
            if (characterController == null)
                characterController = GetComponent<CharacterController>();
        }


        protected virtual void MoveCharacter(Vector3 direction, float speed)
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}