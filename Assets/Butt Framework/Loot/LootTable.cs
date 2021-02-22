using System.Collections.Generic;
using Serializable = System.SerializableAttribute;
using UnityEngine;

namespace Butt.Loot
{
    [CreateAssetMenu(menuName = "Butt Framework/Loot/LootTable", fileName = "NewLootTable")]
    public class LootTable : ScriptableObject
    {
        [Serializable]
        public class WeightedLoot
        {
            [SerializeField, Range(1,100)]
            protected int weighting = 50;
            [SerializeField]
            protected Lootable loot;

            public void AddLootToList(ref List<Lootable> _table)
            {
                for(int i = 0; i < weighting; i++)
                {
                    _table.Add(loot);
                }
                
            }
        }
        [SerializeField]
        private WeightedLoot[] possibleLoot;

        private List<Lootable> table = new List<Lootable>();
        public void GenerateTable()
        {
            //Clear the tbale to ensure new loot is put in
            table.Clear();

            // Fill the table with the weighted loots from the possible list
            foreach (WeightedLoot loot in possibleLoot)
            {
                loot.AddLootToList(ref table);
            }
        }

        /// <summary>
        /// Fills a contents list with loot based on the amount count passed.
        /// </summary>
        /// <param name="_contents"></param>
        /// <param name="_count">How many items that are being added to the table.</param>
        public void FillContents(ref List<Lootable> _contents, int _count)
        {
            for (int i = 0; i < _count; i++)
            {
                _contents.Add(GenerateLoot());
            }
        }

        /// <summary>
        /// Grab a random item from the loot table and returns it.
        /// If the table hasn't been filled, it will automatically be filled.
        /// </summary>
        /// <returns></returns>
        public Lootable GenerateLoot()
        {
            if(table.Count == 0)
            {
                foreach(WeightedLoot loot in possibleLoot)
                {
                    loot.AddLootToList(ref table);
                }
                // Fill the table
               
            }
            //Return a random lootable from the loot table
            return table[Random.Range(0, table.Count - 1)];
        }
    }
}

