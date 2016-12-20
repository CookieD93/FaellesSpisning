using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Faellesspisning;
using Newtonsoft.Json;

namespace Faellesspisning
{
    class Persistance
    {
        // Denne klasse bruges til at gemme og læse filer
        public static async void SaveJson(object collection,string filenameSave)
        {
            string newjson = JsonConvert.SerializeObject(collection);
            StorageFile localFile =
                await
                    ApplicationData.Current.LocalFolder.CreateFileAsync(filenameSave,
                        CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, newjson);
        }
        public static async Task<GemUge> LoadUgeFraJsonAsync(string filenameLoad)
        {
            string JsonString = await DeSerializeFileAsync(filenameLoad);
            return
                (GemUge)
                JsonConvert.DeserializeObject(JsonString, typeof(GemUge));
        }
        public static async Task<Dictionary<int,Bolig>> LoadStandardFraJsonAsync(string filenameLoad)
        {
            string JsonString = await DeSerializeFileAsync(filenameLoad);
            return
                (Dictionary<int,Bolig>)
                JsonConvert.DeserializeObject(JsonString, typeof(Dictionary<int,Bolig>));
        }
        public static async Task<List<Arrangement>> LoadArrangementFraJsonAsync(string filenameLoad)
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
        public class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }
    }
}
