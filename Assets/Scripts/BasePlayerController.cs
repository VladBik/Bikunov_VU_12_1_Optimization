using System.Collections;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerStatsComponent))]
    public abstract class BasePlayerController : MonoBehaviour
    {
        Rigidbody _rigidbody;
        public float _jumpforce;
        public float _forwardSpeed;

        protected virtual void Start()
        {
            StartCoroutine(MoveForward());
            _rigidbody = GetComponent<Rigidbody>();
            _jumpforce = GetComponent<PlayerStatsComponent>().JumpForce;
            _forwardSpeed = GetComponent<PlayerStatsComponent>().ForwardSpeed;
        }

        protected void Jump()
        {
            _rigidbody.AddForce(transform.up * _jumpforce, ForceMode.Impulse);
        }

        private IEnumerator MoveForward()
        {
            while(true)
            {
                transform.position += transform.forward * _forwardSpeed * Time.deltaTime;
                yield return null;
			}
		}
    }
}
