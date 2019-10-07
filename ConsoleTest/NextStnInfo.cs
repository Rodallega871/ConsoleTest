using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// 置きたい石からある方位の石の情報を保持する。
    /// 通称：隣石リスト保持クラス
    /// </summary>
    class NextStnInfo
    {
        //死活フラグ
        /*
         * 置きたい石の座標からある方角に
         * ひっくり返せる対象があるかどうかを判定する。
         */
        internal bool NxtSKFlg { get; set; } = true;
        //更新確定フラグ
        internal bool KakuteiFlg { get; set; } = false;
        //隣石延長線上カウント
        internal int StoneCount { get; set; } = 1;

        //置きたい石から横に何マス進むかを保持する。
        internal int YokoInf { get; set; }
        //置きたい石から縦に何マス進むかを保持する。
        internal int TateInf { get; set; }
        //隣石リスト
        internal List<Stone> RinStnLst = new List<Stone>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="prmYokoInf"></param>横情報(置きたい石からの相対パス)
        /// <param name="prmTateInf"></param>縦情報(置きたい石からの相対パス)
        /// <param name="prmOkitaiR"></param>置きたい石の列座標
        /// <param name="prmOkitaiG"></param>置きたい石の行座標
        internal NextStnInfo(int prmYokoInf, int prmTateInf,int prmOkitaiR,int prmOkitaiG)
        {
            //縦横何マス進むかをセットする。
            YokoInf = prmYokoInf;
            TateInf = prmTateInf;
            //縦横情報をもとに置きたい石の真横の石の情報を
            //隣石リストのindexの0番目に格納する。
            Stone wkStn = new Stone(prmOkitaiR + prmYokoInf, prmOkitaiG + prmTateInf);
            RinStnLst.Add(wkStn);

            //真横の石が盤の中に納まっているかどうかを判定する。
            if (!Comm.ChkInnerOseroBan(RinStnLst[0].Retsu, RinStnLst[0].Gyou))
            {
                //収まっていなければ死活フラグをfalseにする。
                NxtSKFlg = false;
            }

        }

        



    }
}
