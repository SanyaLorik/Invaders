﻿using Assets.Project.Scripts.Battle.Grenades;
using Invaders.Gear;

namespace Invaders.Ui
{
    public class GrenadeInventorySlot : SpeciallyInventorySlot<IGrenade>
    {
        public override bool CanSetItem(IItem item) =>
            IsEmpty == true && item as IGrenade != null;
    }
}