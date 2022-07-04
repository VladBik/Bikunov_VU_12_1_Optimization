using UnityEngine;

namespace Runner
{
    public class TriggerComponent : GameManager
    {
        [SerializeField]
        private Collider _collider;

		[SerializeField]
		private bool _isDamage;

        void Start()
        {
            _collider.isTrigger = true;
            
        }
        
        private void OnTriggerEnter(Collider other)
		{
            if (_isDamage)
            {
                GameManager.Self.SetDamage();
            }
            else
            {
                UpdateLevel();

            }
        }
	}
}