/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   Cube.cs                                            :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/18 15:16:18 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 15:55:44 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube {

	public static CMesh CreateCube(Vector3 position, float size, bool[] faces, string textureName){
		if(faces.Length != 6){
			throw new System.Exception("Faces array do not conains 6 elements!", new System.IndexOutOfRangeException());
		}
		
		Vector3[] v = new Vector3[]{
			new Vector3(-size, -size, -size) + position,
			new Vector3(-size,  size, -size) + position,
			new Vector3( size,  size, -size) + position,
			new Vector3( size, -size, -size) + position,

			new Vector3(-size, -size,  size) + position,
			new Vector3(-size,  size,  size) + position,
			new Vector3( size,  size,  size) + position,
			new Vector3( size, -size,  size) + position,
		};

		CMesh m = new CMesh();
		Vector2[] _uvs = null;
		if(TextureLoader.TextureExist(textureName)){
			_uvs = (TextureLoader.GetTexture(textureName).CalculatedUV());
		}
		//m.AddUVs( TextureLoader.TextureExist(textureName) ? TextureLoader.GetTexture(textureName));
		for(int i = 0; i < faces.Length; i++){
			if(faces[i]){
				int vCount = m.vertices.Count;
				switch(i){
					case 0:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[0], v[1], v[2], v[3] });
						if(_uvs != null)
							m.AddUVs(new Vector2[]{ _uvs[0], _uvs[1], _uvs[2], _uvs[3] });
						//m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 1:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[3], v[2], v[6], v[7] });
						if(_uvs != null)
							m.AddUVs(new Vector2[]{ _uvs[4], _uvs[5], _uvs[6], _uvs[7] });
						//m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 2:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[7], v[6], v[5], v[4] });
						if(_uvs != null)
							m.AddUVs(new Vector2[]{ _uvs[8], _uvs[9], _uvs[10], _uvs[11] });
						//m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 3:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[4], v[5], v[1], v[0] });
						if(_uvs != null)
							m.AddUVs(new Vector2[]{ _uvs[12], _uvs[13], _uvs[14], _uvs[15] });
						//m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 4:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[1], v[5], v[6], v[2] });
						if(_uvs != null)
							m.AddUVs(new Vector2[]{ _uvs[16], _uvs[17], _uvs[18], _uvs[19] });
						//m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 5:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[4], v[0], v[3], v[7] });
						if(_uvs != null)
							m.AddUVs(new Vector2[]{ _uvs[20], _uvs[21], _uvs[22], _uvs[23] });
						//m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					default:
					break;
				}
			}
		}

		return m;
		
	}

}
