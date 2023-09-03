using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace WinFormsApp2.Models
{
    /// <summary>
    /// 設定ファイルを管理するためのクラスです。
    /// </summary>
    internal class SettingManageModel
    {
        //[TODO]publicに変更
        private ConfigKeyList config;

        public SettingManageModel()
        {
            config = new ConfigKeyList();
        }

        /// <summary>
        /// 設定ファイルの内容を読み込み、JSONデータをデシリアライズします。
        /// </summary>
        /// <returns>正常であればtrue、異常であればfalseを返します。</returns>
        public bool ReadSettingFile()
        {
            try
            {
                using (var sr = new StreamReader(@".\sample.json", Encoding.UTF8))
                {
                    var jsonReadData = sr.ReadToEnd();

                    //Deserialize from json to object
                    config = JsonConvert.DeserializeObject<ConfigKeyList>(jsonReadData);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //[TODO]jsonファイルが他プロセスによってオープンされていた場合、try catch
        //[TODO]設定内容が変更されていたら、書き出す
        /// <summary>
        /// 設定の内容をJSONデータにデシリアライズし、設定ファイルに書込みます。
        /// </summary>
        /// <returns>正常であればtrue、異常であればfalseを返します。</returns>
        public bool WriteSettingFile()
        {
            try
            {
                //Serialize from object to json
                var jsonWriteData = JsonConvert.SerializeObject(config, Formatting.Indented);

                //Write JSON file
                //[TODO]ファイル名のハードコーディングを解消
                using (var sw = new StreamWriter(@".\sample.json", false, Encoding.UTF8)) //Overwrite mode
                {
                    sw.Write(jsonWriteData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// IPアドレスの形式が正しいか確認します。
        /// </summary>
        /// <param name="ipAddr">IPアドレス</param>
        /// <returns>正常であればtrue、異常であればfalseを返します。</returns>
        /// <remarks>
        /// 正規表現を使用し、ipv4形式になっているか確認しています。
        /// </remarks>
        public bool IsValidIp(string ipAddr)
        {
            string ipv4Pattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            return Regex.IsMatch(ipAddr, ipv4Pattern);
        }

        /// <summary>
        /// ポート番号の形式が正しいか確認します。
        /// </summary>
        /// <param name="portNum">ポート番号</param>
        /// <returns>正常であればtrue、異常であればfalseを返します。</returns>
        /// <remarks>
        /// ポート番号が範囲内であることを確認しています。
        /// </remarks>
        public bool IsValidPort(int portNum)
        {
            //[TODO]マジックナンバーの置き換え
            if (portNum >= 1 && portNum <= 65535)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //[TODO]既存のIPとの重複
        //[TODO]登録数の上限超過チェック
        /// <summary>
        /// 新しくR/CのIPアドレス、ポート番号を登録します。
        /// </summary>
        /// <param name="newIp">変更後のIPアドレス</param>
        /// <param name="newPort">変更後のポート番号</param>
        /// <returns>正常に登録できればtrue、登録数の上限を超過した場合はfalseを返します。</returns>
        public bool AddNewRc(string newIp, int newPort)
        {
            RobotControllerListKeyList robotControllerListKeyList = new RobotControllerListKeyList
            {
                rcserial = "",
                ip = newIp,
                port = newPort
            };
            config.robotControllerList.Add(robotControllerListKeyList);
            return true;
        }

        //[TODO]既存のIPとの重複
        /// <summary>
        /// 既存のR/CのIPアドレス、ポート番号を更新します。
        /// 登録済のRCSERIALはクリアされます。
        /// </summary>
        /// <param name="index">更新対象のR/Cの番号</param>
        /// <param name="newIp">変更後のIPアドレス</param>
        /// <param name="newPort">変更後のポート番号</param>
        /// <returns>正常に更新できればtrue、R/Cの番号が見つからなければfalseを返します。</returns>
        /// <remarks>
        /// R/Cの番号は、データグリッドの１行目が「0」、２行目が「1」…になります。
        /// </remarks>
        public bool UpdateRcInfo(int index, string newIp, int newPort)
        {
            if (config.robotControllerList != null &&       //インスタンスが存在している
                index >= 0 &&                               //インデックスが正の数
                index < config.robotControllerList.Count)   //要素数が範囲内
            {
                config.robotControllerList[index].rcserial = "";
                config.robotControllerList[index].ip = newIp;
                config.robotControllerList[index].port = newPort;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 登録済みのR/CのIPアドレス、ポート番号の情報を削除します。
        /// </summary>
        /// <param name="no">削除対象のR/Cの番号</param>
        /// <returns>正常に削除できればtrue、R/Cの番号が見つからなければfalseを返します。</returns>
        /// <remarks>
        /// R/Cの番号は、データグリッドの１行目が「0」、２行目が「1」…になります。
        /// </remarks>
        public bool DeleteRc(int index)
        {
            if (config.robotControllerList != null &&       //インスタンスが存在している
                index >= 0 &&                               //インデックスが正の数
                index < config.robotControllerList.Count)   //要素数が範囲内
            {
                config.robotControllerList.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateRCSERIAL(int index, string rcserial)
        {
            if (config.robotControllerList != null &&       //インスタンスが存在している
                index >= 0 &&                               //インデックスが正の数
                index < config.robotControllerList.Count)   //要素数が範囲内
            {
                config.robotControllerList[index].rcserial = rcserial;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// R2プロトコルサーバのIPアドレス、ポート番号を更新します。
        /// </summary>
        /// <param name="newIp">変更後のIPアドレス</param>
        /// <param name="newPort">変更後のポート番号</param>
        /// <remarks>
        /// 事前にIsValidIp(), IsValidPortを使用して、正しい引数であることを確認してください。
        /// </remarks>
        public void UpdateR2sInfo(string newIp, int newPort)
        {
            if (config.robotControllerList != null)
            {
                config.server.ip = newIp;
                config.server.port = newPort;
            }
        }
    }
}
