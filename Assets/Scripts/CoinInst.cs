using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class CoinInst : MonoBehaviour
{
   public List<Transform> spawnPoints = new List<Transform>();
   [SerializeField] private GameObject coin;

   private void Start()
   {
      int a = (int)Math.Ceiling(spawnPoints.Count / 2f);
      List<Transform> randomValues = new List<Transform>();
      while (randomValues.Count < a)
      {
         var index = Random.Range(0, spawnPoints.Count() - 1);
         var spawnPoint = spawnPoints[index];
         if (!randomValues.Contains(spawnPoint))
         {
            randomValues.Add(spawnPoint);
         }
      }
      
      foreach (var transform in randomValues)
      {
         Instantiate(coin, transform.position, Quaternion.identity);
      }
   }
}
