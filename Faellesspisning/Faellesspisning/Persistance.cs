using System;
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
        

        public static async void SaveJson(object collection,string filename)
        {
            string newjson = JsonConvert.SerializeObject(collection);
            StorageFile localFile =
                await
                    ApplicationData.Current.LocalFolder.CreateFileAsync(filename,
                        CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, newjson);
           
        }

        //public static async Task<ObservableCollection<NoteModel>> LoadFromJsonAsync()
        //{
        //    string personsJsonString = await DeSerializeFileAsync(notename);
        //    return
        //        (ObservableCollection<NoteModel>)
        //        JsonConvert.DeserializeObject(personsJsonString, typeof(ObservableCollection<NoteModel>));
        //}

        

        //public static async Task<string> DeSerializeFileAsync(String fileName)
        //{
        //    StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
        //    return await FileIO.ReadTextAsync(localFile);
        //}

        
    }
}
