/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   Chunk.cs                                           :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/18 15:23:59 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/18 17:40:14 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {
	public WorldManager WManager;
	
	public void Generate(){
		if(WManager == null)
			return;
		CMesh m = new CMesh();

		for(int i = 0; i < WManager.ChunkSize; i++){
			for(int j = 0; j < WManager.ChunkSize; j++){
				
				Vector3 p = new Vector3(i, 0, j) + transform.position;
				int h = (int)(Mathf.PerlinNoise(p.x * WManager.PerlinSize, p.z * WManager.PerlinSize) * WManager.PerlinPower);
				
				bool visible = h >= .5 ? true : false;

				if(!visible)
					continue;

				var r = (int)(Mathf.PerlinNoise( (p.x + 1) * WManager.PerlinSize, p.z * WManager.PerlinSize) * WManager.PerlinPower) == h ? true : false;
				var l = (int)(Mathf.PerlinNoise( (p.x - 1) * WManager.PerlinSize, p.z * WManager.PerlinSize) * WManager.PerlinPower) == h ? true : false;

				var f = (int)(Mathf.PerlinNoise( p.x * WManager.PerlinSize, (p.z + 1) * WManager.PerlinSize) * WManager.PerlinPower) == h ? true : false;
				var b = (int)(Mathf.PerlinNoise( p.x * WManager.PerlinSize, (p.z - 1) * WManager.PerlinSize) * WManager.PerlinPower) == h ? true : false;

				m.AddCMesh(Cube.CreateCube(new Vector3(i, h, j), new bool[]{!b, !r, !f, !l, true, false}));

			}
		}
		
		MeshFilter meshFilter;
		MeshRenderer meshRenderer;

		if( (meshFilter = GetComponent<MeshFilter>()) == null )
			meshFilter = gameObject.AddComponent<MeshFilter>();
			
		if( (meshRenderer = GetComponent<MeshRenderer>()) == null )
			meshRenderer = gameObject.AddComponent<MeshRenderer>();
			
		meshRenderer.material = Resources.Load<Material>("DefaultMaterial");
		meshFilter.mesh = m.ToUnityMesh();

	}
}
