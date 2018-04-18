/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   Testing.cs                                         :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/18 15:16:59 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/18 15:31:03 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
	//bool[,] cubes;
	
	public int Width = 4;
	public int Height = 4;

	public float size = 0.05f;
	public float power = 1f;

	void Start(){
		//cubes = new bool[Width, Height];
		CMesh m = new CMesh();

		for(int i = 0; i < Width; i++){
			for(int j = 0; j < Height; j++){
				
				Vector3 p = new Vector3(i, 0, j) + transform.position;
				int h = (int)(Mathf.PerlinNoise(p.x * size, p.z * size) * power);
				
				bool visible = h >= .5 ? true : false;

				if(!visible)
					continue;

				var r = (int)(Mathf.PerlinNoise( (p.x + 1) * size, p.z * size) * power) == h ? true : false;
				var l = (int)(Mathf.PerlinNoise( (p.x - 1) * size, p.z * size) * power) == h ? true : false;

				var f = (int)(Mathf.PerlinNoise( p.x * size, (p.z + 1) * size) * power) == h ? true : false;
				var b = (int)(Mathf.PerlinNoise( p.x * size, (p.z - 1) * size) * power) == h ? true : false;

				m.AddCMesh(Cube.CreateCube(new Vector3(i, h, j), new bool[]{!b, !r, !f, !l, true, false}));

			}
		}
		
		GetComponent<MeshFilter>().mesh = m.ToUnityMesh();
	}
}
