/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   EndlessView.cs                                     :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/18 16:19:33 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/18 17:43:27 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessView : MonoBehaviour {
	public WorldManager WManager;
	public int ViewDistance = 380;
	public int chunkVisibleInViewDistance;

	Dictionary<Vector3, Chunk> terrainChunkDictionary = new Dictionary<Vector3, Chunk>();
	Dictionary<Vector3, Chunk> RemovedterrainChunkDictionary = new Dictionary<Vector3, Chunk>();

	void Start(){
		chunkVisibleInViewDistance = Mathf.RoundToInt(ViewDistance / WManager.ChunkSize);
	}

	void UpdateVisibleChunks(){
		
		foreach(var u in RemovedterrainChunkDictionary){
			WManager.DeleteChunk(u.Key * WManager.ChunkSize);
			terrainChunkDictionary.Remove(u.Key);
		}
		
		RemovedterrainChunkDictionary.Clear();

		int currentChunkCoordX = Mathf.RoundToInt(transform.position.x / WManager.ChunkSize);
		int currentChunkCoordZ = Mathf.RoundToInt(transform.position.z / WManager.ChunkSize);

		for(int xOffset = -chunkVisibleInViewDistance; xOffset <= chunkVisibleInViewDistance; xOffset++){
			for(int zOffset = -chunkVisibleInViewDistance; zOffset <= chunkVisibleInViewDistance; zOffset++){
				Vector3 viewedChunkCoord = new Vector3(currentChunkCoordX + xOffset, 0, currentChunkCoordZ + zOffset);
				if(!terrainChunkDictionary.ContainsKey(viewedChunkCoord)){
					var c = WManager.CreateChunk(viewedChunkCoord * WManager.ChunkSize);
					terrainChunkDictionary.Add(viewedChunkCoord, c);
					RemovedterrainChunkDictionary.Add(viewedChunkCoord, c);
				}
				if(RemovedterrainChunkDictionary.ContainsKey(viewedChunkCoord)){
					RemovedterrainChunkDictionary.Remove(viewedChunkCoord);
				}
			}
		}
	}

	void Update(){
		UpdateVisibleChunks();
	}

}
