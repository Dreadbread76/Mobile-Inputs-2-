using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Butt.Loot
{
    [CreateAssetMenu(menuName = "Butt Framework/Loot/Lootable", fileName = "NewLootable")]
    public class Lootable : ScriptableObject
    {
        [SerializeField]
        protected string itemName = "";
        [SerializeField, TextArea]
        protected string description = "";
        [SerializeField, TextArea]
        protected Sprite sprite;
    }
}

