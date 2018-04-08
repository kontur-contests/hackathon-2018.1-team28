using JetBrains.Annotations;
using UnityEngine;

namespace Assets.scripts
{
    [PublicAPI]
    public class HealthBarHandler : MonoBehaviour
    {
        private Transform _healthTrans;
        private float _hpscale;

        private void Start()
        {
            _healthTrans = transform.Find("HealthBar").gameObject.transform;
            _hpscale = _healthTrans.localScale.x;
        }

        public void UpdateHealth(int currentHp, int maxHp)
        {
            currentHp = Mathf.Max(currentHp, 0);
            var scale = _healthTrans.localScale;
            scale.x = (float) currentHp / maxHp * _hpscale;
            _healthTrans.localScale = scale;
        }
    }
}