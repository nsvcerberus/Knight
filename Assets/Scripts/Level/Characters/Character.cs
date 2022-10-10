using UnityEngine;

namespace Fight.Level.Characters
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rb;
        [SerializeField] protected float goSpeed;
        [SerializeField] protected float runSpeed;


        protected virtual void Awake()
        {
            if (rb == null)
                rb = GetComponent<Rigidbody>();
        }


        protected virtual void MoveCharacter(Vector3 direction, float speed)
        {
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}