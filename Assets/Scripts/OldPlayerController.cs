using UnityEngine;

namespace Runner
{
    public class OldPlayerController : BasePlayerController
    {
        public float _sideSpeed;

        protected override void Start()
        {
            base.Start();
            _sideSpeed = GetComponent<PlayerStatsComponent>().SideSpeed;
        }

        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Jump();

            var direction = Input.GetAxis("Horizontal") * _sideSpeed * Time.fixedDeltaTime;

            if (direction == 0f) return;
            GetComponent<Rigidbody>().velocity += direction * transform.right;
        }
	}
}
