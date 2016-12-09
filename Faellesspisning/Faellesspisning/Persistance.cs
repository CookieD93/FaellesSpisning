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

        public static async Task<Dictionary<int,Bolig>> LoadFromJsonAsync(string filenameLoad)
        {
            string personsJsonString = await DeSerializeFileAsync(filenameLoad);
            return
                (Dictionary<int,Bolig>)
                JsonConvert.DeserializeObject(personsJsonString, typeof(Dictionary<int,Bolig>));
        }



        public static async Task<string> DeSerializeFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        }


    }
}
