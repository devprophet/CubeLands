/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   EndlessView.cs                                     :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/18 16:19:33 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 12:06:08 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessView : MonoBehaviour {
	public WorldManager WManager;
	public int ViewDistance = 380;
	public int chunkVisibleInViewDistance;

	Dictionary<Vector3, Chunk> FirstDictionary = new Dictionary<Vector3, Chunk>();
	Dictionary<Vector3, Chunk> SecndDictionary = new Dictionary<Vector3, Chunk>();

	void Start(){
		//chunkVisibleInViewDistance = Mathf.RoundToInt(ViewDistance / WManager.ChunkSize);
	}

	void UpdateVisibleChunks(){
		chunkVisibleInViewDistance = Mathf.RoundToInt(ViewDistance / WManager.ChunkSize);
		int currentChunkCoordX = Mathf.RoundToInt(transform.position.x / WManager.ChunkSize);
		int currentChunkCoordZ = Mathf.RoundToInt(transform.position.z / WManager.ChunkSize);

		FirstDictionary = new Dictionary<Vector3, Chunk>(SecndDictionary);
		SecndDictionary.Clear();
		
		for(int xOffset = -chunkVisibleInViewDistance; xOffset <= chunkVisibleInViewDistance; xOffset++){
			for(int zOffset = -chunkVisibleInViewDistance; zOffset <= chunkVisibleInViewDistance; zOffset++){
				Vector3 viewedChunkCoord = new Vector3(currentChunkCoordX + xOffset, 0, currentChunkCoordZ + zOffset);
				if(FirstDictionary.ContainsKey(viewedChunkCoord)){
					if(!SecndDictionary.ContainsKey(viewedChunkCoord))
						SecndDictionary.Add(viewedChunkCoord, FirstDictionary[viewedChunkCoord]);
					FirstDictionary.Remove(viewedChunkCoord);
				}else{
					SecndDictionary.Add(viewedChunkCoord, WManager.CreateChunk(viewedChunkCoord, viewedChunkCoord * WManager.ChunkSize));
				}
			}
		}

		foreach(var kv in FirstDictionary){
			WManager.DeleteChunk(kv.Key);
		}
		
		FirstDictionary.Clear();
		
	}

	void Update(){
		UpdateVisibleChunks();
	}

}
