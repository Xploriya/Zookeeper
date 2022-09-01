using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;

public class PlayerMeatPlacer : MonoBehaviour
{
   [SerializeField] private GameObject meatPrefab;
   [SerializeField] private Transform meatPlacementLocation;

   public void PlaceMeat()
   {
      Instantiate(meatPrefab, meatPlacementLocation.position, Quaternion.identity);
   }

}
