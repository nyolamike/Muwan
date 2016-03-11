using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muwan
{
    class Setting
    {
        //logs for this class
        private static Logger logger = LogManager.GetCurrentClassLogger();


        public int TallyWatcherInterval { get { return this.SettingsModel.TallyWatcherInterval; } }
        public int DraftWatcherInterval { get { return this.SettingsModel.DraftWatcherInterval; } }

        public string BaseDomain { get { return this.SettingsModel.BaseDomain; } }
        public string PersisterURL { get { return this.SettingsModel.PersisterURL; } }
        public string FetcherURL { get { return this.SettingsModel.FetcherURL; } }

        //atomic parttern
        private static Setting Instance;

        public static Setting GetInstance (){            
            if (Setting.Instance == null)
            {
                Setting.Instance = new Setting();
            }
            return Setting.Instance;           
        }

        private SettingsModel SettingsModel;

        private Setting()
        {
            this.SettingsModel = new SettingsModel();
            logger.Info("==>Created the settings object");
        }

        public void LoadSettings()
        {
            logger.Info("==>Loading settings");

            string fileName = "setting.json";
            string currentDirectory = System.Environment.CurrentDirectory;
            string filePath = Path.Combine(currentDirectory, fileName);
            string i = "Path for settings is : " + filePath;
            logger.Info(i);
            //read in the json file
            if(File.Exists(filePath)){
                FileStream file = File.Open(filePath, FileMode.Open);
                StreamReader sr = new StreamReader(file);
                string settingString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                i = "The follwing settings were found : " + settingString;
                logger.Info(i);
                SettingsModel model =  JsonConvert.DeserializeObject<SettingsModel>(settingString);
                this.SettingsModel = model;
                logger.Info("Settings loaded successfully");
            }else{
                logger.Info("Settings file was not found");
            }
        }



    }
}
