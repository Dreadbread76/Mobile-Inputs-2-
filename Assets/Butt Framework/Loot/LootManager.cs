using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Butt.Loot
{
    public class LootManager : MonoSingleton<LootManager>
    {
        [SerializeField]
        private List<LootTable> tables = new List<LootTable>();
        // Start is called before the first frame update
        private void Awake()
        {
            CreateInstance();
            FlagAsPersistant();

            tables.ForEach((table) => table.GenerateTable());
        }
    }
}

