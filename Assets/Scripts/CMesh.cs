using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMesh {
	// Tableau stockant les vertex
	public List<Vector3> vertices 	{ get; private set; }
	// Tableau stockant les triangles
	public List<int> triangles 		{ get; private set; }
	// Tableau stockant les uvs
	public List<Vector2> uvs 		{ get; private set; }

	// Initialise les tableau
	public CMesh(){
		vertices 	= new List<Vector3>();
		triangles 	= new List<int>();
		uvs 		= new List<Vector2>();
	}

	// Ajoute un tableau de vertex
	public void AddVertices(Vector3[] vertices){
		this.vertices.AddRange(vertices);
	}
	// Ajoute une list de vertex
	public void AddVertices(List<Vector3> vertices){
		this.vertices.AddRange(vertices);
	}
	// Ajout un tableau de triangles
	public void AddTriangles(int[] triangles){
		this.triangles.AddRange(triangles);
	}
	// Ajoute une list de triangles
	public void AddTriangles(List<int> triangles){
		this.triangles.AddRange(triangles);
	}
	// Ajoute un tableau de Vector2
	public void AddUVs(Vector2[] UVs){
		uvs.AddRange(UVs);
	}
	// Ajoute une List de Vector2
	public void AddUVs(List<Vector2> UVs){
		uvs.AddRange(UVs);
	}
	// Recalcule l'index des triangles
	public int[] RecalulateTriangles(int[] triangles){
		int[] t = new int[triangles.Length];
		for(int i = 0; i < triangles.Length; i++){
			t[i] = triangles[i] + vertices.Count;
		}
		return t;
	}
	// Recalcule l'index des triangles
	public int[] RecalulateTriangles(List<int> triangles){
		int[] t = new int[triangles.Count];
		for(int i = 0; i < triangles.Count; i++){
			t[i] = triangles[i] + vertices.Count;
		}
		return t;
	}
	// Ajoute les vertex, triangles et uv d'un CMesh
	public void AddCMesh(CMesh cmesh){
		AddTriangles(RecalulateTriangles(cmesh.triangles));
		AddVertices(cmesh.vertices);
		AddUVs(cmesh.uvs);
	}
	// Convertit le CMesh en Mesh
	public Mesh ToUnityMesh(){
		
		Mesh m = new Mesh();
		
		m.SetVertices(vertices);
		m.SetTriangles(triangles, 0);
		m.SetUVs(0, uvs);
		m.RecalculateBounds();
		m.RecalculateNormals();

		return m;
	}

}
