using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.Weapons
{
    public interface IWeapon
    {
        float GetFireDelay();
        GameObject GetBullet();
    }
}
