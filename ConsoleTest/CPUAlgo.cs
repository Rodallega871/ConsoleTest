using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{

    /// <summary>
    /// CPUが次の手を考え、実施するクラス
    /// </summary>
    class CPUAlgo
    {
        /// <summary>
        /// 更新可能場所リスト
        /// </summary>
        internal List<ChkCanPutStn> CPUInfoList = new List<ChkCanPutStn>();

        //置くことが確定したときに場所を保持する。
        internal ChkCanPutStn KakuteiStn;


        bool turnFlag = true;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="prmGoishiInfo"></param>
        internal CPUAlgo(String[,] prmGoishiInfo, bool prmTurnFlag)
        {
            //ターンフラグを取得する。(CPUが黒だとtrue、白だとfalse)
            turnFlag = prmTurnFlag;

            //盤面の全ての配列についてチェックを実施。
            for (int i = 0; prmGoishiInfo.GetLength(0) > i; i++)
            {
                for (int j = 0; prmGoishiInfo.GetLength(1) > j; j++)
                {
                    //空きスペース(・)であれば
                    if (prmGoishiInfo[j, i].Equals(OutputCharacter.G01_Ban_NoGoihsi))
                    {
                        CrateCPUList(prmGoishiInfo, j, i);
                    }
                }
            }
        }

        /// <summary>
        /// 更新可能場所リストを作成する。
        /// </summary>
        /// <param name="prmGoishiInfo"></param>
        /// <param name="prmRetsu"></param>
        /// <param name="prmGyou"></param>
        internal void CrateCPUList(String[,] prmGoishiInfo, int prmRetsu, int prmGyou)
        {
            ChkCanPutStn wkputStn = new ChkCanPutStn(prmRetsu, prmGyou, prmGoishiInfo);

            //周辺の石を確認
            if (wkputStn.ChkNextPlace(turnFlag))
            {
                //延長線上の石を確認
                if (wkputStn.ChkNextPlaceRoop(turnFlag))
                {
                    //更新可能場所リストを追加する。
                    CPUInfoList.Add(wkputStn);
                }
            }
        }

        internal void DecideMaxCountPlace()
        {
            //最大値格納用リスト作成
            List<ChkCanPutStn> MaxKakunouYOU = new List<ChkCanPutStn>();

            //サイズ分回す(置ける箇所が2箇所以上ある。)
            for (int i = 0; CPUInfoList.Count > i; i++)
            {
                //最初のレコードを最大値リストに格納する。
                if (i == 0)
                {
                    //ひっくり返せる石の総数を確認する。
                    CPUInfoList[i].CountStnNum();
                    MaxKakunouYOU.Add(CPUInfoList[i]);
                }
                //それ以降は比較を実施する。
                else
                {
                    //ひっくり返せる石の総数を確認する。
                    CPUInfoList[i].CountStnNum();
                    //石の数を比較する。
                    if (CPUInfoList[i].ReturnStnCount > MaxKakunouYOU[0].ReturnStnCount)
                    {
                        MaxKakunouYOU.Clear();
                        MaxKakunouYOU.Add(CPUInfoList[i]);
                    }
                    else if (CPUInfoList[i].ReturnStnCount == MaxKakunouYOU[0].ReturnStnCount)
                    {
                        MaxKakunouYOU.Add(CPUInfoList[i]);
                    }
                }

            }

            if (MaxKakunouYOU.Count == 0)
            {
                KakuteiStn = MaxKakunouYOU[0];
            }
            else
            {
                //乱数を取得し、確定した石に入れる。
                System.Random r = new System.Random(1000);
                int wkSelectdIndex = r.Next(MaxKakunouYOU.Count);
                KakuteiStn = MaxKakunouYOU[wkSelectdIndex];
            }

        }     
    }
}

