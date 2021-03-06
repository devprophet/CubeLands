﻿/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   UVMapping.cs                                       :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/19 17:04:38 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 17:44:48 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVMapping : MonoBehaviour {
	
	public static Vector2[] GetTileUV(int ItemsCountX, int ItemsCountY, Vector2 Item){
		float stepx = 1f / (float)ItemsCountX;
		float stepy = 1f / (float)ItemsCountY;
		
		float _x = Item.x * stepx;
		float _y = Item.y * stepy;

		float cx = stepx / 10f;
		float cy = stepy / 10f;

		return new Vector2[]{
			new Vector2(  _x + cx        ,  _y + cy         ),
			new Vector2(  _x + cx        ,  _y + stepy - cy ),
			new Vector2(  _x + stepx - cx,  _y + stepy - cy ),
			new Vector2(  _x + stepx - cx,  _y + cy         ),
		};
	}
}
