﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace Faellesspisning
{
    class Persistance
    {
        

        public static async void SaveJson(object collection,string filenameSave)
        {
            string newjson = JsonConvert.SerializeObject(collection);
            StorageFile localFile =
                await
                    ApplicationData.Current.LocalFolder.CreateFileAsync(filenameSave,
                        CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, newjson);
           
        }

        public static async Task<Gem> LoadGemFromJsonAsync(string filenameLoad)
        {
            string JsonString = await DeSerializeFileAsync(filenameLoad);
            return
                (Gem)
                JsonConvert.DeserializeObject(JsonString, typeof(Gem));
        }
        public static async Task<Dictionary<int,Bolig>> LoadStandardFromJsonAsync(string filenameLoad)
        {
            string JsonString = await DeSerializeFileAsync(filenameLoad);
            return
                (Dictionary<int,Bolig>)
                JsonConvert.DeserializeObject(JsonString, typeof(Dictionary<int,Bolig>));
        }
        public static async Task<List<Arrangement>> LoadArrangementFromJsonAsync(string filenameLoad)
        {
            string JsonString = await DeSerializeFileAsync(filenameLoad);
            return
                (List<Arrangement>)
                JsonConvert.DeserializeObject(JsonString, typeof(List<Arrangement>));
        }



        public static async Task<string> DeSerializeFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        }


    }
}
