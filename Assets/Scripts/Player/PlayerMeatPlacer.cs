using UnityEngine;

public class PlayerMeatPlacer : MonoBehaviour
{
   [SerializeField] private GameObject meatPrefab;
   [SerializeField] private Transform meatPlacementLocation;

   public void PlaceMeat()
   {
      Instantiate(meatPrefab, meatPlacementLocation.position, Quaternion.identity);
   }

   public void SwitchFood(GameObject food)
   {
      meatPrefab = food;
   }

}
