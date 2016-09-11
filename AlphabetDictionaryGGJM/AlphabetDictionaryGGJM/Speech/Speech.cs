using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;//語音功能
using System.Windows.Forms;//---傳進windowsform控制項
namespace AlphabetDictionaryGGJM.Speech
{
    /// <summary>
    /// 實現語音功能 
    /// </summary>
    public class Speech
    {
        //引用參考 .net -> system.speech
        SpeechSynthesizer synth = new SpeechSynthesizer();
        int volume = 100;//--音量
        int Rate = 1;//------速率
        string Alphabet = "";//要念的單字


        /// <summary>
        /// 取得本機電腦所擁有的語音
        /// </summary>
        /// <returns></returns>
        public List<string> Get_ComputerInstallVoice()
        {
            List<string> voices = new List<string>();
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                voices.Add(voice.VoiceInfo.Name);
            }
            return voices;
        }

        /// <summary>
        /// 設定音量
        /// </summary>
        /// <param name="Set"></param>
        public void Set_volume(int Set)
        {
            this.volume = Set;
        }

        /// <summary>
        /// 設定速率
        /// </summary>
        /// <param name="Set"></param>
        public void Set_rate(int Set)
        {
            this.Rate = Set;
        }
        /// <summary>
        /// 設定使用的語音
        /// </summary>
        public void Set_UseVoice(string Set)
        {
            this.synth.SelectVoice(Set);
        }

        /// <summary>
        /// 設定要念的單字
        /// </summary>
        /// <param name="Set"></param>
        public void Set_Alphabet(string Set)
        {
            this.Alphabet = Set;
        }


        /// <summary>
        /// 根據內容說話
        /// </summary>
        /// <param name="Set"></param>
        public void Speak(string Set)
        {
            synth.Volume = this.volume;
            synth.Rate = this.Rate;
            this.synth.Speak(Set);
        }

        /// <summary>
        /// 根據內容說話
        /// </summary>
        public void Speak()
        {
            synth.Volume = this.volume;
            synth.Rate = this.Rate;
            this.synth.Speak(this.Alphabet);
        }

    }


 

}
