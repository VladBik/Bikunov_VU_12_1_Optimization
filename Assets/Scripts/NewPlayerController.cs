﻿using UnityEngine;

namespace Runner
{
    public class NewPlayerController : BasePlayerController
    {
        private RunnerControls _controls;
		public float _sideSpeed;

		protected override void Start()
        {
			base.Start();
			_sideSpeed = GetComponent<PlayerStatsComponent>().SideSpeed;

		}

		private void Update()
		{
			var direction = _controls.Player.Move.ReadValue<float>() * _sideSpeed * Time.deltaTime;

			if (direction == 0f) return;
			transform.position += direction * transform.right;
		}


		#region new input system code

		private void Awake()
		{
			_controls = new RunnerControls();
		}

		private void OnEnable()
		{
			_controls.Player.Enable();
			_controls.Player.Jump.performed += _ => Jump();
		}

		private void OnDisable()
		{
			_controls.Player.Disable();
			_controls.Player.Jump.performed -= _ => Jump();
		}

		private void OnDestroy()
		{
			_controls.Dispose();
		}

		#endregion
	}
}