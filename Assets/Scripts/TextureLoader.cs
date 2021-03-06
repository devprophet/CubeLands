﻿/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   TextureLoader.cs                                   :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/19 13:58:55 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 16:00:41 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class TextureLoader : MonoBehaviour {
	
	private static Dictionary<string, CubeTexture> cubeTexturesLoaded = new Dictionary<string, CubeTexture>();

	public static void Load(){
		DirectoryInfo di = new DirectoryInfo(Application.dataPath);
		if(Application.platform == RuntimePlatform.OSXPlayer){
			di = di.Parent.Parent;
		}else if(Application.platform == RuntimePlatform.WindowsPlayer){
			di = di.Parent;
		}else if(Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor){
			di = di.Parent;
		}

		if(Directory.Exists(di.FullName + "/Module")){
			Debug.Log("Find module directory!");
			di = new DirectoryInfo(di.FullName + "/Module");
		}else{
			Debug.Log("Create module directory!");
			di = di.CreateSubdirectory("Module");
		}
		
		var files = di.GetFiles();
		
		foreach(var file in files){
			if(file.Extension == ".json"){
			var sr = file.OpenText();
			string jsonStr = sr.ReadToEnd();
			sr.Dispose();
			var cubeTexture = JsonUtility.FromJson<CubeTexture>(jsonStr);
			
			if(!cubeTexturesLoaded.ContainsKey(cubeTexture.TextureName))
				cubeTexturesLoaded.Add(cubeTexture.TextureName, cubeTexture);
			}
		}
	}

	public static bool TextureExist(string name){
		return cubeTexturesLoaded.ContainsKey(name);
	}

	public static CubeTexture GetTexture(string name){
		return cubeTexturesLoaded[name];
	}

	
	
}
