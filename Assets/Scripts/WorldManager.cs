/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   WorldManager.cs                                    :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/18 15:46:18 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/18 17:37:31 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {
	[Header("Parameters for all chunks")]
	[Space(5)]

	public int ChunkSize = 100;

	[Range(1, 2)]
	public float CubeSize = 1f;

	[Space(10)]
	[Header("Parameters for the perlin noise function")]
	[Space(5)]

	[Range(0, 1)]
	public float PerlinSize = 0.05f;

	[Range(1, 10)]
	public float PerlinPower = 2f;
	
	public string PerlinSeed = "Hello world!";

	private Dictionary<Vector3, Chunk> Chunks = new Dictionary<Vector3, Chunk>();

	public bool ChunkExist(Vector3 at){
		return Chunks.ContainsKey(at);
	}

	public Chunk GetChunk(Vector3 at){
		if(ChunkExist(at))
			return Chunks[at];
		else
			throw new System.Exception(string.Format("Error the chunk at {0} not exist!", at));
	}

	public Chunk CreateChunk(Vector3 at){
		GameObject chunk = new GameObject("Chunk " + at.ToString());
		chunk.transform.position = at;
		var c = chunk.AddComponent<Chunk>();
		c.WManager = this;
		Chunks.Add(at, c);
		c.Generate();
	
		return c;
	}

	public void DeleteChunk(Vector3 at){
		if(ChunkExist(at)){
			Destroy(Chunks[at].gameObject);
			Chunks.Remove(at);
			//Debug.Log("Deleted!");
		}else{
			Debug.LogWarningFormat("Can't destroy the chunk at {0} beacause is not exist!", at);
		}
	}
	
}
