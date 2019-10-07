using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// 石が置けるかどうかをチェックする処理
    /// </summary>
    class ChkCanPutStn
    {
        internal SevenOrient sevenOrient;
        private String[,] ChkYouGoishiInfo = new String[8, 8];
        //ひっくり返せる石の総数を保持する。
        internal int ReturnStnCount = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="prmRetus"></param>
        /// <param name="prmGyou"></param>
        internal ChkCanPutStn(int prmRetus, int prmGyou,String[,] prmGoishiInfo)
        {
            //7方位クラスを生成する。
            sevenOrient = new SevenOrient(prmRetus, prmGyou);
            ChkYouGoishiInfo = prmGoishiInfo;
        }

        /// <summary>
        /// 碁石を置きたい場所が・であることを確認する。
        /// </summary>
        /// <returns></returns>
        internal bool ChkOkitaiPlace()
        {
            if(ChkYouGoishiInfo[sevenOrient.OkitaiStn.Retsu, sevenOrient.OkitaiStn.Gyou].Equals
                (OutputCharacter.G01_Ban_NoGoihsi))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 碁石を置きたい場所の隣が置きたい石の逆であることを確認する。
        /// 上記の確認対象が一つでもあればtrueをなければfalseを返す。
        /// </summary>
        /// <returns></returns>
        internal bool ChkNextPlace(bool prmFlag)
        {
            int TrueCount = 0;

            for (int i = 0; sevenOrient.NextStnInfoLst.Count > i; i++ )
            {
                //死活フラグを確認する。。
                if (sevenOrient.NextStnInfoLst[i].NxtSKFlg)
                {
                    //真横の石が置きたい石と逆の色になっていることを確認する。
                    if (!ChkReverseColor(prmFlag, 
                        sevenOrient.NextStnInfoLst[i].RinStnLst[0].Retsu,
                        sevenOrient.NextStnInfoLst[i].RinStnLst[0].Gyou))
                    {
                        sevenOrient.NextStnInfoLst[i].NxtSKFlg = false;
                    }
                    //死活フラグのtrueの数をカウントする。
                    if (sevenOrient.NextStnInfoLst[i].NxtSKFlg)
                    {
                        TrueCount = TrueCount + 1;
                    }
                }
            }

            if (TrueCount == 0)
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// 碁石を置きたい場所の隣が置きたい石の逆であることを確認する。
        /// </summary>
        /// <returns></returns>
        internal bool ChkReverseColor(bool prmFlag,int prmRetsu, int prmGyou)
        {
            if (prmFlag)
            {
                if(ChkYouGoishiInfo[prmRetsu, prmGyou].Equals(OutputCharacter.G01_Ban_WhiteGoihsi))
                {
                    return true;
                }
            }
            else
            {
                if (ChkYouGoishiInfo[prmRetsu, prmGyou].Equals(OutputCharacter.G01_Ban_BlackGoihsi))
                {
                   return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 対象の列、行を受け取り・であるかどうかを確認する。
        /// </summary>
        /// <param name="prmRetsu"></param>
        /// <param name="prmGyou"></param>
        /// <returns></returns>
        internal bool ChkNoGoishi(int prmRetsu, int prmGyou)
        {
            if (ChkYouGoishiInfo[prmRetsu, prmGyou].Equals(OutputCharacter.G01_Ban_NoGoihsi))
            {
                //対象が・である。
                return true;
            }
            return false;
        }

        /// <summary>
        /// 延長線上の石を確認する。
        /// </summary>
        /// <param name="prmFlag"></param>
        /// <returns></returns>
        internal bool ChkNextPlaceRoop(bool prmFlag)
        {
            //
            int TrueCount = 0;

            for (int i = 0; sevenOrient.NextStnInfoLst.Count > i; i++)
            {
                while (true)
                {
                    if (sevenOrient.NextStnInfoLst[i].NxtSKFlg)
                    {

                        Stone wkStone =
　　　　　　　　　　　    new Stone(sevenOrient.NextStnInfoLst[i].RinStnLst[0].Retsu
              　　　　　　　　　　　+ sevenOrient.NextStnInfoLst[i].YokoInf * sevenOrient.NextStnInfoLst[i].StoneCount,
              　　　　　　　　　　　sevenOrient.NextStnInfoLst[i].RinStnLst[0].Gyou
              　　　　　　　　　　　+ sevenOrient.NextStnInfoLst[i].TateInf * sevenOrient.NextStnInfoLst[i].StoneCount);

                        //石の存在チェックを行う。(盤の中に収まるか)
                        if (!Comm.ChkInnerOseroBan(wkStone.Retsu, wkStone.Gyou))
                        {
                            //死活フラグをfalseで更新する。
                            sevenOrient.NextStnInfoLst[i].NxtSKFlg = false;
                        }
                        //・判定を実施する。
                        else if (ChkNoGoishi(wkStone.Retsu, wkStone.Gyou))
                        {
                            //死活フラグをfalseで更新する。
                            sevenOrient.NextStnInfoLst[i].NxtSKFlg = false;

                        }
                        //同色チェックを実施する。
                        else if (!ChkReverseColor(prmFlag, wkStone.Retsu, wkStone.Gyou))
                        {
                            //更新確定フラグをtrueで更新する。
                            sevenOrient.NextStnInfoLst[i].KakuteiFlg = true;
                            sevenOrient.NextStnInfoLst[i].RinStnLst.Add(wkStone);
                            TrueCount++;
                        }
                        else
                        {
                            //隣石延長線上カウントを1増やし処理をroopする。
                            sevenOrient.NextStnInfoLst[i].RinStnLst.Add(wkStone);
                            sevenOrient.NextStnInfoLst[i].StoneCount++;
                        }

                        if (sevenOrient.NextStnInfoLst[i].KakuteiFlg)
                        {
                            //更新処理が確定した場合ループを抜ける
                            break;
                        }
                    }
                    else
                    {
                        //更新処理が抜ける。
                        break;
                    }
                }
            }

            if (TrueCount == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 確定した石を更新する（ひっくり返す）。
        /// </summary>
        /// <param name="prmFlag"></param>
        /// <returns></returns>
        internal String[,] UpdateStn(bool prmFlag)
        {
            for (int i = 0; sevenOrient.NextStnInfoLst.Count > i; i++)
            {
                if (sevenOrient.NextStnInfoLst[i].KakuteiFlg)
                {
                    for (int j = 0; sevenOrient.NextStnInfoLst[i].RinStnLst.Count > j; j++ )
                    {
                        if (prmFlag)
                        {
                            //色を変更する。
                            ChkYouGoishiInfo[
                            sevenOrient.NextStnInfoLst[i].RinStnLst[j].Retsu,
                             sevenOrient.NextStnInfoLst[i].RinStnLst[j].Gyou] = OutputCharacter.G01_Ban_BlackGoihsi;
                        }
                        else
                        {
                            //色を変更する。
                            ChkYouGoishiInfo[
                            sevenOrient.NextStnInfoLst[i].RinStnLst[j].Retsu,
                             sevenOrient.NextStnInfoLst[i].RinStnLst[j].Gyou] = OutputCharacter.G01_Ban_WhiteGoihsi;

                        }
                    }
                }
            }

            return ChkYouGoishiInfo;
        }


        internal void CountStnNum()
        {
            //置きたい場所を取得する。
            ReturnStnCount = 1;

            //全てのリストについて確認する。
            foreach (var worklst in sevenOrient.NextStnInfoLst)
            {
               if(worklst.KakuteiFlg)
                {
                    ReturnStnCount = ReturnStnCount + worklst.RinStnLst.Count;
                }
            }

        }


        }
}
