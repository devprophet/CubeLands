/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   Test.cs                                            :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/19 14:57:31 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 15:50:51 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TextureLoader.Load();
		var path = "/Users/alexis/Desktop/base.json";
		var sw = File.CreateText(path);
		
		var cubeTexture = new CubeTexture();

		cubeTexture.FaceBack 	= new Vector2(0, 0);
		cubeTexture.FaceRight 	= new Vector2(0, 0);
		cubeTexture.FaceFront 	= new Vector2(0, 0);
		cubeTexture.FaceLeft 	= new Vector2(0, 0);
		cubeTexture.FaceTop 	= new Vector2(0, 0);
		cubeTexture.FaceBottom 	= new Vector2(0, 0);

		cubeTexture.TextureTileSet 	= "http://mon.addresse.fr/mon.fichier.json";
		cubeTexture.isLocal 		= false;

		cubeTexture.Author = "Alex";
		cubeTexture.TextureName = "First Cube";

		sw.Write(JsonUtility.ToJson(cubeTexture, true));
		sw.Flush();
		sw.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
