using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube {
	
	const float size = .5f;

	public static CMesh CreateCube(Vector3 position, bool[] faces){
		if(faces.Length != 6){
			throw new UnityException("Faces array do not conains 6 elements!", new System.IndexOutOfRangeException());
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
		for(int i = 0; i < faces.Length; i++){
			if(faces[i]){
				int vCount = m.vertices.Count;
				switch(i){
					case 0:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[0], v[1], v[2], v[3] });
						m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 1:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[3], v[2], v[6], v[7] });
						m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 2:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[7], v[6], v[5], v[4] });
						m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 3:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[4], v[5], v[1], v[0] });
						m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 4:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[1], v[5], v[6], v[2] });
						m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					case 5:
						vCount = m.vertices.Count;
						m.AddTriangles(new int[]{0 + (vCount), 1 + (vCount), 2 + (vCount), 0 + (vCount), 2 + (vCount), 3 + (vCount)});
						m.AddVertices(new Vector3[]{ v[4], v[0], v[3], v[7] });
						m.AddUVs(new Vector2[]{  new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
					break;
					default:
					break;
				}
			}
		}

		return m;
		
	}

}
