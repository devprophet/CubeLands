using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVMapping : MonoBehaviour {

	public static Vector2[] GetTileUV(int ItemsCountX, int ItemsCountY, Vector2 Item){
		float stepx = 1f / (float)ItemsCountX;
		float stepy = 1f / (float)ItemsCountY;
		return new Vector2[]{
			new Vector2(  Item.x * stepx     ,  Item.y * stepy      ),
			new Vector2(  Item.x * stepx     , (Item.y + 1) * stepy ),
			new Vector2( (Item.x + 1) * stepx, (Item.y + 1) * stepy ),
			new Vector2( (Item.x + 1) * stepx,  Item.y * stepy      ),
		};
	}

}
