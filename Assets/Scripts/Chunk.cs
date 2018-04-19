/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   Chunk.cs                                           :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/18 15:23:59 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 22:25:29 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

using LibNoise;
using LibNoise.Generator;
using LibNoise.Operator;

public class Chunk : MonoBehaviour {
	public WorldManager WManager;
	private CMesh m;

	public CMesh Calculate(CMesh cm, Vector3 tposition){
		CMesh m = new CMesh(cm);
		var perlin = new Perlin(0.01, 1.87, 2, 4, 2304, QualityMode.Medium);
		for(int i = 0; i < WManager.ChunkSize; i ++){
			for(int j = 0; j < WManager.ChunkSize; j ++){
				
				Vector3 p = new Vector3(i, 0, j) + tposition;
				//int h = (int)(Mathf.PerlinNoise(p.x * WManager.PerlinSize, p.z * WManager.PerlinSize) * WManager.PerlinPower);
				int h = (int)perlin.GetValue(p.x, p.y, p.z);
				/*bool visible = h >= .5 ? true : false;

				if(!visible)
					continue;*/
				
				/*
				var r = (int)(Mathf.PerlinNoise( (p.x + 1) * WManager.PerlinSize, p.z * WManager.PerlinSize) * WManager.PerlinPower) == h ? true : false;
				var l = (int)(Mathf.PerlinNoise( (p.x - 1) * WManager.PerlinSize, p.z * WManager.PerlinSize) * WManager.PerlinPower) == h ? true : false;

				var f = (int)(Mathf.PerlinNoise( p.x * WManager.PerlinSize, (p.z + 1) * WManager.PerlinSize) * WManager.PerlinPower) == h ? true : false;
				var b = (int)(Mathf.PerlinNoise( p.x * WManager.PerlinSize, (p.z - 1) * WManager.PerlinSize) * WManager.PerlinPower) == h ? true : false;
				*/

				var r = (int)perlin.GetValue(p.x + 1, p.y, p.z) == h ? true : false;
				var l = (int)perlin.GetValue(p.x - 1, p.y, p.z) == h ? true : false;

				var f = (int)perlin.GetValue(p.x, p.y, p.z + 1) == h ? true : false;
				var b = (int)perlin.GetValue(p.x, p.y, p.z - 1) == h ? true : false;

				m.AddCMesh(Cube.CreateCube(new Vector3(i, h, j), WManager.CubeSize / 2f, new bool[]{!b, !r, !f, !l, true, false} , "__base__"));
			}
		}
		return m;
	}

	bool calculated = false;
	
	public void Generate(){
		if(WManager == null)
			return;
		m = new CMesh();
		Vector3 tposition = transform.position;
		Task.Run(
			() => {
				m = Calculate(m, tposition);
				calculated = true;
			}
		);

	}

	void Update(){
		if(calculated){
			MeshFilter meshFilter;
			MeshRenderer meshRenderer;

			if( (meshFilter = GetComponent<MeshFilter>()) == null )
				meshFilter = gameObject.AddComponent<MeshFilter>();
				
			if( (meshRenderer = GetComponent<MeshRenderer>()) == null )
				meshRenderer = gameObject.AddComponent<MeshRenderer>();
				
			meshRenderer.material = Resources.Load<Material>("DefaultMaterial");
			meshFilter.mesh = m.ToUnityMesh();
			calculated = false;
		}
	}
}
